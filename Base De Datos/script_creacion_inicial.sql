
USE [GD1C2019]
go
CREATE SCHEMA [SEGUNDA_VUELTA]
GO
/****** Object:  UserDefinedTableType SEGUNDA_VUELTA.[cabinas]    Script Date: 30/06/2019 15:37:05 ******/
CREATE TYPE SEGUNDA_VUELTA.[cabinas] AS TABLE(
	[nro] [decimal](18, 0) NULL,
	[piso] [decimal](18, 0) NULL,
	[id_servicio] [int] NULL
)
GO
/****** Object:  UserDefinedTableType SEGUNDA_VUELTA.[ids]    Script Date: 30/06/2019 15:37:05 ******/
CREATE TYPE SEGUNDA_VUELTA.[ids] AS TABLE(
	[id] [int] NULL
)
GO
/****** Object:  UserDefinedTableType SEGUNDA_VUELTA.[tramo]    Script Date: 30/06/2019 15:37:05 ******/
CREATE TYPE SEGUNDA_VUELTA.[tramo] AS TABLE(
	[indice] [int] NULL,
	[inicio] [int] NULL,
	[destino] [int] NULL,
	[precio] [decimal](18, 2) NULL
)
GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaCliente]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[altaCliente] 
								@nombre nvarchar(255),
								@apellido nvarchar(255),
								@dni numeric(18,0),
								@direccion nvarchar(255),
								@telefono nvarchar(255),
								@mail nvarchar(255),
								@fechaNacimiento datetime2(3),
								@id int OUTPUT 
								
								
as begin
begin try
	begin transaction
	declare @idUsuario int
	set @idUsuario = (select id from SEGUNDA_VUELTA.Usuario where nombre = 'cliente')
	insert into SEGUNDA_VUELTA.Cliente (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario)
		values (@nombre, @apellido, @dni, @direccion, @telefono, @mail, @fechaNacimiento, @idUsuario)

	commit
	set @id = @@identity
	return
end try
begin catch
	print(ERROR_MESSAGE())
	declare @error nvarchar(255)
	set @error = ERROR_MESSAGE()
	raiserror('Error al cargar el cliente: %s' , 12,1, @error)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[altaCrucero] 
								@nombre nvarchar(255), 
								@modelo nvarchar(255),
								@identificador nvarchar(255), 
								@id_marca int, 
								@fechaAlta datetime2(3),
								@cabinas SEGUNDA_VUELTA.cabinas READONLY
								
as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction

	declare @idCrucero int 

	insert into SEGUNDA_VUELTA.Crucero (nombre, modelo, id_marca, fecha_alta, identificador)
		values (@nombre, @modelo, @id_marca, @fechaAlta, @identificador)
	
	set @idCrucero = SCOPE_IDENTITY()

	insert into SEGUNDA_VUELTA.Cabina (id_crucero, nro, piso, id_servicio)
		select @idCrucero, nro, piso, id_servicio
			from @cabinas

	insert into SEGUNDA_VUELTA.Estado_crucero (id_tipo, fecha_inicio, fecha_fin, id_crucero)
			values (
				(select id from SEGUNDA_VUELTA.Tipo_estado_crucero where nombre = 'En funcionamiento'),
				@fechaAlta,
				null, 
				@idCrucero
				)
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del crucero', 12,1)
	rollback
end catch
end




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaPasaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[altaPasaje] 
								@idCliente int,
								@idViaje int,
								@idCabina int,
								@fecha datetime2(3),
								@idMedioPago int,
								@codigo int OUTPUT 
								
								
as begin
begin try
	begin transaction
	
	insert into SEGUNDA_VUELTA.Pasaje (id_cliente, fecha, id_viaje, id_cabina, id_medio_pago, precio, codigo)
		values (@idCliente, @fecha, @idViaje, @idCabina, @idMedioPago, SEGUNDA_VUELTA.precioViaje(@idViaje, @idCabina), isnull((select top 1 id from SEGUNDA_VUELTA.Pasaje order by id desc), 0)+1)

	set @codigo = SCOPE_IDENTITY()
	
	commit
		return
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del pasaje', 12,1)
	rollback
end catch
end




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaRecorrido]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[altaRecorrido] @codigo int,
						@puertos SEGUNDA_VUELTA.tramo readonly

as begin
begin try
	begin transaction

	declare @idRecorrido int
	
	if((select count(*) from @puertos) < 1)
	begin 
	raiserror('Debe seleccionar como minimo dos puertos', 12,1)
	end

	insert into SEGUNDA_VUELTA.Recorrido (codigo, inicio, inhabilitado, destino) 
		values (
			@codigo, 
			(select top 1 inicio from @puertos order by indice asc)
			, 
			0, 
			(select top 1 destino from @puertos order by indice desc)
			)

	set @idRecorrido = (select @@identity) 

	insert into SEGUNDA_VUELTA.Puerto_recorrido (id_puerto_origen, id_puerto_destino, precio, id_recorrido) 
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaRol]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[altaRol] @nombre nvarchar(255), @ids SEGUNDA_VUELTA.ids READONLY
as begin

begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Rol	(nombre, inhabilitado) values (@nombre, 0)
	declare @idRol int
	set @idRol =  SCOPE_IDENTITY()
	exec SEGUNDA_VUELTA.recargarFuncionalidades @idRol, @ids

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cargar el Rol', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaTarjeta]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc SEGUNDA_VUELTA.[altaTarjeta] 
								@nroTarjeta int,
								@codigoDeguridad int,
								@cantCuotas int
															
as begin
begin try
	begin transaction
	
	insert into Tarjeta_credito(nro_tarjeta, codigo_seguridad)
		values (@nroTarjeta, @codigoDeguridad)

	insert into SEGUNDA_VUELTA.Medio_pago (nro_tarjeta, cant_cuotas, nombre)
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[altaViaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[altaViaje] 
								@idCrucero int, 
								@idRecorrido int, 
								@fechaInicio datetime2(3),
								@fechaFin datetime2(3)
								
as begin
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Viaje (id_recorrido, id_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada)
		values (@idRecorrido, @idCrucero, @fechaInicio, @fechaFin, @fechaFin)

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta del Viaje', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cancelarPasajesDeCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[cancelarPasajesDeCrucero] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3), @motivo nvarchar(255)
as begin
begin try
	begin transaction

	if(@fechaFin is null)
	begin
		insert into SEGUNDA_VUELTA.Estado_pasaje (nombre, observacion, id_pasaje)
		select 'cancelado', @motivo, p.id
			from SEGUNDA_VUELTA.Pasaje p
			join SEGUNDA_VUELTA.Viaje v on p.id_viaje = v.id
			join SEGUNDA_VUELTA.Crucero c on c.id = v.id_crucero
			where v.fecha_inicio >=  @fechaInicio
			and v.id_crucero = @idCrucero

		update SEGUNDA_VUELTA.Viaje
			set cancelado = 1
			where id_crucero = @idCrucero
			and fecha_inicio >= @fechaInicio
	end
	else
	begin
		insert into SEGUNDA_VUELTA.Estado_pasaje (nombre, observacion, id_pasaje)
		select 'cancelado', @motivo, p.id
			from SEGUNDA_VUELTA.Pasaje p
			join SEGUNDA_VUELTA.Viaje v on p.id_viaje = v.id
			where v.fecha_inicio >=  @fechaInicio and v.fecha_inicio < @fechaFin
			and v.id_crucero = @idCrucero

		update SEGUNDA_VUELTA.Viaje
			set cancelado = 1
			where id_crucero = @idCrucero
			and fecha_inicio >= @fechaInicio and fecha_inicio < @fechaFin
	end

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cancelar los pasajes', 12,1)
	rollback
end catch
	
	

end


GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cancelarReservas]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[cancelarReservas] @fecha datetime2(3) 							
as begin
begin try
	begin transaction
	
	delete from SEGUNDA_VUELTA.Reserva
		where datediff(day, fecha, @fecha) > 3

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cancelar las reservas', 12,1)
	rollback
end catch
end




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarClientes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarClientes] AS
BEGIN
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Cliente (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario)
		select CLI_NOMBRE, 
				CLI_APELLIDO, 
				CLI_DNI, 
				CLI_DIRECCION, 
				CLI_TELEFONO,
				CLI_MAIL, 
				CLI_FECHA_NAC,
				(select id from SEGUNDA_VUELTA.Usuario where nombre = 'cliente')
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarCrucerosYCabinas]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarCrucerosYCabinas]  AS
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
		insert into SEGUNDA_VUELTA.Crucero (nombre, modelo, id_marca, fecha_alta, identificador)
			values (	
				@nombre, 
				@modelo, 
				(select id from SEGUNDA_VUELTA.Marca_Crucero where nombre = @fabricante),
				null,
				@nombre
				)
		set @idCrucero = SCOPE_IDENTITY()
		
		insert into SEGUNDA_VUELTA.Estado_crucero (id_tipo, fecha_inicio, fecha_fin, id_crucero)
			values (
				(select id from SEGUNDA_VUELTA.Tipo_estado_crucero where nombre = 'En funcionamiento'),
				(select getdate()),
				null, 
				@idCrucero
				)
		insert into SEGUNDA_VUELTA.Cabina (id_crucero, id_servicio, nro, piso)
			select 
				@idCrucero,
				(select id from SEGUNDA_VUELTA.Servicio where nombre = CABINA_TIPO),
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarEstadosCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE SEGUNDA_VUELTA.[cargarEstadosCrucero]  AS
BEGIN
begin try
	begin transaction

	
	insert into SEGUNDA_VUELTA.Tipo_estado_crucero (nombre)
		values ('Fuera de Servicio'), ('Fin de vida util'), ('En funcionamiento')
 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los estados del crucero', 12,1)
	rollback
end catch
END





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[CargarEstadosPasaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SEGUNDA_VUELTA.[CargarEstadosPasaje] AS
BEGIN
begin try
	begin transaction
	insert into SEGUNDA_VUELTA.Estado_pasaje (nombre, observacion, id_pasaje)
		 select 'pagado', null, id
		 from SEGUNDA_VUELTA.Pasaje 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los estados del pasaje', 12,1)
	rollback
end catch
END




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarFuncionalidades]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarFuncionalidades]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	insert into SEGUNDA_VUELTA.Funcionalidad (nombre)
		values ('abm_puerto'),( 'abm_recorrido'),( 'abm_crucero'),( 'generar_viaje'), ('reservar_viaje'), ('pagar_reserva'), ('listado_estadistico')
END





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarMarcasCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE SEGUNDA_VUELTA.[cargarMarcasCrucero]  AS
BEGIN
begin try
	begin transaction

	
	insert into SEGUNDA_VUELTA.Marca_Crucero (nombre)
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarMediosDePago]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarMediosDePago]  AS
BEGIN
begin try
	begin transaction
	
	insert into SEGUNDA_VUELTA.Medio_pago (nombre, cant_cuotas, nro_tarjeta)
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
	set @idEstado = (select id from SEGUNDA_VUELTA.Estado_pasaje where nombre = 'Reservado')*/




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarPasajesYReservas]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarPasajesYReservas]  AS
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
			from SEGUNDA_VUELTA.Recorrido rec
			join SEGUNDA_VUELTA.Puerto_recorrido pr on pr.id_recorrido = rec.id
			join SEGUNDA_VUELTA.Viaje via on via.id_recorrido = rec.id
			join SEGUNDA_VUELTA.Puerto pue_inicio on pue_inicio.id = rec.inicio
			join SEGUNDA_VUELTA.Puerto pue_destino on pue_destino.id = rec.destino 
			join SEGUNDA_VUELTA.Crucero cru on via.id_crucero = cru.id
			join SEGUNDA_VUELTA.Cabina cab on cab.id_crucero = cru.id
			join SEGUNDA_VUELTA.Servicio srv on srv.id = cab.id_servicio
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

	
	insert into SEGUNDA_VUELTA.Pasaje (id_cliente, id_medio_pago, fecha, id_cabina, id_viaje, codigo, precio)
		select 
			cli.id,
			null,
			g.PASAJE_FECHA_COMPRA,
			p.cab_id,
			p.via_id,
			PASAJE_CODIGO,
			p.precio
		from GD1C2019.gd_esquema.Maestra g
		join SEGUNDA_VUELTA.Cliente cli on cli.apellido = CLI_APELLIDO and cli.nombre = CLI_NOMBRE and cli.dni = CLI_DNI 
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

	insert into SEGUNDA_VUELTA.Reserva (id_cliente, fecha, codigo, id_viaje, id_cabina)
	select 
			cli.id,
			g.RESERVA_FECHA,
			g.RESERVA_CODIGO,
			p.via_id,
			p.cab_id
		from GD1C2019.gd_esquema.Maestra g
		join SEGUNDA_VUELTA.Cliente cli on cli.apellido = CLI_APELLIDO and cli.nombre = CLI_NOMBRE and cli.dni = CLI_DNI 
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarPuertoRecorrido]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarPuertoRecorrido]  AS
BEGIN
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Puerto_recorrido (id_puerto_origen, id_puerto_destino, id_recorrido, precio) 
		select r.inicio, r.destino, r.id, RECORRIDO_PRECIO_BASE
		from SEGUNDA_VUELTA.Recorrido r
		join SEGUNDA_VUELTA.Puerto as p1 on r.inicio = p1.id
		join SEGUNDA_VUELTA.Puerto as p2 on r.destino = p2.id
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[CargarPuertos]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SEGUNDA_VUELTA.[CargarPuertos]  AS
BEGIN
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Puerto (nombre) 
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarRecorridos]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarRecorridos]  AS
BEGIN
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Recorrido (codigo, inicio, destino, inhabilitado) 
		select RECORRIDO_CODIGO, p1.id, p2.id, 0
		from GD1C2019.gd_esquema.Maestra
		join SEGUNDA_VUELTA.Puerto as p1 on PUERTO_DESDE = p1.nombre 
		join SEGUNDA_VUELTA.Puerto as p2 on PUERTO_HASTA = p2.nombre
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarRoles]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarRoles]
AS
BEGIN
	insert into SEGUNDA_VUELTA.Rol (nombre, inhabilitado)
		values ('administrador', null) , ('cliente', null)

END





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarServiciosCabina]    Script Date: 30/06/2019 15:37:06 ******/
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
create PROCEDURE SEGUNDA_VUELTA.[cargarServiciosCabina]  AS
BEGIN
begin try
	begin transaction

	
	insert into SEGUNDA_VUELTA.Servicio (nombre, porc_aumento)
		select CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
		from GD1C2019.gd_esquema.Maestra
		group by CABINA_TIPO, CABINA_TIPO_PORC_RECARGO
 
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los servicios de Cabina', 12,1)
	rollback
end catch
END





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarUsuarios]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[cargarUsuarios]
as begin

begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Funcionalidad (nombre) 
		values ('abm_rol') , 
				('abm_recorrido'), 
				('abm_crucero'),
				('generar_viaje'),
				('reservar_viaje'),
				('pago_reserva'),
				('listado_estadistico')

	insert into SEGUNDA_VUELTA.Rol (nombre, inhabilitado)
		values ('admin', 0), ('cliente', 0)

	insert into SEGUNDA_VUELTA.Rol_funcionalidad (id_rol, id_funcionalidad)
		select 
			(select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'admin'),
			id
			from SEGUNDA_VUELTA.Funcionalidad 
	
	insert into SEGUNDA_VUELTA.Rol_funcionalidad (id_rol, id_funcionalidad)
		values ( 
			(select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'cliente'), 
			(select f.id from SEGUNDA_VUELTA.Funcionalidad f where nombre = 'reservar_viaje')
		),
		( 
			(select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'cliente'), 
			(select f.id from SEGUNDA_VUELTA.Funcionalidad f where nombre = 'pago_reserva')
		)


	insert into SEGUNDA_VUELTA.Usuario (password, nombre, cant_intentos_fallido,  inhabilitado)
		values(
			HASHBYTES('SHA2_256', cast('w23e' as nvarchar(255))),
			cast('admin' as nvarchar(255)),
			0,
			0
		)

	insert into SEGUNDA_VUELTA.Usuario (password, nombre, cant_intentos_fallido,  inhabilitado)
		values(
			HASHBYTES('SHA2_256', cast('administrador' as nvarchar(255))),
			cast('administrador' as nvarchar(255)),
			0,
			0
		)
	
	insert into SEGUNDA_VUELTA.Usuario (password, nombre, cant_intentos_fallido,  inhabilitado)
		values
		(
			HASHBYTES('SHA2_256', cast('cliente' as nvarchar(255))),
			cast('cliente' as nvarchar(255)),
			0,
			0
		)

	insert into SEGUNDA_VUELTA.Usuario_rol (id_rol, id_usuario)
		select (select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'admin'),
				id from SEGUNDA_VUELTA.Usuario where nombre = 'admin'

	insert into SEGUNDA_VUELTA.Usuario_rol (id_rol, id_usuario)
		select (select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'admin'),
				id from SEGUNDA_VUELTA.Usuario where nombre = 'administrador'

	insert into SEGUNDA_VUELTA.Usuario_rol (id_rol, id_usuario)
		select (select r.id from SEGUNDA_VUELTA.Rol r where nombre = 'cliente'),
				id from SEGUNDA_VUELTA.Usuario where nombre = 'cliente'

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los usuarios', 12,1)
	rollback
end catch
end





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[cargarViajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SEGUNDA_VUELTA.[cargarViajes]  AS
BEGIN
begin try
	begin transaction

	insert into SEGUNDA_VUELTA.Viaje ( id_recorrido, id_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada/*, cant_cabinas_libres*/ ) 
		select r.id, 
				cru1.id,
				g1.FECHA_SALIDA, 
				g1.FECHA_LLEGADA, 
				g1.FECHA_LLEGADA_ESTIMADA/*, 
				(
					(
					select count(*) 
						from SEGUNDA_VUELTA.Cabina cab 
						join SEGUNDA_VUELTA.Crucero cru2 on cab.id_crucero = cru2.id 
						where cru1.id = cru2.id
					)
					-
					(
					select count(*) 

					)
				)*/
		from SEGUNDA_VUELTA.Recorrido r
		join SEGUNDA_VUELTA.Puerto as p1 on r.inicio = p1.id
		join SEGUNDA_VUELTA.Puerto as p2 on r.destino = p2.id
		join GD1C2019.gd_esquema.Maestra g1
			on RECORRIDO_CODIGO = r.codigo and p1.nombre = PUERTO_DESDE and p2.nombre = PUERTO_HASTA
		join SEGUNDA_VUELTA.Crucero cru1 on CRUCERO_IDENTIFICADOR = cru1.nombre 
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[completarVidaUtilCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc SEGUNDA_VUELTA.[completarVidaUtilCrucero] @idCrucero int, @fecha datetime2(3)
as begin
declare @estadoFinVidaUtil int
		set @estadoFinVidaUtil = (select id from SEGUNDA_VUELTA.Tipo_estado_crucero where nombre = 'Fin de vida util')

		insert into SEGUNDA_VUELTA.Estado_crucero (id_tipo, id_crucero, fecha_inicio, fecha_fin)
			values (@estadoFinVidaUtil, @idCrucero, @fecha, null)
end


GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[completarVidaUtilCruceroYCancelarPasajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[completarVidaUtilCruceroYCancelarPasajes] @idCrucero int, @fecha datetime2(3), @motivo nvarchar(255)

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		
		exec SEGUNDA_VUELTA.completarVidaUtilCrucero @idCrucero, @fecha
		exec SEGUNDA_VUELTA.cancelarPasajesDeCrucero @idCrucero, @fecha, null, @motivo

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [completarVidaUtilCruceroYCancelarPasajes]', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[completarVidaUtilCruceroYReprogramarPasajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.completarVidaUtilCruceroYReprogramarPasajes @idCrucero int, @fecha datetime2(3), @cruceroReemplazante Nvarchar(1000) OUTPUT

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		declare @fechaFin datetime2(3)
		set @fechaFin = (select top 1 fecha_fin from  SEGUNDA_VUELTA.Viaje where id_crucero = @idCrucero order by fecha_fin desc) 
		exec SEGUNDA_VUELTA.completarVidaUtilCrucero @idCrucero, @fecha
		exec SEGUNDA_VUELTA.reemplazarViajes @idCrucero, @fecha, @fechaFin, @cruceroReemplazante output
	commit
	return
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [completarVidaUtilCruceroYReprogramarPasajes]', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[loginUser]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.loginUser
								@usuario nvarchar(255),
								@password nvarchar(255),
								@respuesta  nvarchar(255) output,
								@idUser int output
								
as begin
begin try

	set @idUser = 0 
	if(exists (select * from SEGUNDA_VUELTA.Usuario where nombre = @usuario))
	begin

		if((select cant_intentos_fallido from SEGUNDA_VUELTA.Usuario where nombre = @usuario) > 3)
		begin
			set @respuesta = 'maxima cantidad de intentos fallidos'
			return
		end

		if((select password from SEGUNDA_VUELTA.Usuario where nombre = @usuario) = HASHBYTES('SHA2_256', @password))
		begin
			set @respuesta = 'ok'
			set @idUser = (select id from SEGUNDA_VUELTA.Usuario where nombre = @usuario)
			update SEGUNDA_VUELTA.Usuario 
				set cant_intentos_fallido = 0
				where nombre = @usuario
		end
		else
		begin
			set @respuesta = 'password incorrecta'
			update SEGUNDA_VUELTA.Usuario 
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
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[modificacionCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[modificacionCrucero] 
								@idCrucero int,
								@nombre nvarchar(255), 
								@modelo nvarchar(255), 
								@id_marca int,  
								@identificador nvarchar(255),
								@cabinas SEGUNDA_VUELTA.cabinas READONLY
							
as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
	declare @nro int
	declare @piso int
	declare @id_servicio int

	update SEGUNDA_VUELTA.Crucero 
		set nombre = @nombre,
			modelo = @modelo,
			id_marca = @id_marca,
			identificador = @identificador
			where id = @idCrucero
	
	--Borrar cabinas que hayan sufrido algun cambio
	DECLARE cabinasCrucero CURSOR FOR SELECT nro, piso, id_servicio from SEGUNDA_VUELTA.Cabina where id_crucero = @idCrucero
	OPEN cabinasCrucero
	FETCH NEXT FROM cabinasCrucero INTO @nro, @piso, @id_servicio
	WHILE @@fetch_status = 0
	BEGIN
		if not exists (select 1 from @cabinas where nro = @nro and piso = @piso and id_servicio = @id_servicio)
		begin
				update SEGUNDA_VUELTA.Cabina
				set borrada = 1
				where id_crucero = @idCrucero
					and nro = @nro
					and piso = @piso
					and id_servicio = @id_servicio
		end
		FETCH NEXT FROM cabinasCrucero INTO  @nro, @piso, @id_servicio
	END
	CLOSE cabinasCrucero
	DEALLOCATE cabinasCrucero

	--Cargar cabinas que si hayan sufrido cambios
	DECLARE cabinasNuevas CURSOR FOR SELECT nro, piso, id_servicio from @cabinas
	OPEN cabinasNuevas
	FETCH NEXT FROM cabinasNuevas INTO @nro, @piso, @id_servicio
	WHILE @@fetch_status = 0
	BEGIN
		if not exists (select 1 from SEGUNDA_VUELTA.Cabina where nro = @nro and piso = @piso and id_servicio = @id_servicio and id_crucero = @idCrucero and SEGUNDA_VUELTA.Cabina.borrada is null)
		begin
			insert into SEGUNDA_VUELTA.Cabina (nro, piso, id_servicio, id_crucero)
			values (@nro, @piso, @id_servicio, @idCrucero)
		end
		FETCH NEXT FROM cabinasNuevas INTO  @nro, @piso, @id_servicio
	END
	CLOSE cabinasNuevas
	DEALLOCATE cabinasNuevas



		
	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en la modificacion del crucero', 12,1)
	rollback
end catch
end


select * from SEGUNDA_VUELTA.Crucero cru 
	join SEGUNDA_VUELTA.Cabina cab on cab.id_crucero = cru.id
	where cru.identificador = '555'
	

GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[modificacionRecorrido]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[modificacionRecorrido] 
						@idRecorrido int,
						@codigo int,
						@puertos SEGUNDA_VUELTA.tramo readonly

as begin
begin try
	begin transaction


	
	if((select count(*) from @puertos) < 1)
	begin 
	raiserror('Debe seleccionar como minimo dos puertos', 12,1)
	end
	update SEGUNDA_VUELTA.Recorrido 
		set codigo = @codigo,
			inicio = (select top 1 inicio from @puertos order by indice asc),
			destino = (select top 1 destino from @puertos order by indice asc)
		where id = @idRecorrido

	delete from SEGUNDA_VUELTA.Puerto_recorrido where id_recorrido = @idRecorrido

	insert into SEGUNDA_VUELTA.Puerto_recorrido (id_puerto_origen, id_puerto_destino, precio, id_recorrido) 
		select inicio, destino, precio ,@idRecorrido
		from @puertos

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al modificar el Recorrido', 12,1)
	rollback
end catch
end





GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[modificacionRol]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc SEGUNDA_VUELTA.[modificacionRol] @idRol int, @nombre nvarchar(255), @ids SEGUNDA_VUELTA.ids READONLY
as begin

begin try
	begin transaction

	update SEGUNDA_VUELTA.Rol set nombre = @nombre where id = @idRol
	exec SEGUNDA_VUELTA.recargarFuncionalidades @idRol, @ids

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al cargar el Rol', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[pagarReserva]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[pagarReserva] 
								@codigoReserva int,
								@nombreMedioPago nvarchar(255),
								@cantidadCuotas int,
								@nroTarjeta nvarchar(255),
								@codigoSeguridad int,
								@fecha datetime2(3),
								@codigo int OUTPUT
								
								
as begin
begin try
	begin transaction
	declare @idCliente int
	declare @idViaje int
	declare @idMedioPago int

	set @idCliente = (select top 1 id_cliente from SEGUNDA_VUELTA.Reserva where codigo = @codigoReserva)
	set @idViaje = (select top 1 id_viaje from SEGUNDA_VUELTA.Reserva where codigo = @codigoReserva)

	if(@nombreMedioPago <> 'efectivo')
	begin
		if(not exists(select 1 from Tarjeta_credito where nro_tarjeta = @nroTarjeta))
		begin
			insert into Tarjeta_credito (codigo_seguridad, nro_tarjeta) values (@codigoSeguridad, @nroTarjeta)
		end
		
		insert into SEGUNDA_VUELTA.Medio_pago (nombre, cant_cuotas, nro_tarjeta) values (@nombreMedioPago, @cantidadCuotas, @nroTarjeta)
		set @idMedioPago = SCOPE_IDENTITY()
	end
	else
	begin
		set @idMedioPago = (select id from SEGUNDA_VUELTA.Medio_pago where nombre = 'efectivo')
	end

	declare @codigo_pasaje int 
	set @codigo_pasaje = isnull((select top 1 codigo from SEGUNDA_VUELTA.Pasaje order by codigo desc ), 0) +1

	insert into SEGUNDA_VUELTA.Pasaje (id_cliente, fecha, id_viaje, id_cabina, id_medio_pago, precio, codigo)
		select @idCliente, @fecha, @idViaje, id_cabina, @idMedioPago, SEGUNDA_VUELTA.precioViaje(@idViaje, id_cabina), @codigo_pasaje
		from SEGUNDA_VUELTA.Reserva where codigo = @codigoReserva

	set @codigo = @codigo_pasaje

	
	commit
	return 
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el pago de la Reserva', 12,1)
	rollback
end catch
end

select *  from SEGUNDA_VUELTA.Medio_pago


GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[ponerEnFueraDeServicioCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc SEGUNDA_VUELTA.[ponerEnFueraDeServicioCrucero] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3)
as begin
declare @estadoFueraDeServicio int
		set @estadoFueraDeServicio = (select id from SEGUNDA_VUELTA.Tipo_estado_crucero where nombre = 'Fuera de Servicio')

		insert into SEGUNDA_VUELTA.Estado_crucero (id_tipo, id_crucero, fecha_inicio, fecha_fin)
			values (@estadoFueraDeServicio, @idCrucero, @fechaInicio, @fechaFin)
end


GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[ponerEnFueraDeServicioCruceroYCancelarPasajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[ponerEnFueraDeServicioCruceroYCancelarPasajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3), @motivo nvarchar(255)

as begin
begin try
	begin transaction
		
		exec SEGUNDA_VUELTA.ponerEnFueraDeServicioCrucero @idCrucero, @fechaInicio, @fechaFin
		exec SEGUNDA_VUELTA.cancelarPasajesDeCrucero @idCrucero, @fechaInicio, @fechaFin, @motivo

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en la modificacion del Crucero', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[ponerEnFueraDeServicioCruceroYReprogramarPasajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[ponerEnFueraDeServicioCruceroYReprogramarPasajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3), @cruceroReemplazante Nvarchar(1000) OUTPUT

as begin
/*type cabinas ( nro decimal(18,0), piso decimal(18,0), id_servicio int );*/
begin try
	begin transaction
		declare @cruReemplazante nvarchar(1000)
		exec SEGUNDA_VUELTA.ponerEnFueraDeServicioCrucero @idCrucero, @fechaInicio, @fechaFin
		exec SEGUNDA_VUELTA.reemplazarViajes @idCrucero, @fechaInicio, @fechaFin, @cruReemplazante

		set @cruceroReemplazante = @cruReemplazante


	commit
			return
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error [ponerEnFueraDeServicioCruceroYReprogramarPasajes]', 12,1)
	rollback
end catch
end



GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[postergarViajesDeCrucero]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[postergarViajesDeCrucero] 
								@idCrucero int, 
								@cantDias int,
								@fechaInicio datetime2(3),
								@fechaFin datetime2(3)
								
as begin
begin try
	begin transaction

	exec SEGUNDA_VUELTA.ponerEnFueraDeServicioCrucero @idCrucero, @fechaInicio, @fechaFin
	update SEGUNDA_VUELTA.Viaje 
		set fecha_inicio = dateadd(day, @cantDias, fecha_inicio),
			fecha_fin = dateadd(day, @cantDias, fecha_fin),
			fecha_fin_estimada = dateadd(day, @cantDias, fecha_fin_estimada)
		where id_crucero = @idCrucero
		and fecha_inicio > = @fechaInicio

	commit
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error al postergar los viajes', 12,1)
	rollback
end catch
end


select * from SEGUNDA_VUELTA.Viaje where id_crucero = 38
GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[recargarFuncionalidades]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[recargarFuncionalidades] @idRol int, @ids SEGUNDA_VUELTA.ids READONLY
as begin

begin try
	begin transaction
	delete from SEGUNDA_VUELTA.Rol_funcionalidad where id_rol = @idRol
	insert into SEGUNDA_VUELTA.Rol_funcionalidad(id_rol, id_funcionalidad) select @idRol, id from @ids

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar funcionalidades', 12,1)
	rollback
end catch
end




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[reemplazarViajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc SEGUNDA_VUELTA.[reemplazarViajes] @idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3), @cruceroReemplazante Nvarchar(1000) OUTPUT
as begin
	declare @idCruceroReemplazante int
	set @idCruceroReemplazante = SEGUNDA_VUELTA.cruceroReemplazante(@idCrucero, @fechaInicio, @fechaFin)
	if( @idCruceroReemplazante <> -1 )
	
		begin
		print(@idCruceroReemplazante)
			update SEGUNDA_VUELTA.Viaje
				set id_crucero = @idCruceroReemplazante
				where id_crucero = @idCrucero
		set @cruceroReemplazante = (select identificador from SEGUNDA_VUELTA.Crucero where id = @idCruceroReemplazante)
		return
		end
		else
		begin
			raiserror('No existe ningun reemplazo para el crucero', 12, 1)
		end
end 


GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[reiniciarBase]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SEGUNDA_VUELTA.reiniciarBase
AS
BEGIN

begin transaction t1
begin try

disable trigger inhabilitarRol on SEGUNDA_VUELTA.Rol;
disable trigger inhabilitarUsuario on SEGUNDA_VUELTA.Usuario;
disable trigger inhabilitarRecorrido on SEGUNDA_VUELTA.Recorrido


delete from SEGUNDA_VUELTA.Estado_pasaje
delete from SEGUNDA_VUELTA.Pasaje
delete from SEGUNDA_VUELTA.Medio_pago
delete from SEGUNDA_VUELTA.Reserva
delete from SEGUNDA_VUELTA.Cliente
delete from SEGUNDA_VUELTA.Usuario_rol
delete from SEGUNDA_VUELTA.Rol_funcionalidad
delete from SEGUNDA_VUELTA.Funcionalidad
delete from SEGUNDA_VUELTA.Usuario
delete from SEGUNDA_VUELTA.Rol
delete from SEGUNDA_VUELTA.Estado_crucero
delete from SEGUNDA_VUELTA.Cabina
delete from SEGUNDA_VUELTA.Servicio
delete from SEGUNDA_VUELTA.Viaje
delete from SEGUNDA_VUELTA.Crucero
delete from SEGUNDA_VUELTA.Tipo_estado_crucero
delete from SEGUNDA_VUELTA.Marca_Crucero
delete from SEGUNDA_VUELTA.Puerto_recorrido
delete from SEGUNDA_VUELTA.Recorrido
delete from SEGUNDA_VUELTA.Puerto
delete from SEGUNDA_VUELTA.Tarjeta_credito;


enable trigger inhabilitarRol on SEGUNDA_VUELTA.Rol;
enable trigger inhabilitarUsuario on SEGUNDA_VUELTA.Usuario;
enable trigger inhabilitarRecorrido on SEGUNDA_VUELTA.Recorrido

commit transaction t1
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al eliminar', 12,1)
	rollback transaction t1
end catch

begin transaction t2
begin try

exec SEGUNDA_VUELTA.cargarUsuarios
exec SEGUNDA_VUELTA.cargarClientes
exec SEGUNDA_VUELTA.cargarEstadosCrucero
exec SEGUNDA_VUELTA.cargarMarcasCrucero
exec SEGUNDA_VUELTA.cargarServiciosCabina
exec SEGUNDA_VUELTA.cargarCrucerosYCabinas
exec SEGUNDA_VUELTA.cargarPuertos
exec SEGUNDA_VUELTA.cargarRecorridos
exec SEGUNDA_VUELTA.cargarPuertoRecorrido
exec SEGUNDA_VUELTA.cargarViajes
exec SEGUNDA_VUELTA.cargarMediosDePago
exec SEGUNDA_VUELTA.cargarPasajesYReservas
exec SEGUNDA_VUELTA.cargarEstadosPasaje


commit transaction t2
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar', 12,1)
	rollback transaction t2
end catch

END




GO
/****** Object:  StoredProcedure SEGUNDA_VUELTA.[reservarViaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc SEGUNDA_VUELTA.[reservarViaje] 
								@idCliente int,
								@idViaje int,
								@idCabinas SEGUNDA_VUELTA.ids readonly,
								@fecha datetime2(3),
								@codigo int OUTPUT 
								
								
as begin
declare @codigoReserva int
	declare @fechaInicio datetime2(3)
	declare @fechaFin datetime2(3)

	set @fechaInicio = (select fecha_inicio from SEGUNDA_VUELTA.Viaje where id = @idViaje)
	set @fechaFin = (select fecha_inicio from SEGUNDA_VUELTA.Viaje where id = @idViaje)

	set @codigoReserva = (select top 1 codigo from SEGUNDA_VUELTA.Reserva res
					join SEGUNDA_VUELTA.Viaje via on res.id_viaje = via.id
					where ((@fechaInicio >= via.fecha_inicio and @fechaInicio <= via.fecha_fin) or (@fechaFin >= via.fecha_inicio and @fechaFin <= via.fecha_fin))
					and via.id <> @idViaje
					and res.id_cliente = @idCliente)

	if(@codigoReserva is not null)
	begin
		raiserror( 'Usted ya cuenta con una reserva con codigo: %i cuya duracion de viaje se superpone con el viaje solicitado', 12,1, @codigoReserva )
		return
	end

begin try
	begin transaction
	set @codigoReserva = isnull((select top 1 r.codigo from SEGUNDA_VUELTA.Reserva r order by r.codigo desc), 0) +1

	insert into SEGUNDA_VUELTA.Reserva (id_cliente, fecha, id_viaje, id_cabina, codigo)
		select @idCliente, @fecha, @idViaje, cab.id, @codigoReserva
		from @idCabinas cab

	set @codigo = @codigoReserva
	
	commit
	return
end try
begin catch
	print(ERROR_MESSAGE())
	raiserror('Error en el alta de la Reserva', 12,1)
	rollback
end catch
end

GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[buscarViajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[buscarViajes] (@origen int, @destino int, @fecha nvarchar(255), @cantPasajes int)
returns @viajes table (cru_id int, cru_nombre nvarchar(255), via_id int)
begin

		insert into @viajes
		select cru.id cru_id, cru.nombre cru_nombre, via.id via_id
		from SEGUNDA_VUELTA.Crucero cru                                                     
		join SEGUNDA_VUELTA.Viaje via on cru.id = via.id_crucero
		join SEGUNDA_VUELTA.Recorrido rec on rec.id = via.id_recorrido
		join SEGUNDA_VUELTA.Puerto_recorrido pr on pr.id_recorrido = rec.id
		where via.cancelado is null
			and via.cant_cabinas_libres >= @cantPasajes
			and (@origen = -1 or rec.inicio = @origen)
			and (@destino = -1 or pr.id_puerto_destino = @destino)
			and (@fecha is null or convert(date,via.fecha_inicio) = @fecha)
		group by cru.id, cru.nombre, via.id

	return
end
GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[cabinasLibres]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[cabinasLibres] (@idViaje int)
returns @cabinas table (id int)
begin
insert into @cabinas select cab.id
			from SEGUNDA_VUELTA.Cabina cab
			join SEGUNDA_VUELTA.Crucero cru on cab.id_crucero = cru.id
			join SEGUNDA_VUELTA.Viaje via on via.id_crucero = cru.id
			where via.id = @idViaje and 
					cab.id not in (select id from SEGUNDA_VUELTA.Reserva res where res.id_viaje = @idViaje) and
					cab.id not in (select id from SEGUNDA_VUELTA.Pasaje  pas where pas.id_viaje = @idViaje) and
					cab.borrada is null

			
	return
end


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[cabinasLibresConDatos]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.cabinasLibresConDatos (@idViaje int)
returns @cabinas table (id int, nro int, piso int, servicio nvarchar(255), precio int)
begin
insert into @cabinas select cab.id id_cabina, 
						cab.nro nro, 
						cab.piso piso, 
						srv.nombre servicio, 
						SEGUNDA_VUELTA.precioViaje(@idViaje, cab.id) precio
			from SEGUNDA_VUELTA.Cabina cab
			join SEGUNDA_VUELTA.Crucero cru on cab.id_crucero = cru.id
			join SEGUNDA_VUELTA.Servicio srv on srv.id = cab.id_servicio
			join SEGUNDA_VUELTA.Viaje via on via.id_crucero = cru.id
			where via.id = @idViaje and 
					cab.id not in (select id_cabina from SEGUNDA_VUELTA.Reserva res where res.id_viaje = @idViaje) and
					cab.id not in (select id_cabina from SEGUNDA_VUELTA.Pasaje  pas where pas.id_viaje = @idViaje) and
					cab.borrada is null

			
	return
end



GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[completarCabinas]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function SEGUNDA_VUELTA.completarCabinas (@cabinas SEGUNDA_VUELTA.ids readonly, @viaje int)
returns @cabinasRTN table (piso int, nro int, precio int)
begin

	insert into @cabinasRTN	(piso, nro, precio)
	select piso, nro, SEGUNDA_VUELTA.precioViaje(@viaje, id)
		from SEGUNDA_VUELTA.Cabina where id in (select id from @cabinas)
	return
end


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[cruceroDisponible]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE function SEGUNDA_VUELTA.[cruceroDisponible](@idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3))
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
		(select id from SEGUNDA_VUELTA.crucerosFueraDeServicio(@fechaInicio)) 
		union 
		(select id from SEGUNDA_VUELTA.crucerosFinVidaUtil(@fechaInicio)) 
		)
	)
	begin
		return 0
	end 

	if(not exists (select 1 from SEGUNDA_VUELTA.Viaje via
										join SEGUNDA_VUELTA.Crucero c on via.id_crucero = c.id
										where id_crucero = @idCrucero
										and fecha_fin >= @fechaInicio and fecha_inicio <= @fechaFin))
	begin
		return 1	
	end

	DECLARE fechasOcupadasCrucero CURSOR LOCAL FOR SELECT  via.fecha_inicio, fecha_fin
										from SEGUNDA_VUELTA.Viaje via
										join SEGUNDA_VUELTA.Crucero c on via.id_crucero = c.id
										where id_crucero = @idCrucero
										and fecha_fin >= @fechaInicio and fecha_inicio <= @fechaFin
										order by fecha_inicio

					open fechasOcupadasCrucero

					fetch next from fechasOcupadasCrucero into @fechaInicioViaje1, @fechaFinViaje1
					fetch next from fechasOcupadasCrucero into @fechaInicioViaje2, @fechaFinViaje2
					
					if(@@FETCH_STATUS <> 0 ) /*Si el crucero solo tiene 1 Viaje */
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
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[cruceroReemplazante]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[cruceroReemplazante] (@idCrucero int, @fechaInicio datetime2(3), @fechaFin datetime2(3))
returns int
as begin

	declare	@idViaje int
	declare @fechaInicioViajeAReemplazar datetime2(3)
	declare @fechaFinViajeAReemplazar datetime2(3)
	declare @idPosibleCrucero int
	declare @cruceroPuedeSerReemplazante bit
	set @idPosibleCrucero = -1

	DECLARE viajesAReemplazar CURSOR LOCAL FOR SELECT fecha_inicio, fecha_fin
										from SEGUNDA_VUELTA.Viaje
										where id_crucero = @idCrucero
										and fecha_inicio >= @fechaInicio and fecha_fin <= @fechaFin
										order by fecha_inicio
	
	declare cruceros cursor local for select id 
										from SEGUNDA_VUELTA.Crucero 
										where id not in (
						select est.id_crucero
						from SEGUNDA_VUELTA.Estado_crucero est 
						join SEGUNDA_VUELTA.Tipo_estado_crucero tip on tip.id = est.id_tipo
						where (tip.nombre = 'Fuera de Servicio' or tip.nombre = 'Fin de vida util')
							and (
							(est.fecha_fin is null and (est.fecha_inicio < @fechaInicio or est.fecha_inicio < @fechaFin))  
							or
							( 
								(est.fecha_inicio > @fechaInicio and est.fecha_inicio < @fechaFin )
								or
								(est.fecha_fin > @fechaInicio and est.fecha_fin < @fechaFin )
								or
								(est.fecha_inicio < @fechaInicio and est.fecha_fin > @fechaFin)
							)
							)
					) and id <> @idCrucero

	OPEN cruceros
	open viajesAReemplazar

	FETCH NEXT FROM cruceros INTO @idPosibleCrucero
	set @cruceroPuedeSerReemplazante = 0

	WHILE @@fetch_status = 0
	BEGIN

		FETCH NEXT FROM viajesAReemplazar INTO @fechaInicioViajeAReemplazar, @fechaFinViajeAReemplazar
			WHILE @@fetch_status = 0
			BEGIN

				if(SEGUNDA_VUELTA.cruceroDisponible(@idPosibleCrucero, @fechaInicioViajeAReemplazar, @fechaFinViajeAReemplazar) = 0)
				begin
					set @cruceroPuedeSerReemplazante = 0
					break
				end

			FETCH NEXT FROM viajesAReemplazar INTO @fechaInicioViajeAReemplazar, @fechaFinViajeAReemplazar
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
	CLOSE viajesAReemplazar
	DEALLOCATE viajesAReemplazar

	return @idPosibleCrucero
end





GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[crucerosConMasDiasFueraDeServicio]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[crucerosConMasDiasFueraDeServicio] (@anio int, @semestre int)
returns @rtnTable TABLE 
(
    -- columns returned by the function
    nombre nvarchar(255),
    cantidad int
)
begin
	declare @desde datetime2(3)
	declare @hasta datetime2(3)
	set @desde =  CONVERT(VARCHAR(4), @anio)+'-01-01' --Primer dia del anio
	set @hasta =  CONVERT(VARCHAR(4), @anio)+'-12-31' --Ultimo dia del anio
	if(@semestre = 1)
	begin
		set @hasta = (SELECT DATEADD(mm, -6, @hasta))
	end
	else
	begin
		set @desde = (SELECT DATEADD(mm, 6, @desde))
	end

	insert into @rtnTable
		select top 5 cru.nombre nombre, sum (
												DATEDIFF(
												day,
												case when (est.fecha_inicio > @desde) then est.fecha_inicio else @desde end,
												case when (est.fecha_fin < @hasta) then est.fecha_fin else @hasta end
												)
											) cantidad
		from SEGUNDA_VUELTA.Crucero cru
		join SEGUNDA_VUELTA.Estado_crucero est on est.id_crucero = cru.id
		join SEGUNDA_VUELTA.Tipo_estado_crucero tip on tip.id = est.id_tipo 
		where tip.nombre = 'Fuera de Servicio' and
			(est.fecha_inicio >= @desde or (est.fecha_inicio <= @desde and est.fecha_fin >= @desde)) and
			(est.fecha_fin <= @hasta or (est.fecha_inicio <= @hasta and est.fecha_fin >= @hasta))
		group by cru.nombre
		order by sum (
						DATEDIFF(
							day,
							case when (est.fecha_inicio > @desde) then est.fecha_inicio else @desde end,
							case when (est.fecha_fin < @hasta) then est.fecha_fin else @hasta end
						)
					) desc

	return
end



GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[precioRecorrido]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function SEGUNDA_VUELTA.[precioRecorrido] (@idRecorrido int)
returns numeric(18,2)
begin
	return (select sum(precio)
				from SEGUNDA_VUELTA.Puerto_recorrido
				where id_recorrido = @idRecorrido)
end


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[precioViaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[precioViaje] (@idViaje int, @idCabina int)
returns numeric(18,2)
begin
	declare @precioBase numeric(18,0)
	set @precioBase = ( select sum(pr.precio)
						 from SEGUNDA_VUELTA.Viaje via
						join SEGUNDA_VUELTA.Puerto_recorrido pr on pr.id_recorrido = via.id_recorrido
						where via.id = @idViaje
						)
	return @precioBase * (select porc_aumento 
							from SEGUNDA_VUELTA.Servicio s join SEGUNDA_VUELTA.Cabina c on s.id = c.id_servicio 
							where c.id = @idCabina )
end


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[recorridosConMasCabinasLibres]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[recorridosConMasCabinasLibres] (@anio int, @semestre int)
returns @rtnTable TABLE 
(
	codigo nvarchar(255),
    cantidad int
)
as
begin
	declare @desde datetime2(3)
	declare @hasta datetime2(3)
	set @desde = '01/01/'+ CONVERT(VARCHAR(4), @anio) --Primer dia del anio
	set @hasta = '31/12/'+ CONVERT(VARCHAR(4), @anio) --Ultimo dia del anio
	if(@semestre = 1)
	begin
		set @hasta = (SELECT DATEADD(mm, -6, @hasta))
	end
	else
	begin
		set @desde = (SELECT DATEADD(mm, 6, @desde))
	end
	insert into @rtnTable
	select top 5 rec.codigo,
				sum(via.cant_cabinas_libres) cantidad
		from SEGUNDA_VUELTA.Viaje via
		join SEGUNDA_VUELTA.Recorrido rec on via.id_recorrido = rec.id
		where via.fecha_inicio >= @desde and via.fecha_fin <= @hasta
		group by rec.id, rec.codigo
		order by sum(via.cant_cabinas_libres) desc

	return
end


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[recorridosConMasPasajes]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[recorridosConMasPasajes] (@anio int, @semestre int)
returns @rtnTable TABLE 
(
	codigo nvarchar(255),
    cantidad int
)
as
begin
	declare @desde datetime2(3)
	declare @hasta datetime2(3)
	set @desde = '01/01/'+ CONVERT(VARCHAR(4), @anio) --Primer dia del anio
	set @hasta = '31/12/'+ CONVERT(VARCHAR(4), @anio) --Ultimo dia del anio
	if(@semestre = 1)
	begin
		set @hasta = (SELECT DATEADD(mm, -6, @hasta))
	end
	else
	begin
		set @desde = (SELECT DATEADD(mm, 6, @desde))
	end
	insert into @rtnTable
	select top 5 rec.codigo, sum(via.cant_pasajes_comprados) cantidad
		from SEGUNDA_VUELTA.Viaje via
		join SEGUNDA_VUELTA.Recorrido rec on via.id_recorrido = rec.id
		where via.fecha_inicio >= @desde and via.fecha_inicio <= @hasta
		group by rec.id, rec.codigo
		order by sum(via.cant_pasajes_comprados) desc

	return
end


GO
/****** Object:  Table SEGUNDA_VUELTA.Cabina    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Cabina(
	[id_crucero] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[nro] [decimal](18, 0) NOT NULL,
	[piso] [decimal](18, 0) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[borrada] [bit] NULL,
 CONSTRAINT [PK_Cabina_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Cliente    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Cliente(
	[nombre] [nvarchar](255) NOT NULL,
	[apellido] [nvarchar](255) NOT NULL,
	[dni] [decimal](18, 0) NOT NULL,
	[telefono] [nvarchar](255) NOT NULL,
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
/****** Object:  Table SEGUNDA_VUELTA.Crucero    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Crucero(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[modelo] [nvarchar](50) NOT NULL,
	[id_marca] [int] NOT NULL,
	[fecha_alta] [datetime2](3) NULL,
	[identificador] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Estado_crucero    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Estado_crucero(
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
/****** Object:  Table SEGUNDA_VUELTA.Estado_pasaje    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Estado_pasaje(
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
/****** Object:  Table SEGUNDA_VUELTA.Funcionalidad    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Funcionalidad(
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Marca_Crucero    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Marca_Crucero(
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Marca_Crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Medio_pago    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Medio_pago(
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
/****** Object:  Table SEGUNDA_VUELTA.Pasaje    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Pasaje(
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
/****** Object:  Table SEGUNDA_VUELTA.Puerto    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Puerto(
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Puerto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Puerto_recorrido    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Puerto_recorrido(
	[id_puerto_origen] [int] NOT NULL,
	[id_puerto_destino] [int] NOT NULL,
	[id_recorrido] [int] NOT NULL,
	[precio] [numeric](18, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Recorrido    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Recorrido(
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
/****** Object:  Table SEGUNDA_VUELTA.Reserva    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Reserva(
	[id_cliente] [int] NOT NULL,
	[fecha] [datetime2](3) NOT NULL,
	[codigo] [decimal](18, 0) NOT NULL,
	[id_viaje] [int] NOT NULL,
	[id_cabina] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Rol    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Rol(
	[nombre] [nvarchar](255) NOT NULL,
	[inhabilitado] [bit] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Rol_funcionalidad    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Rol_funcionalidad(
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Servicio    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Servicio(
	[nombre] [nvarchar](255) NOT NULL,
	[porc_aumento] [decimal](18, 2) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.[Tarjeta_credito]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.[Tarjeta_credito](
	[nro_tarjeta] [int] NOT NULL,
	[codigo_seguridad] [decimal](3, 0) NOT NULL,
 CONSTRAINT [PK_Tarjeta_credito] PRIMARY KEY CLUSTERED 
(
	[nro_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Tipo_estado_crucero    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Tipo_estado_crucero(
	[nombre] [nvarchar](255) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Tipo_estado_crucero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Usuario    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Usuario(
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
/****** Object:  Table SEGUNDA_VUELTA.Usuario_rol    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Usuario_rol(
	[id_rol] [int] NOT NULL,
	[id_usuario] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table SEGUNDA_VUELTA.Viaje    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE SEGUNDA_VUELTA.Viaje(
	[id_recorrido] [int] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[fecha_inicio] [datetime2](3) NOT NULL,
	[fecha_fin] [datetime2](3) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_fin_estimada] [datetime2](3) NOT NULL,
	[cant_pasajes_comprados] [numeric](18, 0) NOT NULL,
	[cant_cabinas_libres] [numeric](18, 0) NOT NULL,
	[cancelado] [bit] NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[crucerosDisponibles]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[crucerosDisponibles] (@fechaInicio datetime2(3), @fechaFin datetime2(3))
returns table
as return (select id 
		from SEGUNDA_VUELTA.Crucero cru 
		where SEGUNDA_VUELTA.cruceroDisponible(id, @fechaInicio, @fechaFin) = 1
				)




GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[crucerosFinVidaUtil]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[crucerosFinVidaUtil] (@fecha datetime2(3))
returns table
return select est.id_crucero id
						from SEGUNDA_VUELTA.Estado_crucero est 
						join SEGUNDA_VUELTA.Tipo_estado_crucero tip on tip.id = est.id_tipo
						where tip.nombre = 'Fin de vida util' and est.fecha_inicio <= @fecha


GO
/****** Object:  UserDefinedFunction SEGUNDA_VUELTA.[crucerosFueraDeServicio]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function SEGUNDA_VUELTA.[crucerosFueraDeServicio] (@fecha datetime2(3))
returns table
return select est.id_crucero id
						from SEGUNDA_VUELTA.Estado_crucero est 
						join SEGUNDA_VUELTA.Tipo_estado_crucero tip on tip.id = est.id_tipo
						where tip.nombre = 'Fuera de Servicio' and (est.fecha_inicio <= @fecha or est.fecha_fin >= @fecha) 


GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Crucero]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Crucero] ON SEGUNDA_VUELTA.Crucero
(
	[identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Funcionalidad]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Funcionalidad] ON SEGUNDA_VUELTA.Funcionalidad
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Marca_Crucero]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Marca_Crucero] ON SEGUNDA_VUELTA.Marca_Crucero
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Puerto]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Puerto] ON SEGUNDA_VUELTA.Puerto
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_rol]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Nombre_unique_rol] ON SEGUNDA_VUELTA.Rol
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Servicio]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Servicio] ON SEGUNDA_VUELTA.Servicio
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tipo_estado_crucero]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tipo_estado_crucero] ON SEGUNDA_VUELTA.Tipo_estado_crucero
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_usuario]    Script Date: 30/06/2019 15:37:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Nombre_unique_usuario] ON SEGUNDA_VUELTA.Usuario
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje ADD  CONSTRAINT [DF_Viaje_cant_pasajes_comprados]  DEFAULT ((0)) FOR [cant_pasajes_comprados]
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje ADD  CONSTRAINT [DF_Viaje_cant_cabinas_libres]  DEFAULT ((0)) FOR [cant_cabinas_libres]
GO
ALTER TABLE SEGUNDA_VUELTA.Cabina  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Crucero] FOREIGN KEY([id_crucero])
REFERENCES SEGUNDA_VUELTA.Crucero ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Cabina CHECK CONSTRAINT [FK_Cabina_Crucero]
GO
ALTER TABLE SEGUNDA_VUELTA.Cabina  WITH CHECK ADD  CONSTRAINT [FK_Cabina_Servicio] FOREIGN KEY([id_servicio])
REFERENCES SEGUNDA_VUELTA.Servicio ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Cabina CHECK CONSTRAINT [FK_Cabina_Servicio]
GO
ALTER TABLE SEGUNDA_VUELTA.Cliente  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([id_usuario])
REFERENCES SEGUNDA_VUELTA.Usuario ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Cliente CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE SEGUNDA_VUELTA.Crucero  WITH CHECK ADD  CONSTRAINT [FK_Crucero_Marca_Crucero] FOREIGN KEY([id_marca])
REFERENCES SEGUNDA_VUELTA.Marca_Crucero ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Crucero CHECK CONSTRAINT [FK_Crucero_Marca_Crucero]
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_crucero  WITH CHECK ADD  CONSTRAINT [FK_Estado_crucero_Crucero] FOREIGN KEY([id_crucero])
REFERENCES SEGUNDA_VUELTA.Crucero ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_crucero CHECK CONSTRAINT [FK_Estado_crucero_Crucero]
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_crucero  WITH CHECK ADD  CONSTRAINT [FK_Estado_crucero_Tipo_estado_crucero] FOREIGN KEY([id_tipo])
REFERENCES SEGUNDA_VUELTA.Tipo_estado_crucero ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_crucero CHECK CONSTRAINT [FK_Estado_crucero_Tipo_estado_crucero]
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_pasaje  WITH CHECK ADD  CONSTRAINT [FK_Estado_pasaje_Pasaje] FOREIGN KEY([id_pasaje])
REFERENCES SEGUNDA_VUELTA.Pasaje ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Estado_pasaje CHECK CONSTRAINT [FK_Estado_pasaje_Pasaje]
GO
ALTER TABLE SEGUNDA_VUELTA.Medio_pago  WITH CHECK ADD  CONSTRAINT [FK_Medio_pago_Tarjeta_credito] FOREIGN KEY([nro_tarjeta])
REFERENCES SEGUNDA_VUELTA.[Tarjeta_credito] ([nro_tarjeta])
GO
ALTER TABLE SEGUNDA_VUELTA.Medio_pago CHECK CONSTRAINT [FK_Medio_pago_Tarjeta_credito]
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Cabina] FOREIGN KEY([id_cabina])
REFERENCES SEGUNDA_VUELTA.Cabina ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje NOCHECK CONSTRAINT [FK_Pasaje_Cabina]
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([id_cliente])
REFERENCES SEGUNDA_VUELTA.Cliente ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje NOCHECK CONSTRAINT [FK_Pasaje_Cliente]
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Medio_pago] FOREIGN KEY([id_medio_pago])
REFERENCES SEGUNDA_VUELTA.Medio_pago ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje NOCHECK CONSTRAINT [FK_Pasaje_Medio_pago]
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([id_viaje])
REFERENCES SEGUNDA_VUELTA.Viaje ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Pasaje NOCHECK CONSTRAINT [FK_Pasaje_Viaje]
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Puerto] FOREIGN KEY([id_puerto_origen])
REFERENCES SEGUNDA_VUELTA.Puerto ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido CHECK CONSTRAINT [FK_Puerto_recorrido_Puerto]
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Puerto1] FOREIGN KEY([id_puerto_destino])
REFERENCES SEGUNDA_VUELTA.Puerto ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido CHECK CONSTRAINT [FK_Puerto_recorrido_Puerto1]
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido  WITH CHECK ADD  CONSTRAINT [FK_Puerto_recorrido_Recorrido] FOREIGN KEY([id_recorrido])
REFERENCES SEGUNDA_VUELTA.Recorrido ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Puerto_recorrido CHECK CONSTRAINT [FK_Puerto_recorrido_Recorrido]
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cabina] FOREIGN KEY([id_cabina])
REFERENCES SEGUNDA_VUELTA.Cabina ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva CHECK CONSTRAINT [FK_Reserva_Cabina]
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([id_cliente])
REFERENCES SEGUNDA_VUELTA.Cliente ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Viaje] FOREIGN KEY([id_viaje])
REFERENCES SEGUNDA_VUELTA.Viaje ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Reserva CHECK CONSTRAINT [FK_Reserva_Viaje]
GO
ALTER TABLE SEGUNDA_VUELTA.Rol_funcionalidad  WITH CHECK ADD  CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES SEGUNDA_VUELTA.Funcionalidad ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Rol_funcionalidad CHECK CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad]
GO
ALTER TABLE SEGUNDA_VUELTA.Usuario_rol  WITH CHECK ADD  CONSTRAINT [FK_Usuario_rol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES SEGUNDA_VUELTA.Usuario ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Usuario_rol CHECK CONSTRAINT [FK_Usuario_rol_Usuario]
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Crucero] FOREIGN KEY([id_crucero])
REFERENCES SEGUNDA_VUELTA.Crucero ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje CHECK CONSTRAINT [FK_Viaje_Crucero]
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Recorrido] FOREIGN KEY([id_recorrido])
REFERENCES SEGUNDA_VUELTA.Recorrido ([id])
GO
ALTER TABLE SEGUNDA_VUELTA.Viaje CHECK CONSTRAINT [FK_Viaje_Recorrido]
GO
/****** Object:  Trigger SEGUNDA_VUELTA.[uniqueDni]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[uniqueDni] on SEGUNDA_VUELTA.Cliente instead of insert
as begin

	if(exists (select 1 from SEGUNDA_VUELTA.Cliente cli where cli.dni in (select i.dni from inserted i)))
	begin
		raiserror('clave duplicada', 12, 1)
		return
	end
	else
	begin
		insert into SEGUNDA_VUELTA.Cliente (nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario)
		select nombre, apellido, dni, direccion, telefono, mail, fecha_nacimiento, id_usuario from inserted
	end

	
end
GO
/****** Object:  Trigger SEGUNDA_VUELTA.[aumentarCantidadDePasajesEnViaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[aumentarCantidadDePasajesEnViaje] on SEGUNDA_VUELTA.Pasaje after insert
as begin 
	update via
		set cant_pasajes_comprados = cant_pasajes_comprados + (select count(*) from inserted where via.id = id_viaje)
		from SEGUNDA_VUELTA.Viaje via
		where via.id in (select id_viaje from inserted)
end



GO
/****** Object:  Trigger SEGUNDA_VUELTA.[disminuirCantidadCAbinasLibresEnViaje]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[disminuirCantidadCAbinasLibresEnViaje] on SEGUNDA_VUELTA.Pasaje after insert
as begin 
	update via
		set cant_cabinas_libres = cant_cabinas_libres - (select count(*) from inserted i where via.id = i.id_viaje)
		from SEGUNDA_VUELTA.Viaje via
		where via.id in (select i2.id_viaje from inserted i2)
end




GO
/****** Object:  Trigger SEGUNDA_VUELTA.[inhabilitarRecorrido]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger SEGUNDA_VUELTA.[inhabilitarRecorrido] on SEGUNDA_VUELTA.Recorrido instead of delete 
as begin
	update SEGUNDA_VUELTA.Recorrido	
		set inhabilitado = 1
		where id in (select id from deleted)
end 


GO
/****** Object:  Trigger SEGUNDA_VUELTA.[uniqueCodigo]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[uniqueCodigo] on SEGUNDA_VUELTA.Recorrido instead of insert, update
as begin

		if(exists (select 1 from deleted))
		begin
			--Update

			UPDATE rec
				SET rec.codigo = (select codigo from inserted i where i.id = rec.id),
					rec.destino = (select destino from inserted i where i.id = rec.id),
					rec.inhabilitado = (select inhabilitado from inserted i where i.id = rec.id),
					rec.inicio = (select inicio from inserted i where i.id = rec.id)
				FROM SEGUNDA_VUELTA.Recorrido rec
				WHERE rec.id in (select id from inserted i)
				end
		else
		begin
			--Insert
			if(exists (select 1 from SEGUNDA_VUELTA.Recorrido rec where rec.codigo in (select codigo from inserted)))
			begin
				raiserror('clave duplicada', 12, 1)
				return
			end
			else
			begin
			insert into SEGUNDA_VUELTA.Recorrido (codigo, inicio, inhabilitado, destino) 
			select codigo, inicio, inhabilitado, destino from inserted
			end
		end

	
end
GO
/****** Object:  Trigger SEGUNDA_VUELTA.[inhabilitarRol]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[inhabilitarRol] on SEGUNDA_VUELTA.Rol instead of delete 
as begin
	update SEGUNDA_VUELTA.Rol	
		set inhabilitado = 1
		where id in (select id from deleted)
	delete from SEGUNDA_VUELTA.Usuario_rol where id_rol in (select id from deleted)
end



GO
/****** Object:  Trigger SEGUNDA_VUELTA.[inhabilitarUsuario]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger SEGUNDA_VUELTA.[inhabilitarUsuario] on SEGUNDA_VUELTA.Usuario instead of delete 
as begin
	update SEGUNDA_VUELTA.Usuario	
		set inhabilitado = 1
		where id in (select id from deleted)
end 


GO
/****** Object:  Trigger SEGUNDA_VUELTA.[setCantidadCabinasLibres]    Script Date: 30/06/2019 15:37:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger SEGUNDA_VUELTA.[setCantidadCabinasLibres] on SEGUNDA_VUELTA.Viaje after insert
as begin

	update via
		set cant_cabinas_libres = (select count(*) 
										from SEGUNDA_VUELTA.Cabina cab 
										where cab.id_crucero = via.id_crucero
										and cab.borrada is null)
		from SEGUNDA_VUELTA.Viaje via
		where via.id in (select i.id from inserted i)

end


GO
exec SEGUNDA_VUELTA.reiniciarBase