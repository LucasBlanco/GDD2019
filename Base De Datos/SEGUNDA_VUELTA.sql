USE [master]
GO
/****** Object:  Database [SEGUNDA_VUELTA]    Script Date: 05/06/2019 15:34:39 ******/
CREATE DATABASE [SEGUNDA_VUELTA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SEGUNDA_VUELTA', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\SEGUNDA_VUELTA.mdf' , SIZE = 119808KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SEGUNDA_VUELTA_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER2012\MSSQL\DATA\SEGUNDA_VUELTA_log.ldf' , SIZE = 757248KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SEGUNDA_VUELTA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ARITHABORT OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET  MULTI_USER 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SEGUNDA_VUELTA]
GO
/****** Object:  UserDefinedTableType [dbo].[cabinas]    Script Date: 05/06/2019 15:34:39 ******/
CREATE TYPE [dbo].[cabinas] AS TABLE(
	[nro] [decimal](18, 0) NULL,
	[piso] [decimal](18, 0) NULL,
	[id_servicio] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ids]    Script Date: 05/06/2019 15:34:39 ******/
CREATE TYPE [dbo].[ids] AS TABLE(
	[id] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[tramo]    Script Date: 05/06/2019 15:34:39 ******/
CREATE TYPE [dbo].[tramo] AS TABLE(
	[indice] [int] NULL,
	[inicio] [int] NULL,
	[destino] [int] NULL,
	[precio] [decimal](18, 2) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[altaCliente]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[altaCliente] 
								@nombre nvarchar(255),
								@apellido nvarchar(255),
								@dni numeric(18,0),
								@direccion nvarchar(255),
								@telefono nvarchar(255),
								@mail nvarchar(255),
								@fechaNacimiento datetime2(3)
								
								
as begin
begin try
	begin transaction
	declare @idUsuario int
	set @idUsuario = (select id from Usuario where nombre = 'cliente')
	insert into Cliente (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario)
		values (@nombre, @apellido, @dni, @direccion, @telefono, @mail, @fechaNacimiento, @idUsuario)

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del cliente', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[altaCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[altaCrucero] 
								@nombre nvarchar(255), 
								@modelo nvarchar(255), 
								@id_marca int, 
								@fechaAlta datetime2(3),
								@cabinas dbo.cabinas READONLY
								
as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction

	declare @idCrucero int 

	insert into Crucero (nombre, modelo, id_marca, fecha_alta)
		values (@nombre, @modelo, @id_marca, @fechaAlta)
	
	set @idCrucero = SCOPE_IDENTITY()

	insert into Cabina (id_crucero, nro, piso, ocupada, id_servicio)
		select @idCrucero, nro, piso, 0, id_servicio
			from @cabinas
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del crucero', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[altaPasaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[altaPasaje] 
								@idCliente int,
								@idViaje int,
								@idCabina int,
								@fecha datetime2(3),
								@idMedioPago int,
								@codigo int OUTPUT 
								
								
as begin
begin try
	begin transaction
	
	insert into Pasaje (id_cliente, fecha, id_viaje, id_cabina, id_medio_pago, precio)
		values (@idCliente, @fecha, @idViaje, @idCabina, @idMedioPago, dbo.precioViaje(@idViaje, @idCabina))

	set @codigo = SCOPE_IDENTITY()

	insert into Estado_pasaje (nombre, observacion, id_pasaje)
		values ('pagado', null, SCOPE_IDENTITY())
	
	return
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del pasaje', 12,1)
	rollback
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[altaRecorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[altaRecorrido] @codigo int,
						@puertos dbo.tramo readonly

as begin
begin try
	begin transaction

	declare @idRecorrido int
	
	if((select count(*) from @puertos) < 1)
	begin 
	raiserror('Debe seleccionar como minimo dos puertos', 12,1)
	end

	insert into Recorrido (codigo, inicio, inhabilitado, destino) 
		values (
			@codigo, 
			(select top 1 inicio from @puertos order by indice asc)
			, 
			0, 
			(select top 1 destino from @puertos order by indice desc)
			)

	set @idRecorrido = (select SCOPE_IDENTITY()) 

	insert into Puerto_recorrido (id_puerto_origen, id_puerto_destino, precio, id_recorrido) 
		select inicio, destino, precio,@idRecorrido
		from @puertos
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cargar el recorrido', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[altaRol]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[altaRol] @nombre nvarchar(255), @ids dbo.ids READONLY
as begin

begin try
	begin transaction

	insert into Rol	(nombre) values (@nombre)
	declare @idRol int
	set @idRol =  SCOPE_IDENTITY()
	exec recargarFuncionalidades @idRol, @ids

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cargar el rol', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[altaTarjeta]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[altaTarjeta] 
								@nroTarjeta int,
								@codigoDeguridad int,
								@cantCuotas int
															
as begin
begin try
	begin transaction
	
	insert into Tarjeta_credito(nro_tarjeta, codigo_seguridad)
		values (@nroTarjeta, @codigoDeguridad)

	insert into Medio_pago (nro_tarjeta, cant_cuotas, nombre)
		values (@nroTarjeta, @cantCuotas, 'tarjeta credito')

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta de la tarjeta', 12,1)
	rollback
end catch
end
GO
/****** Object:  StoredProcedure [dbo].[altaViaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[altaViaje] 
								@idCrucero int, 
								@idRecorrido int, 
								@fechaInicio datetime2(3),
								@fechaFin datetime2(3)
								
as begin
begin try
	begin transaction

	insert into Viaje (id_recorrido, id_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada)
		values (@idRecorrido, @idCrucero, @fechaInicio, @fechaFin, @fechaFin)

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del viaje', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[cancelarPasajesDeCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[cancelarPasajesDeCrucero] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2, @motivo nvarchar(255)
as begin
	if(@fechaFin is null)
	begin
		insert into Estado_pasaje (nombre, observacion, id_pasaje)
		select 'cancelado', @motivo, p.id
			from Pasaje p
			join Viaje v on p.id_viaje = v.id
			join Crucero c on c.id = v.id_crucero
			where v.fecha_inicio >=  @fechaInicio
	end
	else
	begin
		insert into Estado_pasaje (nombre, observacion, id_pasaje)
		select 'cancelado', @motivo, p.id
			from Pasaje p
			join Viaje v on p.id_viaje = v.id
			join Crucero c on c.id = v.id_crucero
			where v.fecha_inicio >=  @fechaInicio and v.fecha_inicio < @fechaFin
	end
	

end
GO
/****** Object:  StoredProcedure [dbo].[cancelarReservas]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[cancelarReservas] @fecha datetime2(3) 							
as begin
begin try
	begin transaction
	
	delete from Reserva
		where fecha < (DATEADD(day, -4, @fecha))

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cancelar las reservas', 12,1)
	rollback
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[cargarClientes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarClientes] AS
BEGIN
begin try
	begin transaction

	insert into Cliente (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario)
		select CLI_NOMBRE, 
				CLI_APELLIDO, 
				CLI_DNI, 
				CLI_DIRECCION, 
				CLI_TELEFONO,
				CLI_MAIL, 
				CLI_FECHA_NAC,
				(select id from Usuario where nombre = 'cliente')
				from GD1C2019.gd_esquema.Maestra
				group by 
				CLI_NOMBRE, 
				CLI_APELLIDO, 
				CLI_DNI, 
				CLI_DIRECCION, 
				CLI_TELEFONO,
				CLI_MAIL, 
				CLI_FECHA_NAC
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los clientes', 12,1)
	rollback
end catch
END



GO
/****** Object:  StoredProcedure [dbo].[cargarCrucerosYCabinas]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarCrucerosYCabinas]  AS
BEGIN
begin try
	begin transaction


	declare	@nombre NVARCHAR(50)
	declare	@modelo NVARCHAR(50)
	declare	@fabricante NVARCHAR(255)


	DECLARE cruceros CURSOR LOCAL FOR SELECT CRUCERO_IDENTIFICADOR, CRUCERO_MODELO, CRU_FABRICANTE 
										from GD1C2019.gd_esquema.Maestra 
										group by CRUCERO_IDENTIFICADOR, CRUCERO_MODELO, CRU_FABRICANTE
	declare @idEstado int
	declare @idCrucero int
	OPEN cruceros

	FETCH NEXT FROM cruceros INTO @nombre, @modelo, @fabricante

	WHILE @@fetch_status = 0
	BEGIN
		insert into Crucero (nombre, modelo, id_marca, fecha_alta)
			values (	
				@nombre, 
				@modelo, 
				(select id from Marca_Crucero where nombre = @fabricante),
				null
				)
		set @idCrucero = SCOPE_IDENTITY()
		
		insert into Estado_crucero (id_tipo, fecha_inicio, fecha_fin, id_crucero)
			values (
				(select id from Tipo_estado_crucero where nombre = 'En funcionamiento'),
				(select getdate()),
				null, 
				@idCrucero
				)
		insert into Cabina (id_crucero, id_servicio, nro, piso)
			select 
				@idCrucero,
				(select id from Servicio where nombre = CABINA_TIPO),
				CABINA_NRO,
				CABINA_PISO
				from GD1C2019.gd_esquema.Maestra
				where CRUCERO_IDENTIFICADOR = @nombre
				group by CABINA_NRO, CABINA_PISO, CABINA_TIPO
	

    FETCH NEXT FROM cruceros INTO @nombre, @modelo, @fabricante
	END

	CLOSE cruceros

	DEALLOCATE cruceros


	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los cruceros', 12,1)
	rollback
end catch
END





GO
/****** Object:  StoredProcedure [dbo].[cargarEstadosCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[cargarEstadosCrucero]  AS
BEGIN
begin try
	begin transaction

	
	insert into Tipo_estado_crucero (nombre)
		values ('Fuera de servicio'), ('Fin de vida util'), ('En funcionamiento')
 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los estados del crucero', 12,1)
	rollback
end catch
END



GO
/****** Object:  StoredProcedure [dbo].[CargarEstadosPasaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CargarEstadosPasaje] AS
BEGIN
begin try
	begin transaction
	insert into Estado_pasaje (nombre, observacion, id_pasaje)
		 select 'pagado', null, id
		 from Pasaje 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los estados del pasaje', 12,1)
	rollback
end catch
END


GO
/****** Object:  StoredProcedure [dbo].[cargarFuncionalidades]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarFuncionalidades]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	insert into Funcionalidad (nombre)
		values ('abm_puerto'),( 'abm_recorrido'),( 'abm_crucero'),( 'generar_viaje'), ('reservar_viaje'), ('pagar_reserva'), ('listado_estadistico')
END



GO
/****** Object:  StoredProcedure [dbo].[cargarMarcasCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[cargarMarcasCrucero]  AS
BEGIN
begin try
	begin transaction

	
	insert into Marca_Crucero (nombre)
		select CRU_FABRICANTE 
		from GD1C2019.gd_esquema.Maestra
		group by CRU_FABRICANTE
 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar las marcas del crucero', 12,1)
	rollback
end catch
END



GO
/****** Object:  StoredProcedure [dbo].[cargarMediosDePago]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[cargarMediosDePago]  AS
BEGIN
begin try
	begin transaction
	
	insert into Medio_pago (nombre, cant_cuotas, nro_tarjeta)
		values ('efectivo', 1, null)
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los medios de pago', 12,1)
	rollback
end catch
END

/*declare @idEstado int
	set @idEstado = (select id from Estado_pasaje where nombre = 'Reservado')*/


GO
/****** Object:  StoredProcedure [dbo].[cargarPasajesYReservas]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarPasajesYReservas]  AS
BEGIN
begin try
	begin transaction
			
	CREATE TABLE pasaje_aux (
						rec_codigo int, 
						rec_inicio nvarchar(255), 
						rec_destino nvarchar(255), 
						rec_id_inicio int, 
						rec_id_destino int, 
						via_id int, 
						via_fecha_inicio datetime2(3), 
						via_fecha_fin datetime2(3), 
						via_fecha_fin_estimada datetime2(3), 
						cru_nombre nvarchar(255), 
						cru_id int, 
						cab_piso int, 
						cab_nro int, 
						cab_id int, 
						precio decimal(18,2)
						);

	insert into pasaje_aux(
						rec_codigo, 
						rec_id_inicio, 
						rec_id_destino,
						rec_inicio, 
						rec_destino, 
						via_id, 
						via_fecha_inicio, 
						via_fecha_fin, 
						via_fecha_fin_estimada, 
						cru_nombre, 
						cru_id , 
						cab_piso, 
						cab_nro, 
						cab_id, 
						precio
						)
		select rec.codigo, 
				rec.inicio, 
				rec.destino,
				pue_inicio.nombre,
				pue_destino.nombre,
				via.id, 
				via.fecha_inicio, 
				via.fecha_fin, 
				via.fecha_fin_estimada, 
				cru.nombre, 
				cru.id , 
				cab.piso, 
				cab.nro, 
				cab.id, 
				(pr.precio * srv.porc_aumento)
			from Recorrido rec
			join Puerto_recorrido pr on pr.id_recorrido = rec.id
			join Viaje via on via.id_recorrido = rec.id
			join Puerto pue_inicio on pue_inicio.id = rec.inicio
			join Puerto pue_destino on pue_destino.id = rec.destino 
			join Crucero cru on via.id_crucero = cru.id
			join Cabina cab on cab.id_crucero = cru.id
			join Servicio srv on srv.id = cab.id_servicio
			group by rec.codigo,
						rec.inicio, 
						rec.destino,
						pue_inicio.nombre,
						pue_destino.nombre, 
						via.id, 
						via.id_crucero, 
						via.fecha_inicio, 
						via.fecha_fin, 
						via.fecha_fin_estimada, 
						cab.id, 
						cru.nombre, 
						cab.nro, 
						cab.piso, 
						cru.id, 
						pr.precio, 
						srv.porc_aumento

	
	insert into Pasaje (id_cliente, id_medio_pago, fecha, id_cabina, id_viaje, codigo, precio)
		select 
			cli.id,
			null,
			g.PASAJE_FECHA_COMPRA,
			p.cab_id,
			p.via_id,
			PASAJE_CODIGO,
			p.precio
		from GD1C2019.gd_esquema.Maestra g
		join Cliente cli on cli.apellido = CLI_APELLIDO and cli.nombre = CLI_NOMBRE and cli.dni = CLI_DNI 
		join pasaje_aux p on
			p.cab_nro = g.CABINA_NRO and
			p.cab_piso = g.CABINA_PISO and
			p.cru_nombre = g.CRUCERO_IDENTIFICADOR and
			p.rec_codigo = g.RECORRIDO_CODIGO and
			p.rec_destino = g.PUERTO_HASTA and
			p.rec_inicio = g.PUERTO_DESDE and
			p.via_fecha_fin = g.FECHA_LLEGADA and
			p.via_fecha_inicio = g.FECHA_SALIDA and
			p.via_fecha_fin_estimada = g.FECHA_LLEGADA_ESTIMADA and
			p.cru_nombre = g.CRUCERO_IDENTIFICADOR
		where g.PASAJE_CODIGO is not null

	insert into Reserva (id_cliente, fecha, codigo, id_viaje, id_cabina)
	select 
			cli.id,
			g.RESERVA_FECHA,
			g.RESERVA_CODIGO,
			p.via_id,
			p.cab_id
		from GD1C2019.gd_esquema.Maestra g
		join Cliente cli on cli.apellido = CLI_APELLIDO and cli.nombre = CLI_NOMBRE and cli.dni = CLI_DNI 
		join pasaje_aux p on
			p.cab_nro = g.CABINA_NRO and
			p.cab_piso = g.CABINA_PISO and
			p.cru_nombre = g.CRUCERO_IDENTIFICADOR and
			p.rec_codigo = g.RECORRIDO_CODIGO and
			p.rec_destino = g.PUERTO_HASTA and
			p.rec_inicio = g.PUERTO_DESDE and
			p.via_fecha_fin = g.FECHA_LLEGADA and
			p.via_fecha_inicio = g.FECHA_SALIDA and
			p.via_fecha_fin_estimada = g.FECHA_LLEGADA_ESTIMADA and
			p.cru_nombre = g.CRUCERO_IDENTIFICADOR
		where g.PASAJE_CODIGO is null

	drop table pasaje_aux
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los pasajes', 12,1)
	rollback
end catch
END


GO
/****** Object:  StoredProcedure [dbo].[cargarPuertoRecorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarPuertoRecorrido]  AS
BEGIN
begin try
	begin transaction

	insert into Puerto_recorrido (id_puerto_origen, id_puerto_destino, id_recorrido, precio) 
		select r.inicio, r.destino, r.id, RECORRIDO_PRECIO_BASE
		from Recorrido r
		join Puerto as p1 on r.inicio = p1.id
		join Puerto as p2 on r.destino = p2.id
		join GD1C2019.gd_esquema.Maestra
			on RECORRIDO_CODIGO = r.codigo and p1.nombre = PUERTO_DESDE and p2.nombre = PUERTO_HASTA
			group by r.inicio, r.destino, r.id, RECORRIDO_PRECIO_BASE

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los recorridos', 12,1)
	rollback
end catch
END




GO
/****** Object:  StoredProcedure [dbo].[CargarPuertos]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CargarPuertos]  AS
BEGIN
begin try
	begin transaction

	insert into Puerto (nombre) 
	select PUERTO_DESDE as puerto from GD1C2019.gd_esquema.Maestra 
		group by PUERTO_DESDE
	union 
	select PUERTO_HASTA as puerto from GD1C2019.gd_esquema.Maestra 
		group by PUERTO_HASTA




	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los puertos', 12,1)
	rollback
end catch
END


GO
/****** Object:  StoredProcedure [dbo].[cargarRecorridos]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarRecorridos]  AS
BEGIN
begin try
	begin transaction

	insert into Recorrido (codigo, inicio, destino, inhabilitado) 
		select RECORRIDO_CODIGO, p1.id, p2.id, null
		from GD1C2019.gd_esquema.Maestra
		join Puerto as p1 on PUERTO_DESDE = p1.nombre 
		join Puerto as p2 on PUERTO_HASTA = p2.nombre
		group by RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA, p1.nombre, p1.id, p2.nombre, p2.id

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los recorridos', 12,1)
	rollback
end catch
END





GO
/****** Object:  StoredProcedure [dbo].[cargarRoles]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarRoles]
AS
BEGIN
	insert into Rol (nombre, inhabilitado)
		values ('administrador', null) , ('cliente', null)

END



GO
/****** Object:  StoredProcedure [dbo].[cargarServiciosCabina]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
create PROCEDURE [dbo].[cargarServiciosCabina]  AS
BEGIN
begin try
	begin transaction

	
	insert into Servicio (nombre, porc_aumento)
		select CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
		from GD1C2019.gd_esquema.Maestra
		group by CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los servicios de cabina', 12,1)
	rollback
end catch
END



GO
/****** Object:  StoredProcedure [dbo].[cargarUsuarios]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[cargarUsuarios]
as begin

begin try
	begin transaction

	insert into Funcionalidad (nombre) 
		values ('abm_rol') , 
				('abm_recorrido'), 
				('abm_crucero'),
				('generar_viaje'),
				('reservar_viaje'),
				('pago_reserva'),
				('listado_estadistico')

	insert into Rol (nombre, inhabilitado)
		values ('admin', 0), ('cliente', 0)

	insert into Rol_funcionalidad (id_rol, id_funcionalidad)
		select 
			(select r.id from Rol r where nombre = 'admin'),
			id
			from Funcionalidad 
	
	insert into Rol_funcionalidad (id_rol, id_funcionalidad)
		values ( 
			(select r.id from Rol r where nombre = 'cliente'), 
			(select f.id from Funcionalidad f where nombre = 'reservar_viaje')
		),
		( 
			(select r.id from Rol r where nombre = 'cliente'), 
			(select f.id from Funcionalidad f where nombre = 'pago_reserva')
		)


	insert into Usuario (password, nombre, cant_intentos_fallido,  inhabilitado)
		values(
			HASHBYTES('SHA2_256', cast('w23e' as nvarchar(255))),
			cast('admin' as nvarchar(255)),
			0,
			0
		)
	
	insert into Usuario (password, nombre, cant_intentos_fallido,  inhabilitado)
		values
		(
			HASHBYTES('SHA2_256', cast('cliente' as nvarchar(255))),
			cast('cliente' as nvarchar(255)),
			0,
			0
		)

	insert into Usuario_rol (id_rol, id_usuario)
		select (select r.id from Rol r where nombre = 'admin'),
				id from Usuario where nombre = 'admin'

	insert into Usuario_rol (id_rol, id_usuario)
		select (select r.id from Rol r where nombre = 'cliente'),
				id from Usuario where nombre = 'cliente'

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los USUARIOS', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure [dbo].[cargarViajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarViajes]  AS
BEGIN
begin try
	begin transaction

	insert into Viaje ( id_recorrido, id_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada/*, cant_cabinas_libres*/ ) 
		select r.id, 
				cru1.id,
				g1.FECHA_SALIDA, 
				g1.FECHA_LLEGADA, 
				g1.FECHA_LLEGADA_ESTIMADA/*, 
				(
					(
					select count(*) 
						from Cabina cab 
						join Crucero cru2 on cab.id_crucero = cru2.id 
						where cru1.id = cru2.id
					)
					-
					(
					select count(*) 

					)
				)*/
		from Recorrido r
		join Puerto as p1 on r.inicio = p1.id
		join Puerto as p2 on r.destino = p2.id
		join GD1C2019.gd_esquema.Maestra g1
			on RECORRIDO_CODIGO = r.codigo and p1.nombre = PUERTO_DESDE and p2.nombre = PUERTO_HASTA
		join Crucero cru1 on CRUCERO_IDENTIFICADOR = cru1.nombre 
		where PASAJE_CODIGO is not null
		group by r.id, 
				cru1.id, 
				g1.FECHA_SALIDA, 
				g1.FECHA_LLEGADA, 
				g1.FECHA_LLEGADA_ESTIMADA,
				g1.RECORRIDO_CODIGO, 
				g1.PUERTO_DESDE, 
				g1.PUERTO_HASTA, 
				g1.CRUCERO_IDENTIFICADOR, 
				cru1.nombre
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los viajes', 12,1)
	rollback
end catch
END




GO
/****** Object:  StoredProcedure [dbo].[completarVidaUtilCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[completarVidaUtilCrucero] @idCrucero int, @fecha datetime2(3)
as begin
declare @estadoFinVidaUtil int
		set @estadoFinVidaUtil = (select id from Tipo_estado_crucero where nombre = 'Fin de vida util')

		insert into Estado_crucero (id_tipo, id_crucero, fecha_inicio, fecha_fin)
			values (@estadoFinVidaUtil, @idCrucero, @fecha, null)
end
GO
/****** Object:  StoredProcedure [dbo].[completarVidaUtilCruceroYCancelarPasajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[completarVidaUtilCruceroYCancelarPasajes] @idCrucero int, @fecha datetime2(3), @motivo nvarchar(255)

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		
		exec completarVidaUtilCrucero @idCrucero, @fecha
		exec cancelarPasajesDeCrucero @idCrucero, @fecha, null, @motivo

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [completarVidaUtilCruceroYCancelarPasajes]', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[completarVidaUtilCruceroYReprogramarPasajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[completarVidaUtilCruceroYReprogramarPasajes] @idCrucero int, @fecha datetime2(3), @motivo nvarchar(255)

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		declare @fechaFin datetime2(3)
		set @fechaFin = (select top 1 fecha_fin from  Viaje where id_crucero = @idCrucero order by fecha_fin desc) 
		exec completarVidaUtilCrucero @idCrucero, @fecha
		exec reemplazarViajes @idCrucero, @fecha, @fechaFin
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [completarVidaUtilCruceroYReprogramarPasajes]', 12,1)
	rollback
end catch
end




GO
/****** Object:  StoredProcedure [dbo].[loginUser]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[loginUser] 
								@usuario nvarchar(255),
								@password nvarchar(255),
								@respuesta  nvarchar(255) output,
								@idUser int output
								
as begin
begin try

	set @idUser = 0 
	if(exists (select * from Usuario where nombre = @usuario))
	begin

		if((select cant_intentos_fallido from Usuario where nombre = @usuario) > 3)
		begin
			set @respuesta = 'maxima cantidad de intentos fallidos'
			return
		end

		if((select password from Usuario where nombre = @usuario) = HASHBYTES('SHA2_256', @password))
		begin
			set @respuesta = 'ok'
			set @idUser = (select id from Usuario where nombre = @usuario)
			update Usuario 
				set cant_intentos_fallido = 0
				where nombre = @usuario
		end
		else
		begin
			set @respuesta = 'password incorrecta'
			update Usuario 
				set cant_intentos_fallido = cant_intentos_fallido +1
				where nombre = @usuario
		end

	end
	else
	begin

		set @respuesta = 'usuario incorrecto'

	end

	return 
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el login', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[modificacionCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[modificacionCrucero] 
								@idCrucero int,
								@nombre nvarchar(255), 
								@modelo nvarchar(255), 
								@id_marca int,  
								@cabinas dbo.cabinas READONLY
as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction

	update Crucero 
		set nombre = @nombre,
			modelo = @modelo,
			id_marca = @id_marca

	delete from Cabina where id_crucero = @idCrucero

	insert into Cabina (id_crucero, nro, piso, ocupada, id_servicio)
		select @idCrucero, nro, piso, 0, id_servicio
			from @cabinas
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en la modificacion del crucero', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[modificacionRecorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[modificacionRecorrido] 
						@idRecorrido int,
						@codigo int,
						@inicio int, 
						@fin int, 
						@precio decimal(18, 2),
						@puertos dbo.ids readonly

as begin
begin try
	begin transaction


	
	if((select count(*) from @puertos) < 2)
	begin 
	raiserror('Debe seleccionar como minimo dos puertos', 12,1)
	end

	update Recorrido 
		set codigo = @codigo,
			inicio = @inicio,
			destino = @fin,
			precio = @precio

	delete from Puerto_recorrido where id_recorrido = @idRecorrido

	DECLARE puertos CURSOR LOCAL FOR SELECT id from @puertos
									
	declare @puertoOrigen int
	declare @puertoDestino int
	OPEN puertos

	FETCH NEXT FROM puertos INTO @puertoOrigen
	FETCH NEXT FROM puertos INTO @puertoDestino

	WHILE @@fetch_status = 0
	BEGIN
		
	
		insert into Puerto_recorrido (id_puerto_origen, id_recorrido, id_puerto_destino) values ( @puertoOrigen, @idRecorrido, @puertoDestino)

		set @puertoOrigen = @puertoDestino
	

    FETCH NEXT FROM puertos INTO @puertoDestino
	END

	CLOSE puertos

	DEALLOCATE puertos



	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al modificar el recorrido', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure [dbo].[modificacionRol]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[modificacionRol] @idRol int, @nombre nvarchar(255), @ids dbo.ids READONLY
as begin

begin try
	begin transaction

	update Rol set nombre = @nombre where id = @idRol
	exec recargarFuncionalidades @idRol, @ids

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cargar el rol', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[pagarReserva]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[pagarReserva] 
								@idReserva int,
								@idMedioPago int,
								@fecha datetime2(3),
								@codigo int OUTPUT
								
								
as begin
begin try
	begin transaction
	declare @idCliente int
	declare @idCabina int
	declare @idViaje int

	set @idCliente = (select id_cliente from Reserva where id = @idReserva)
	set @idCabina = (select id_cabina from Reserva where id = @idReserva)
	set @idViaje = (select id_viaje from Reserva where id = @idReserva)

	exec altaPasaje @idCliente,@idViaje, @idCabina, @fecha, @idMedioPago, @codigo
	return 
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el pago de la reserva', 12,1)
	rollback
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[ponerEnFueraDeServicioCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ponerEnFueraDeServicioCrucero] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3)
as begin
declare @estadoFueraDeServicio int
		set @estadoFueraDeServicio = (select id from Tipo_estado_crucero where nombre = 'Fuera de servicio')

		insert into Estado_crucero (id_tipo, id_crucero, fecha_inicio, fecha_fin)
			values (@estadoFueraDeServicio, @idCrucero, @fechaInicio, @fechaFin)
end
GO
/****** Object:  StoredProcedure [dbo].[ponerEnFueraDeServicioCruceroYCancelarPasajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ponerEnFueraDeServicioCruceroYCancelarPasajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3), @motivo nvarchar(255)

as begin
begin try
	begin transaction
		
		exec ponerEnFueraDeServicioCrucero @idCrucero, @fechaInicio, @fechaFin
		exec cancelarPasajesDeCrucero @idCrucero, @fechaInicio, @fechaFin, @motivo

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en la modificacion del crucero', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[ponerEnFueraDeServicioCruceroYReprogramarPasajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ponerEnFueraDeServicioCruceroYReprogramarPasajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3)

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		
		exec ponerEnFueraDeServicioCrucero @idCrucero, @fechaInicio, @fechaFin
		exec reemplazarViajes @idCrucero, @fechaInicio, @fechaFin

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [ponerEnFueraDeServicioCruceroYReprogramarPasajes]', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[postergarViajesDeCrucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[postergarViajesDeCrucero] 
								@idCrucero int, 
								@cantDias int
								
as begin
begin try
	begin transaction

	update Viaje 
		set fecha_inicio = dateadd(day, @cantDias, fecha_inicio),
			fecha_fin = dateadd(day, @cantDias, fecha_fin),
			fecha_fin_estimada = dateadd(day, @cantDias, fecha_fin_estimada)
		where id_crucero = @idCrucero

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al postergar los viajes', 12,1)
	rollback
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[recargarFuncionalidades]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[recargarFuncionalidades] @idRol int, @ids dbo.ids READONLY
as begin

begin try
	begin transaction
	delete from Rol_funcionalidad where id_rol = @idRol
	insert into Rol_funcionalidad(id_rol, id_funcionalidad) select @idRol, id from @ids

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar funcionalidades', 12,1)
	rollback
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[reemplazarViajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[reemplazarViajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3)
as begin
	if( dbo.cruceroReemplazante(@idCrucero, @fechaInicio, @fechaFin) <> -1 )
		begin
			update Viaje
				set id_crucero = dbo.cruceroReemplazante(@idCrucero, @fechaInicio, @fechaFin)
		end
		else
		begin
			raiserror('No existe ningun reemplazo para el crucero', 12, 1)
		end
end 
GO
/****** Object:  StoredProcedure [dbo].[reiniciarBase]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reiniciarBase]
AS
BEGIN

begin transaction t1
begin try

disable trigger inhabilitarRol on Rol;
disable trigger inhabilitarUsuario on Usuario;
disable trigger inhabilitarRecorrido on Recorrido

delete from Estado_pasaje
delete from Pasaje
delete from Reserva
delete from Cliente
delete from Usuario_rol
delete from Rol_funcionalidad
delete from Funcionalidad
delete from Usuario
delete from Rol
delete from Estado_crucero
delete from Cabina
delete from Servicio
delete from Viaje
delete from Crucero
delete from Tipo_estado_crucero
delete from Marca_Crucero
delete from Servicio
delete from Puerto_recorrido
delete from Recorrido
delete from Puerto;

enable trigger inhabilitarRol on Rol;
enable trigger inhabilitarUsuario on Usuario;
enable trigger inhabilitarRecorrido on Recorrido

commit transaction t1
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al eliminar', 12,1)
	rollback transaction t1
end catch

begin transaction t2
begin try

exec cargarUsuarios
exec cargarClientes
exec cargarEstadosCrucero
exec cargarMarcasCrucero
exec cargarServiciosCabina
exec cargarCrucerosYCabinas
exec cargarPuertos
exec cargarRecorridos
exec cargarPuertoRecorrido
exec cargarViajes
exec cargarMediosDePago
exec cargarPasajesYReservas
exec cargarEstadosPasaje

commit transaction t2
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar', 12,1)
	rollback transaction t2
end catch

END


GO
/****** Object:  StoredProcedure [dbo].[reservarViaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[reservarViaje] 
								@idCliente int,
								@idViaje int,
								@idCabina int,
								@fecha datetime2(3),
								@codigo int OUTPUT 
								
								
as begin
begin try
	begin transaction
	
	insert into Reserva (id_cliente, fecha, id_viaje, id_cabina)
		values (@idCliente, @fecha, @idViaje, @idCabina)

	set @codigo = SCOPE_IDENTITY()
	return
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta de la reserva', 12,1)
	rollback
end catch
end

GO
/****** Object:  UserDefinedFunction [dbo].[cabinasLibres]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[cabinasLibres] (@idViaje int)
returns @cabinas table (id int)
begin
insert into @cabinas select cab.id
			from Cabina cab
			join Crucero cru on cab.id_crucero = cru.id
			join Viaje via on via.id_crucero = cru.id
			where via.id = @idViaje and 
					cab.id not in (select id from Reserva res where res.id_viaje = @idViaje) and
					cab.id not in (select id from Pasaje  pas where pas.id_viaje = @idViaje)

			
	return
end
GO
/****** Object:  UserDefinedFunction [dbo].[cruceroDisponible]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE function [dbo].[cruceroDisponible](@idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3))
returns int
begin

	declare	@idViaje int
	declare @fechaInicioViaje1 datetime2(3)
	declare @fechaFinViaje1 datetime2(3)
	declare @fechaInicioViaje2 datetime2(3)
	declare @fechaFinViaje2 datetime2(3)
	declare @fechaInicioIntervalo datetime2(3)
	declare @fechaFinIntervalo datetime2(3)

	declare @cruceroEstaDisponible bit
	set @cruceroEstaDisponible = 0

	if(@idCrucero in (
		(select id from dbo.crucerosFueraDeServicio(@fechaInicio)) 
		union 
		(select id from dbo.crucerosFinVidaUtil(@fechaInicio)) 
		)
	)
	begin
		return 0
	end 

	DECLARE fechasOcupadasCrucero CURSOR LOCAL FOR SELECT  via.fecha_inicio, fecha_fin
										from Viaje via
										join Crucero c on via.id_crucero = c.id
										where id_crucero = @idCrucero
										and fecha_fin >= @fechaInicio and fecha_inicio <= @fechaFin
										order by fecha_inicio

					open fechasOcupadasCrucero

					fetch next from fechasOcupadasCrucero into @fechaInicioViaje1, @fechaFinViaje1
					fetch next from fechasOcupadasCrucero into @fechaInicioViaje2, @fechaFinViaje2
					
					if(@@FETCH_STATUS <> 0 ) /*Si el crucero solo tiene 1 viaje */
					begin
						set @fechaInicioIntervalo = @fechaFinViaje1
						if( @fechaInicio > @fechaInicioIntervalo)
							begin
								set @cruceroEstaDisponible = 1
							end
					end
						
						while @@FETCH_STATUS = 0
						begin

							set @fechaInicioIntervalo = @fechaFinViaje1
							set @fechaFinIntervalo = @fechaInicioViaje2

							if( @fechaInicio > @fechaInicioIntervalo and @fechaFin < @fechaFinintervalo)
							begin
								set @cruceroEstaDisponible = 1
								break
							end
							
							set @fechaInicioViaje1 = @fechaInicioViaje2
							set @fechaFinViaje1 = @fechaFinViaje2
							fetch next from fechasOcupadasCrucero into @fechaInicioViaje2, @fechaFinViaje2
							if(@@FETCH_STATUS <> 0 )
							begin
								set @fechaInicioIntervalo = @fechaFinViaje1
								if( @fechaInicio > @fechaInicioIntervalo)
								begin
									set @cruceroEstaDisponible = 1
									break
								end
							end
						end

					close fechasOcupadasCrucero
					deallocate fechasOcupadasCrucero

	return @cruceroEstaDisponible
end
GO
/****** Object:  UserDefinedFunction [dbo].[cruceroReemplazante]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[cruceroReemplazante] (@idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3))
returns int
as begin

	declare	@idViaje int
	declare @fechaInicioViajeAReemplazar datetime2(3)
	declare @fechaFinViajeAReemplazar datetime2(3)
	declare @fechaInicioViaje1 datetime2(3)
	declare @fechaFinViaje1 datetime2(3)
	declare @fechaInicioViaje2 datetime2(3)
	declare @fechaFinViaje2 datetime2(3)
	declare @fechaInicioIntervalo datetime2(3)
	declare @fechaFinIntervalo datetime2(3)
	declare @idPosibleCrucero int
	declare @cruceroPuedeSerReemplazante bit
	set @idPosibleCrucero = -1

	DECLARE viajesAReemplazar CURSOR LOCAL FOR SELECT fecha_inicio, fecha_fin
										from Viaje
										where id_crucero = @idCrucero
										and fecha_inicio >= @fechaInicio and fecha_fin <= @fechaFin
										order by fecha_inicio
	
	declare cruceros cursor local for select id 
										from Crucero 
										where id not in (
						select est.id_crucero
						from Estado_crucero est 
						join Tipo_estado_crucero tip on tip.id = est.id_tipo
						where tip.nombre = 'Fuera de servicio'
					)

	OPEN cruceros
	open viajes

	FETCH NEXT FROM cruceros INTO @idPosibleCrucero
	set @cruceroPuedeSerReemplazante = 0

	WHILE @@fetch_status = 0
	BEGIN

		FETCH NEXT FROM viajesAReemplazar INTO @fechaInicioViajeAReemplazar, @fechaFinViajeAReemplazar
			WHILE @@fetch_status = 0
			BEGIN

				if(dbo.cruceroDisponible(@idPosibleCrucero, @fechaInicioViajeAReemplazar, @fechaFinViajeAReemplazar) = 0)
				begin
					set @cruceroPuedeSerReemplazante = 0
					break
				end

			FETCH NEXT FROM viajes INTO @idViaje
		end

		if(@cruceroPuedeSerReemplazante = 1)
			begin
				break;
			end
		else
		begin
			FETCH NEXT FROM cruceros INTO @idPosibleCrucero
			
		end
	END

	CLOSE cruceros
	DEALLOCATE cruceros
	CLOSE viajes
	DEALLOCATE viajes

	return @idPosibleCrucero
end



GO
/****** Object:  UserDefinedFunction [dbo].[precioViaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[precioViaje] (@idViaje int, @idCabina int)
returns numeric(18,2)
begin
	declare @precioBase numeric(18,0)
	set @precioBase = ( select sum(pr.precio)
						 from Viaje via
						join Puerto_recorrido pr on pr.id_recorrido = via.id_recorrido)
	return @precioBase * (select porc_aumento 
							from Servicio s join Cabina c on s.id = c.id_servicio 
							where c.id = @idCabina )
end
GO
/****** Object:  Table [dbo].[Cabina]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabina](
	[id_crucero] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[nro] [decimal](18, 0) NOT NULL,
	[piso] [decimal](18, 0) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cabina_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[dni] [decimal](18, 0) NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [nvarchar](255) NOT NULL,
	[mail] [nvarchar](255) NULL,
	[fecha_nacimiento] [datetime2](3) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Crucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crucero](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[modelo] [nvarchar](50) NOT NULL,
	[id_marca] [int] NOT NULL,
	[fecha_alta] [datetime2](3) NULL,
 CONSTRAINT [PK_Crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado_crucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_crucero](
	[id_tipo] [int] NOT NULL,
	[fecha_inicio] [datetime2](3) NOT NULL,
	[fecha_fin] [datetime2](3) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_crucero] [int] NOT NULL,
 CONSTRAINT [PK_Estado_crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado_pasaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_pasaje](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[observacion] [nvarchar](255) NULL,
	[id_pasaje] [int] NOT NULL,
 CONSTRAINT [PK_Estado_pasaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionalidad](
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marca_Crucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca_Crucero](
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Marca_Crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Medio_pago]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medio_pago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[cant_cuotas] [decimal](18, 0) NULL,
	[nro_tarjeta] [int] NULL,
 CONSTRAINT [PK_Medio_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pasaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasaje](
	[id_cliente] [int] NOT NULL,
	[id_medio_pago] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime2](3) NOT NULL,
	[id_cabina] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[id_viaje] [int] NOT NULL,
	[codigo] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Puerto]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puerto](
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Puerto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Puerto_recorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puerto_recorrido](
	[id_puerto_origen] [int] NOT NULL,
	[id_puerto_destino] [int] NOT NULL,
	[id_recorrido] [int] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recorrido](
	[codigo] [int] NOT NULL,
	[inicio] [int] NOT NULL,
	[destino] [int] NOT NULL,
	[inhabilitado] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Recorrido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[id_cliente] [int] NOT NULL,
	[fecha] [datetime2](3) NOT NULL,
	[codigo] [decimal](18, 0) NOT NULL,
	[id_viaje] [int] NOT NULL,
	[id_cabina] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[nombre] [nvarchar](255) NOT NULL,
	[inhabilitado] [bit] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol_funcionalidad]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_funcionalidad](
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[nombre] [nvarchar](255) NOT NULL,
	[porc_aumento] [decimal](18, 2) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tarjeta_credito]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta_credito](
	[nro_tarjeta] [int] NOT NULL,
	[codigo_seguridad] [decimal](3, 0) NOT NULL,
 CONSTRAINT [PK_Tarjeta_credito] PRIMARY KEY CLUSTERED 
(
	[nro_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipo_estado_crucero]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_estado_crucero](
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Tipo_estado_crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[nombre] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[cant_intentos_fallido] [numeric](18, 0) NOT NULL,
	[inhabilitado] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario_rol]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_rol](
	[id_rol] [int] NOT NULL,
	[id_usuario] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viaje](
	[id_recorrido] [int] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[fecha_inicio] [datetime2](3) NOT NULL,
	[fecha_fin] [datetime2](3) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_fin_estimada] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[crucerosConMasDiasFueraDeServicio]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[crucerosConMasDiasFueraDeServicio] (@desde datetime2(3), @hasta datetime2(3))
returns table
as
	return 
		select top 5 cru.nombre nombre, sum (
												DATEDIFF(
												day,
												case when (est.fecha_inicio > @desde) then est.fecha_inicio else @desde end,
												case when (est.fecha_fin < @hasta) then est.fecha_inicio else @hasta end
												)
											) cantidad
		from Crucero cru
		join Estado_crucero est on est.id_crucero = cru.id
		join Tipo_estado_crucero tip on tip.id = est.id_tipo 
		where tip.nombre = 'Fuera de servicio' and
			(est.fecha_inicio >= @desde or (est.fecha_inicio <= @desde and est.fecha_fin >= @desde)) and
			(est.fecha_fin <= @hasta or (est.fecha_inicio <= @hasta and est.fecha_fin >= @hasta))
		group by cru.nombre
		order by sum (
						DATEDIFF(
							day,
							case when (est.fecha_inicio > @desde) then est.fecha_inicio else @desde end,
							case when (est.fecha_fin < @hasta) then est.fecha_inicio else @hasta end
						)
					) desc

GO
/****** Object:  UserDefinedFunction [dbo].[crucerosDisponibles]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[crucerosDisponibles] (@fechaInicio datetime2(3), @fechaFin datetime2(3))
returns table
as return (select id 
		from Crucero cru 
		where dbo.cruceroDisponible(id, @fechaInicio, @fechaFin) = 1
				)


GO
/****** Object:  UserDefinedFunction [dbo].[crucerosFinVidaUtil]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[crucerosFinVidaUtil] (@fecha datetime2(3))
returns table
return select est.id_crucero id
						from Estado_crucero est 
						join Tipo_estado_crucero tip on tip.id = est.id_tipo
						where tip.nombre = 'Fin de vida util' and est.fecha_inicio <= @fecha
GO
/****** Object:  UserDefinedFunction [dbo].[crucerosFueraDeServicio]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[crucerosFueraDeServicio] (@fecha datetime2(3))
returns table
return select est.id_crucero id
						from Estado_crucero est 
						join Tipo_estado_crucero tip on tip.id = est.id_tipo
						where tip.nombre = 'Fuera de servicio' and (est.fecha_inicio <= @fecha or est.fecha_fin >= @fecha) 
GO
/****** Object:  UserDefinedFunction [dbo].[recorridosConMasCabinasLibres]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[recorridosConMasCabinasLibres] (@desde datetime2(3), @hasta datetime2(3))
returns table
as
	return 
		select top 5 puerto_desde.nombre inicio, 
				puerto_hasta.nombre destino, 
				(select count(*) 
					from Viaje via2 
					join Recorrido rec2 on via2.id_recorrido = rec2.id
					join Crucero cru on via2.id_crucero = cru.id 
					join Cabina cab on cab.id_crucero = cru.id
					where rec2.id = rec.id and via2.fecha_inicio >= @desde and via2.fecha_fin <= @hasta
				) - count(*)  cantidad
		from Pasaje pas
		join Viaje via on via.id = pas.id_viaje
		join Recorrido rec on via.id_recorrido = rec.id
		join Puerto as puerto_desde on puerto_desde.id = rec.inicio
		join Puerto as puerto_hasta on puerto_hasta.id = rec.destino
		where via.fecha_inicio >= @desde and via.fecha_fin <= @hasta
		group by rec.id,  puerto_desde.nombre, puerto_hasta.nombre
		order by (select count(*) 
					from Viaje via2 
					join Recorrido rec2 on via2.id_recorrido = rec2.id
					join Crucero cru on via2.id_crucero = cru.id 
					join Cabina cab on cab.id_crucero = cru.id
					where rec2.id = rec.id and via2.fecha_inicio >= @desde and via2.fecha_fin <= @hasta
				) - count(*)
				desc

GO
/****** Object:  UserDefinedFunction [dbo].[recorridosConMasPasajes]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[recorridosConMasPasajes] (@desde datetime2(3), @hasta datetime2(3))
returns table
as
	return 
		select top 5 puerto_desde.nombre inicio, puerto_hasta.nombre destino, count(*) cantidad
		from Pasaje pas
		join Viaje via on via.id = pas.id_viaje
		join Recorrido rec on via.id_recorrido = rec.id
		join Puerto as puerto_desde on puerto_desde.id = rec.inicio
		join Puerto as puerto_hasta on puerto_hasta.id = rec.destino
		where via.fecha_inicio >= @desde and via.fecha_fin <= @hasta
		group by rec.id,  puerto_desde.nombre, puerto_hasta.nombre
		order by count(*) desc

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Crucero]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Crucero] ON [dbo].[Crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Funcionalidad]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Funcionalidad] ON [dbo].[Funcionalidad]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Marca_Crucero]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Marca_Crucero] ON [dbo].[Marca_Crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Puerto]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Puerto] ON [dbo].[Puerto]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_rol]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Nombre_unique_rol] ON [dbo].[Rol]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Servicio]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Servicio] ON [dbo].[Servicio]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tipo_estado_crucero]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tipo_estado_crucero] ON [dbo].[Tipo_estado_crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_usuario]    Script Date: 05/06/2019 15:34:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Nombre_unique_usuario] ON [dbo].[Usuario]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cabina]  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Crucero] FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Crucero] ([id])
GO
ALTER TABLE [dbo].[Cabina] CHECK CONSTRAINT [FK_Cabina_Crucero]
GO
ALTER TABLE [dbo].[Cabina]  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Servicio] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[Servicio] ([id])
GO
ALTER TABLE [dbo].[Cabina] CHECK CONSTRAINT [FK_Cabina_Servicio]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Crucero]  WITH CHECK ADD  CONSTRAINT [FK_Crucero_Marca_Crucero] FOREIGN KEY([id_marca])
REFERENCES [dbo].[Marca_Crucero] ([id])
GO
ALTER TABLE [dbo].[Crucero] CHECK CONSTRAINT [FK_Crucero_Marca_Crucero]
GO
ALTER TABLE [dbo].[Estado_crucero]  WITH CHECK ADD  CONSTRAINT [FK_Estado_crucero_Crucero] FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Crucero] ([id])
GO
ALTER TABLE [dbo].[Estado_crucero] CHECK CONSTRAINT [FK_Estado_crucero_Crucero]
GO
ALTER TABLE [dbo].[Estado_crucero]  WITH CHECK ADD  CONSTRAINT [FK_Estado_crucero_Tipo_estado_crucero] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[Tipo_estado_crucero] ([id])
GO
ALTER TABLE [dbo].[Estado_crucero] CHECK CONSTRAINT [FK_Estado_crucero_Tipo_estado_crucero]
GO
ALTER TABLE [dbo].[Estado_pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Estado_pasaje_Pasaje] FOREIGN KEY([id_pasaje])
REFERENCES [dbo].[Pasaje] ([id])
GO
ALTER TABLE [dbo].[Estado_pasaje] CHECK CONSTRAINT [FK_Estado_pasaje_Pasaje]
GO
ALTER TABLE [dbo].[Medio_pago]  WITH CHECK ADD  CONSTRAINT [FK_Medio_pago_Tarjeta_credito] FOREIGN KEY([nro_tarjeta])
REFERENCES [dbo].[Tarjeta_credito] ([nro_tarjeta])
GO
ALTER TABLE [dbo].[Medio_pago] CHECK CONSTRAINT [FK_Medio_pago_Tarjeta_credito]
GO
ALTER TABLE [dbo].[Pasaje]  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Cabina] FOREIGN KEY([id_cabina])
REFERENCES [dbo].[Cabina] ([id])
GO
ALTER TABLE [dbo].[Pasaje] NOCHECK CONSTRAINT [FK_Pasaje_Cabina]
GO
ALTER TABLE [dbo].[Pasaje]  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Pasaje] NOCHECK CONSTRAINT [FK_Pasaje_Cliente]
GO
ALTER TABLE [dbo].[Pasaje]  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Medio_pago] FOREIGN KEY([id_medio_pago])
REFERENCES [dbo].[Medio_pago] ([id])
GO
ALTER TABLE [dbo].[Pasaje] NOCHECK CONSTRAINT [FK_Pasaje_Medio_pago]
GO
ALTER TABLE [dbo].[Pasaje]  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([id_viaje])
REFERENCES [dbo].[Viaje] ([id])
GO
ALTER TABLE [dbo].[Pasaje] NOCHECK CONSTRAINT [FK_Pasaje_Viaje]
GO
ALTER TABLE [dbo].[Puerto_recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Puerto] FOREIGN KEY([id_puerto_origen])
REFERENCES [dbo].[Puerto] ([id])
GO
ALTER TABLE [dbo].[Puerto_recorrido] CHECK CONSTRAINT [FK_Puerto_recorrido_Puerto]
GO
ALTER TABLE [dbo].[Puerto_recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Puerto1] FOREIGN KEY([id_puerto_destino])
REFERENCES [dbo].[Puerto] ([id])
GO
ALTER TABLE [dbo].[Puerto_recorrido] CHECK CONSTRAINT [FK_Puerto_recorrido_Puerto1]
GO
ALTER TABLE [dbo].[Puerto_recorrido]  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Recorrido] FOREIGN KEY([id_recorrido])
REFERENCES [dbo].[Recorrido] ([id])
GO
ALTER TABLE [dbo].[Puerto_recorrido] CHECK CONSTRAINT [FK_Puerto_recorrido_Recorrido]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cabina] FOREIGN KEY([id_cabina])
REFERENCES [dbo].[Cabina] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cabina]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Viaje] FOREIGN KEY([id_viaje])
REFERENCES [dbo].[Viaje] ([id])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Viaje]
GO
ALTER TABLE [dbo].[Rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES [dbo].[Funcionalidad] ([id])
GO
ALTER TABLE [dbo].[Rol_funcionalidad] CHECK CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad]
GO
ALTER TABLE [dbo].[Usuario_rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_rol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Usuario_rol] CHECK CONSTRAINT [FK_Usuario_rol_Usuario]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Crucero] FOREIGN KEY([id_crucero])
REFERENCES [dbo].[Crucero] ([id])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_Crucero]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Recorrido] FOREIGN KEY([id_recorrido])
REFERENCES [dbo].[Recorrido] ([id])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_Recorrido]
GO
/****** Object:  Trigger [dbo].[inhabilitarRecorrido]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[inhabilitarRecorrido] on [dbo].[Recorrido] instead of delete 
as begin
	update Recorrido	
		set inhabilitado = 1
		where id in (select id from deleted)
end 
GO
/****** Object:  Trigger [dbo].[inhabilitarRol]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[inhabilitarRol] on [dbo].[Rol] instead of delete 
as begin
	update Rol	
		set inhabilitado = 1
		where id in (select id from deleted)
end

GO
/****** Object:  Trigger [dbo].[inhabilitarUsuario]    Script Date: 05/06/2019 15:34:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[inhabilitarUsuario] on [dbo].[Usuario] instead of delete 
as begin
	update Usuario	
		set inhabilitado = 1
		where id in (select id from deleted)
end 
GO
USE [master]
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET  READ_WRITE 
GO
