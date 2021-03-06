USE [master]
GO
/****** Object:  Database [db_libros]    Script Date: 14/03/2022 02:42:01 a. m. ******/
CREATE DATABASE [db_libros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_libros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_libros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_libros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\db_libros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_libros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_libros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_libros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_libros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_libros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_libros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_libros] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_libros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_libros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_libros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_libros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_libros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_libros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_libros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_libros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_libros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_libros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_libros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_libros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_libros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_libros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_libros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_libros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_libros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_libros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_libros] SET  MULTI_USER 
GO
ALTER DATABASE [db_libros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_libros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_libros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_libros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_libros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_libros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_libros] SET QUERY_STORE = OFF
GO
USE [db_libros]
GO
/****** Object:  Table [dbo].[tbl_libros]    Script Date: 14/03/2022 02:42:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_libros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[autor] [nchar](100) NULL,
	[titulo_libro] [nchar](100) NULL,
	[fecha_publicacion] [date] NULL,
	[editorial] [nchar](100) NULL,
 CONSTRAINT [PK_tbl_libros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Borrar_Libro_Por_Autor]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Borrar_Libro_Por_Autor]
	@Autor nchar(100)
AS
BEGIN
	DELETE FROM [dbo].[tbl_libros]
      WHERE autor = @Autor
END
GO
/****** Object:  StoredProcedure [dbo].[Borrar_Libros_Por_Editorial]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Borrar_Libros_Por_Editorial] 
	-- Add the parameters for the stored procedure here
	@Editorial nchar(100)
AS
BEGIN
	DELETE FROM [dbo].[tbl_libros]
      WHERE editorial = @Editorial
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Libros_Por_Autor]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Roberto Galicia>
-- Create date: <Create Date,,09/03/2022>
-- Description:	<Description,,Prueba Tecnica>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_Libros_Por_Autor]
	-- Add the parameters for the stored procedure here
	@autor             nchar(100)
AS
BEGIN
	SELECT   *
	FROM     dbo.tbl_libros 
	WHERE    autor = @autor 
	ORDER BY autor
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_libros_Por_Autor_Y_Fecha_Publicacion]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_libros_Por_Autor_Y_Fecha_Publicacion]
	@Autor             nchar(100),
	@Fecha_Publicacion date
AS
BEGIN
	SELECT * 
	FROM dbo.tbl_libros 
	WHERE autor = @Autor AND fecha_publicacion = @Fecha_Publicacion
	ORDER BY autor
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Libros_Por_Editorial]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_Libros_Por_Editorial] 
	-- Add the parameters for the stored procedure here
	@Editorial nchar(100)
AS
BEGIN
	SELECT * 
	FROM dbo.tbl_libros 
	WHERE editorial = @Editorial 
	ORDER BY editorial
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Libros_Por_Fecha_Publicacion]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_Libros_Por_Fecha_Publicacion] 
	-- Add the parameters for the stored procedure here
	@Fecha_Publicacion date
AS
BEGIN
	SELECT * FROM dbo.tbl_libros WHERE fecha_publicacion = @Fecha_Publicacion ORDER BY fecha_publicacion
END
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Libros_Por_Titulo]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Buscar_Libros_Por_Titulo]
	@titulo nchar(100)
AS
BEGIN
	SELECT * FROM dbo.tbl_libros WHERE titulo_libro = @titulo ORDER BY titulo_libro
END
GO
/****** Object:  StoredProcedure [dbo].[Crear_Libro]    Script Date: 14/03/2022 02:42:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Roberto Galicia>
-- Create date: <Create Date,,09/03/2022>
-- Description:	<Description,,Prueba tecnica>
-- =============================================
CREATE PROCEDURE [dbo].[Crear_Libro]
	-- Add the parameters for the stored procedure here
	@autor             nchar(100),
	@titulo_libro      nchar(100),
	@fecha_publicacion date,
	@editorial         nchar(100)
AS
BEGIN
	INSERT INTO [dbo].[tbl_libros]
           ([autor]
           ,[titulo_libro]
           ,[fecha_publicacion]
           ,[editorial])
     VALUES
           (@autor
           ,@titulo_libro
           ,@fecha_publicacion
           ,@editorial)
END
GO
USE [master]
GO
ALTER DATABASE [db_libros] SET  READ_WRITE 
GO
