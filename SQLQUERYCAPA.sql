
CREATE TABLE Autor (
	IdAutor int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre varchar(100) NOT NULL
);

CREATE TABLE Categoria (
	IdCategoria int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre varchar(100) NOT NULL
);

CREATE TABLE EstadoSocio (
	IdEstadoSocio int NOT NULL PRIMARY KEY,
	Descripcion varchar(100) NOT NULL
);

CREATE TABLE EstadoPrestamo (
	IdEstadoPrestamo int NOT NULL PRIMARY KEY,
	Descripcion varchar(100) NOT NULL
);

CREATE TABLE EstadoLibro (
	IdEstadoLibro int NOT NULL PRIMARY KEY,
	Descripcion varchar(100) NOT NULL
);

CREATE TABLE Libro (
	IdLibro int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Titulo varchar(200) NOT NULL,
	Descripcion varchar(500) NOT NULL,
	ISBN varchar(13) NOT NULL,
	IdAutor int NOT NULL --FOREIGN KEY REFERENCES Autor(IdAutor),
	CONSTRAINT FK_AutorLibro FOREIGN KEY (IdAutor) REFERENCES Autor(IdAutor),
	IdCategoria int NOT NULL
	CONSTRAINT FK_CategoriaLibro FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
	IdEstadoLibro int NOT NULL
	CONSTRAINT FK_EstadoLibro FOREIGN KEY (IdEstadoLibro) REFERENCES EstadoLibro(IdEstadoLibro)
);

-- agregar una columna
ALTER TABLE Libro
ADD IdEstado smallint NOT NULL;

-- borrar una columna
ALTER TABLE Libro
DROP COLUMN IdEstado;

-- Agregar una foreign key porque no anda :(
ALTER TABLE Libro
ADD CONSTRAINT FK_EstadoLibro
FOREIGN KEY (IdEstado) REFERENCES Estado(IdEstado);

-- borrar tablas
DROP TABLE Autor
DROP TABLE Categoria
DROP TABLE Estado
DROP TABLE Libro

CREATE TABLE Socio (
	IdSocio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre varchar(100) NOT NULL,
	Apellido varchar(100) NOT NULL,
	NombreUsuario varchar(100) NOT NULL,
	IdEstadoSocio int NOT NULL
	CONSTRAINT FK_EstadoSocio FOREIGN KEY (IdEstadoSocio) REFERENCES EstadoSocio(IdEstadoSocio)
);

DROP TABLE Socio

ALTER TABLE Socio
DROP COLUMN IdEstado;

CREATE TABLE Prestamo (
	IdPrestamo int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FechaInicio datetime NOT NULL,
	FechaFinalizacion datetime NOT NULL,
	FechaDevolucion datetime,
	IdSocio int NOT NULL
	CONSTRAINT FK_PrestamoSocio FOREIGN KEY (IdSocio) REFERENCES Socio(IdSocio),
	IdLibro int NOT NULL
	CONSTRAINT FK_PrestamoLibro FOREIGN KEY (IdLibro) REFERENCES Libro(IdLibro),
	IdEstadoPrestamo int NOT NULL
	CONSTRAINT FK_PrestamoEstado FOREIGN KEY (IdEstadoPrestamo) REFERENCES EstadoPrestamo(IdEstadoPrestamo)
);

DROP TABLE Prestamo

select * from socio

select * from EstadoSocio

insert into EstadoSocio values (1,'Activo')
insert into EstadoSocio values (2,'Inactivo')

insert into EstadoPrestamo values (1,'Activo')
insert into EstadoPrestamo values (2,'Inactivo')

insert into EstadoLibro values (1,'Disponible')
insert into EstadoLibro values (2,'Prestado')





