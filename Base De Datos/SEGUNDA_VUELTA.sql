USE [master]
GO
/****** Object:  Database [SEGUNDA_VUELTA]    Script Date: 16/05/2019 18:41:57 ******/
CREATE DATABASE [SEGUNDA_VUELTA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SEGUNDA_VUELTA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MANTEQUITA\MSSQL\DATA\SEGUNDA_VUELTA.mdf' , SIZE = 91136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SEGUNDA_VUELTA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MANTEQUITA\MSSQL\DATA\SEGUNDA_VUELTA_log.ldf' , SIZE = 321088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [SEGUNDA_VUELTA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SEGUNDA_VUELTA]
GO
/****** Object:  UserDefinedTableType [dbo].[ids]    Script Date: 16/05/2019 18:41:57 ******/
CREATE TYPE [dbo].[ids] AS TABLE(
	[id] [int] NULL
)
GO
/****** Object:  Table [dbo].[Cabina]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabina](
	[id_crucero] [int] NOT NULL,
	[ocupada] [nvarchar](255) NULL,
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/05/2019 18:41:57 ******/
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
	[mail] [nvarchar](255) NOT NULL,
	[fecha_nacimiento] [datetime2](3) NOT NULL,
	[id_usuario] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Crucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Estado_crucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Estado_pasaje]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_pasaje](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[observacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_Estado_pasaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Marca_Crucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Medio_pago]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Pasaje]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasaje](
	[id_cliente] [int] NOT NULL,
	[id_medio_pago] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_estado] [int] NOT NULL,
	[fecha] [datetime2](3) NOT NULL,
	[id_cabina] [int] NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[id_viaje] [int] NULL,
	[codigo] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Puerto]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Puerto_recorrido]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puerto_recorrido](
	[id_puerto_origen] [int] NOT NULL,
	[id_puerto_destino] [int] NOT NULL,
	[id_recorrido] [int] NOT NULL,
	[fecha_llegada] [datetime2](3) NULL,
	[fecha_salida] [datetime2](3) NULL,
	[fecha_estimada_llegada] [datetime2](3) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recorrido]    Script Date: 16/05/2019 18:41:57 ******/
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
	[precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Recorrido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[recorridos]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recorridos](
	[codigo] [int] NULL,
	[inicio] [nvarchar](255) NULL,
	[destino] [nvarchar](255) NULL,
	[precio] [decimal](18, 2) NULL,
	[id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[nombre] [nvarchar](255) NOT NULL,
	[inhabilitado] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol_funcionalidad]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_funcionalidad](
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Tarjeta_credito]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Tipo_estado_crucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[nombre] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[cant_intentos_fallido] [numeric](18, 0) NOT NULL,
	[id_rol] [int] NOT NULL,
	[inhabilitado] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viaje](
	[id_recorrido] [int] NOT NULL,
	[id_crucero] [int] NOT NULL,
	[fecha_inicio] [datetime2](3) NOT NULL,
	[fecha_fin] [datetime2](3) NOT NULL,
	[cant_cabinas_libres] [decimal](18, 0) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_fin_estimada] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[viajes]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[viajes](
	[rec_codigo] [int] NULL,
	[rec_inicio] [nvarchar](255) NULL,
	[rec_destino] [nvarchar](255) NULL,
	[via_id] [int] NULL,
	[via_crucero] [int] NULL,
	[via_fecha_inicio] [datetime2](3) NULL,
	[via_fecha_fin] [datetime2](3) NULL,
	[via_fecha_fin_estimada] [datetime2](3) NULL,
	[cru_nombre] [nvarchar](255) NULL,
	[cru_id] [int] NULL,
	[cab_piso] [int] NULL,
	[cab_nro] [int] NULL,
	[cab_id] [int] NULL,
	[precio] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Crucero]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Crucero] ON [dbo].[Crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Estado_pasaje]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Estado_pasaje] ON [dbo].[Estado_pasaje]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Funcionalidad]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Funcionalidad] ON [dbo].[Funcionalidad]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Marca_Crucero]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Marca_Crucero] ON [dbo].[Marca_Crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pasaje]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pasaje] ON [dbo].[Pasaje]
(
	[id_cliente] ASC,
	[id_estado] ASC,
	[fecha] ASC,
	[id_cabina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Puerto]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Puerto] ON [dbo].[Puerto]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_rol]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Nombre_unique_rol] ON [dbo].[Rol]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Servicio]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Servicio] ON [dbo].[Servicio]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tipo_estado_crucero]    Script Date: 16/05/2019 18:41:57 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tipo_estado_crucero] ON [dbo].[Tipo_estado_crucero]
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Nombre_unique_usuario]    Script Date: 16/05/2019 18:41:57 ******/
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
ALTER TABLE [dbo].[Pasaje]  WITH NOCHECK ADD  CONSTRAINT [FK_Pasaje_Estado_pasaje] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estado_pasaje] ([id])
GO
ALTER TABLE [dbo].[Pasaje] NOCHECK CONSTRAINT [FK_Pasaje_Estado_pasaje]
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
ALTER TABLE [dbo].[Rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad] FOREIGN KEY([id_funcionalidad])
REFERENCES [dbo].[Funcionalidad] ([id])
GO
ALTER TABLE [dbo].[Rol_funcionalidad] CHECK CONSTRAINT [FK_Rol_funcionalidad_Funcionalidad]
GO
ALTER TABLE [dbo].[Rol_funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_funcionalidad_Rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Rol_funcionalidad] CHECK CONSTRAINT [FK_Rol_funcionalidad_Rol]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
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
/****** Object:  StoredProcedure [dbo].[altaRecorrido]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[altaRecorrido] @codigo int,
						@inicio int, 
						@fin int, 
						@precio decimal(18, 2),
						@puertos dbo.ids readonly

as begin
begin try
	begin transaction

	declare @ids dbo.ids
	declare @idRecorrido int
	
	if((select count(*) from @ids) < 2)
	begin 
	raiserror('Debe seleccionar como minimo dos puertos', 12,1)
	end

	insert into Recorrido (codigo, inicio, inhabilitado, destino, precio) values (@codigo, @inicio, 'inhabilitado', @fin, @precio)

	set @idRecorrido = (select SCOPE_IDENTITY()) 

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
	raiserror('Error al cargar el recorrido', 12,1)
	rollback
end catch
end


GO
/****** Object:  StoredProcedure [dbo].[cargarClientes]    Script Date: 16/05/2019 18:41:57 ******/
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
				null
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
/****** Object:  StoredProcedure [dbo].[cargarCrucerosYCabinas]    Script Date: 16/05/2019 18:41:57 ******/
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
		insert into Cabina (id_crucero, ocupada, id_servicio, nro, piso)
			select 
				@idCrucero,
				null,
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
/****** Object:  StoredProcedure [dbo].[cargarEstadosCrucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[CargarEstadosPasaje]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[CargarEstadosPasaje] AS
BEGIN
begin try
	begin transaction
	insert into Estado_pasaje (nombre, observacion)
		values ('reservado', null) , ('pagado', null)
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los estados del pasaje', 12,1)
	rollback
end catch
END

GO
/****** Object:  StoredProcedure [dbo].[cargarFuncionalidades]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarMarcasCrucero]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarMediosDePago]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarPasajes]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[cargarPasajes]  AS
BEGIN
begin try
	begin transaction
	declare @idEstado int
	declare @idMedioPago int
	set @idEstado = (select id from Estado_pasaje where nombre = 'Reservado')
	set @idMedioPago = (select id from Medio_pago where nombre = 'efectivo')

	/*CREATE TABLE recorridos (
						codigo int, 
						inicio nvarchar(255), 
						destino nvarchar(255), 
						precio decimal(18,2),
						id int
						);

	insert into recorridos (codigo, inicio, destino, precio, id)
		select rec.codigo, rec.inicio, rec.destino, pure.precio, rec.id
			from Recorrido rec
			join Puerto_recorrido pure on pure.id_recorrido = rec.id*/
			
	CREATE TABLE pasaje_aux (
						rec_codigo int, 
						rec_inicio nvarchar(255), 
						rec_destino nvarchar(255), 
						via_id int, 
						via_crucero int, 
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
						rec_inicio, 
						rec_destino, 
						via_id, 
						via_crucero, 
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
				via.id, 
				via.id_crucero, 
				via.fecha_inicio, 
				via.fecha_fin, 
				via.fecha_fin_estimada, 
				cru.nombre, 
				cru.id , 
				cab.piso, 
				cab.nro, 
				cab.id, 
				rec.precio * srv.porc_aumento
			from Recorrido rec
			join Viaje via on via.id_recorrido = rec.id
			join Crucero cru on via.id_crucero = cru.id
			join Cabina cab on cab.id_crucero = cru.id
			join Servicio srv on srv.id = cab.id_servicio
			group by rec.codigo, 
						rec.inicio, 
						rec.destino, 
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
						rec.precio, 
						srv.porc_aumento

	
	insert into Pasaje (id_cliente, id_medio_pago, id_estado, fecha, id_cabina, id_viaje, codigo, precio)
		select 
			cli.id,
			@idMedioPago,
			@idEstado,
			RESERVA_FECHA,
			via.cab_id,
			via.via_id,
			RESERVA_CODIGO,
			via.precio
		from GD1C2019.gd_esquema.Maestra
		join Cliente cli on cli.dni = CLI_DNI and cli.nombre = CLI_NOMBRE and cli.apellido = CLI_APELLIDO
		join Puerto puerto_origen on puerto_origen.nombre = PUERTO_DESDE
		join Puerto puerto_destino on puerto_destino.nombre = PUERTO_HASTA
		join pasaje_aux via on via.rec_codigo = RECORRIDO_CODIGO 
							and via.rec_inicio = puerto_origen.id 
							and via.rec_destino = puerto_destino.id
							and via.via_fecha_inicio = FECHA_SALIDA
							and via.via_fecha_fin = FECHA_LLEGADA
							and via.via_fecha_fin_estimada = FECHA_LLEGADA_ESTIMADA
							and cru_nombre = CRUCERO_IDENTIFICADOR and cab_nro = CABINA_NRO and cab_piso = CABINA_PISO
		where RESERVA_CODIGO is not null

	drop table pasaje_aux
	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los pasajes', 12,1)
	rollback
end catch
END

/**/



GO
/****** Object:  StoredProcedure [dbo].[cargarPuertoRecorrido]    Script Date: 16/05/2019 18:41:57 ******/
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

	insert into Puerto_recorrido (id_puerto_origen, id_puerto_destino, id_recorrido) 
		select r.inicio, r.destino, r.id
		from Recorrido r
		join Puerto as p1 on r.inicio = p1.id
		join Puerto as p2 on r.destino = p2.id
		join GD1C2019.gd_esquema.Maestra
			on RECORRIDO_CODIGO = r.codigo and p1.nombre = PUERTO_DESDE and p2.nombre = PUERTO_HASTA
			group by r.inicio, r.destino, r.id

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los recorridos', 12,1)
	rollback
end catch
END



GO
/****** Object:  StoredProcedure [dbo].[CargarPuertos]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarRecorridos]    Script Date: 16/05/2019 18:41:57 ******/
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

	insert into Recorrido (codigo, inicio, destino, inhabilitado, precio) 
		select RECORRIDO_CODIGO, p1.id, p2.id, null, RECORRIDO_PRECIO_BASE
		from GD1C2019.gd_esquema.Maestra
		join Puerto as p1 on PUERTO_DESDE = p1.nombre 
		join Puerto as p2 on PUERTO_HASTA = p2.nombre
		group by RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA, p1.nombre, p1.id, p2.nombre, p2.id, RECORRIDO_PRECIO_BASE

	commit
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar los recorridos', 12,1)
	rollback
end catch
END




GO
/****** Object:  StoredProcedure [dbo].[cargarRol_funcionalidad]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cargarRol_funcionalidad]
AS
BEGIN

	declare @idAdmin int
	declare @idCliente int
	set @idAdmin = (select id from Rol where nombre = 'administrador')
	set @idCliente = (select id from Rol where nombre = 'cliente')

	insert into Rol_Funcionalidad (id_rol, id_funcionalidad)
		select @idAdmin, id from Funcionalidad

	insert into Rol_Funcionalidad (id_rol, id_funcionalidad)
		select @idCliente, id from Funcionalidad
		where nombre = 'reservar_viaje' or nombre = 'pagar_reserva'
END


GO
/****** Object:  StoredProcedure [dbo].[cargarRoles]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarServiciosCabina]    Script Date: 16/05/2019 18:41:57 ******/
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
/****** Object:  StoredProcedure [dbo].[cargarUsuarios]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cargarUsuarios] AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	insert into Usuario (nombre, password, cant_intentos_fallido, id_rol, inhabilitado)
	 values ('admin', HASHBYTES('SHA2_256',convert(nvarchar(255),'w23e')), 0, (select id from Rol where nombre = 'administrador'), null)
	
END


GO
/****** Object:  StoredProcedure [dbo].[cargarViajes]    Script Date: 16/05/2019 18:41:57 ******/
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

	insert into Viaje ( id_recorrido, id_crucero, fecha_inicio, fecha_fin, fecha_fin_estimada, cant_cabinas_libres ) 
		select r.id, 
				cru1.id,
				g1.FECHA_SALIDA, 
				g1.FECHA_LLEGADA, 
				g1.FECHA_LLEGADA_ESTIMADA, 
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
				)
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
/****** Object:  StoredProcedure [dbo].[reiniciarBase]    Script Date: 16/05/2019 18:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reiniciarBase]
AS
BEGIN

begin transaction t1
begin try

delete from Cliente
delete from Rol_funcionalidad
delete from Funcionalidad
delete from Usuario
delete from Rol
delete from Estado_pasaje
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
delete from Puerto

commit transaction t1
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al elimnar', 12,1)
	rollback transaction t1
end catch

begin transaction t2
begin try


exec cargarFuncionalidades
exec cargarRoles
exec cargarRol_funcionalidad
exec cargarUsuarios
exec cargarClientes
exec cargarEstadosPasaje
exec cargarEstadosCrucero
exec cargarMarcasCrucero
exec cargarServiciosCabina
exec cargarCrucerosYCabinas
exec cargarPuertos
exec cargarRecorridos
exec cargarPuertoRecorrido
exec cargarViajes
exec cargarMediosDePago
exec cargarPasajes

commit transaction t2
end try
begin catch
print(ERROR_MESSAGE())
	raiserror('Error al cargar', 12,1)
	rollback transaction t2
end catch

END

GO
USE [master]
GO
ALTER DATABASE [SEGUNDA_VUELTA] SET  READ_WRITE 
GO
