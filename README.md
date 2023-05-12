# RestFullApiNetCoreUdemy
1. Clonar repositorio
2. Tener instalado, visual studio 2022 o que tenga net6
3. Tener instalado sql server y sql management
4. Crear la base de datos con el nombre "CursoWebApis" solo crearla y nada màs
5. Compilar el proyecto que funcione todo bien y se visualize el swagger
6. Cambiar la conexiòn de la bd del archivo appsettings.Development.json
	(lo puede visualizar en: menu>ver>explorador de objetos de SQL server> click derecho en la base de datos que crearon>propiedades>ahì se encuentra propiedad que dice conexion string o algo asì)
7. Ejecutar la migraciòn: "Update-Migration"
8. Listo el proyecto para usarse
9. Nota: para el cargado de datos
	- Primero debe agregar un usuario y contraseña
	- Debe hacerlo admin
	- Debe logearse y con ese token autenticarse para el consumo de los endpoint protegidos
	- Puede crear un Autor
	- 
