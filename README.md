# Prueba Tecnica  :+1:

## Requerimientos 

- SQL Server Express 2019
- .NET Core 3.1
- Nodejs

## Desplegar API en el IIS

1. Click derecho al proyecto 
2. Seleccionar Publicar
3. Seleccionamos la opcion: Desplegar desde carpeta
4. Seleccionamos la ubicacion de la carpeta donde se crearan los archivos compilados de la api
5. Le damos finalizar y Publicar.


6. Abrimos el Administrador del IIS
7. Seleccionamos un sitio web a donde queremos deplegar la api
8. Seleccionamos opcion: Agregar Aplicacion
9. Seleccionamos un alias, grupo de aplicaciones y colocamos la ubicacion de la carperta donde estan los archivos compilados del api 
10. Le damos aceptar y ya esta lista la api en el IIS

## Antes de correr el proyecto de Reactjs

```
  cd front-end
  npm install
```
## Ejecutar el proyecto de Reactjs
```
  npm run dev
```
### Nota
los end-ponits api que se usan en react, son los de produccion en el IIS.

