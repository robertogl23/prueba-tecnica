USE [db_libros]
GO


DECLARE @RC int

DECLARE @autor1 nchar(100) = 'Craig Whitlock'
DECLARE @titulo_libro1 nchar(100) = 'Los papeles de Afganistán'
DECLARE @fecha_publicacion1 date = '2022/03/09'
DECLARE @editorial1 nchar(100) = 'Crítica México'

DECLARE @autor2 nchar(100) = 'Natasha Preston'
DECLARE @titulo_libro2 nchar(100) = 'La noche en que todo cambió'
DECLARE @fecha_publicacion2 date = '2022/03/09'
DECLARE @editorial2 nchar(100) = 'Destino Infantil & Juvenil México'

DECLARE @autor3 nchar(100) = 'Zygmunt Bauman'
DECLARE @titulo_libro3 nchar(100) = 'Mundo consumo'
DECLARE @fecha_publicacion3 date = '2022/03/09'
DECLARE @editorial3 nchar(100) = 'Paidos México'

DECLARE @autor4 nchar(100) = 'Alvydas Slepikas'
DECLARE @titulo_libro4 nchar(100) = 'Bajo la sombra de los lobos'
DECLARE @fecha_publicacion4 date = '2022/03/09'
DECLARE @editorial4 nchar(100) = 'Tusquets México'

DECLARE @autor5 nchar(100) = 'Alejandro Vázquez'
DECLARE @titulo_libro5 nchar(100) = 'El corredor'
DECLARE @fecha_publicacion5 date = '2022/03/09'
DECLARE @editorial5 nchar(100) = 'Literatura Random House'

DECLARE @autor6 nchar(100) = 'Valentine Penrose'
DECLARE @titulo_libro6 nchar(100) = 'La condesa sangrienta'
DECLARE @fecha_publicacion6 date = '2022/03/09'
DECLARE @editorial6 nchar(100) = 'Perla Ediciones'

DECLARE @autor7 nchar(100) = 'Madeline Miller'
DECLARE @titulo_libro7 nchar(100) = 'La canción de Aquiles'
DECLARE @fecha_publicacion7 date = '2022/03/09'
DECLARE @editorial7 nchar(100) = 'Alianza de Novela'

DECLARE @autor8 nchar(100) = 'Yuval Noah Harari'
DECLARE @titulo_libro8 nchar(100) = 'Sapiens. De animales a dioses'
DECLARE @fecha_publicacion8 date = '2022/03/09'
DECLARE @editorial8 nchar(100) = 'Debate'

DECLARE @autor9 nchar(100) = 'Alberto Villarreal'
DECLARE @titulo_libro9 nchar(100) = 'Anoche en las trincheras'
DECLARE @fecha_publicacion9 date = '2022/03/09'
DECLARE @editorial9 nchar(100) = 'Planeta México'

DECLARE @autor10 nchar(100) = 'Alberto Villarreal'
DECLARE @titulo_libro10 nchar(100) = 'Todo lo que fuimos'
DECLARE @fecha_publicacion10 date = '2022/03/09'
DECLARE @editorial10 nchar(100) = 'Planeta México'




EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor1
  ,@titulo_libro1
  ,@fecha_publicacion1
  ,@editorial1

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor2
  ,@titulo_libro2
  ,@fecha_publicacion2
  ,@editorial2

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor3
  ,@titulo_libro3
  ,@fecha_publicacion3
  ,@editorial3

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor4
  ,@titulo_libro4
  ,@fecha_publicacion4
  ,@editorial4

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor5
  ,@titulo_libro5
  ,@fecha_publicacion5
  ,@editorial5

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor6
  ,@titulo_libro6
  ,@fecha_publicacion6
  ,@editorial6

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor7
  ,@titulo_libro7
  ,@fecha_publicacion7
  ,@editorial7

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor8
  ,@titulo_libro8
  ,@fecha_publicacion8
  ,@editorial8

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor9
  ,@titulo_libro9
  ,@fecha_publicacion9
  ,@editorial9

EXECUTE @RC = [dbo].[Crear_Libro] 
   @autor10
  ,@titulo_libro10
  ,@fecha_publicacion10
  ,@editorial10

GO


