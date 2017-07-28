CREATE TABLE Penalizacion (
	IdPenalizacion int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FechaInicio datetime NOT NULL,
	FechaCumplimiento datetime,
	IdPrestamo int NOT NULL
	CONSTRAINT FK_PenalizacionPrestamo REFERENCES Prestamo(IdPrestamo),
);

DROP TABLE Penalizacion

CREATE TABLE Cuarentena (
	IdCuarentena int NOT NULL PRIMARY KEY,
	FechaFinalizacion datetime NOT NULL,
	IdPenalizacion int NOT NULL
	CONSTRAINT FK_CuarentenaPenalizacion REFERENCES Penalizacion(IdPenalizacion)
);

CREATE TABLE Factura (
	IdFactura int NOT NULL PRIMARY KEY,
	FechaRecepcion datetime,
	IdPenalizacion int NOT NULL
	CONSTRAINT FK_FacturaPenalizacion REFERENCES Penalizacion(IdPenalizacion)
);

DROP TABLE Cuarentena
DROP TABLE Factura

CREATE TABLE Constantes (
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	clave varchar(100) NOT NULL,
	valor varchar(100) NOT NULL,
	Descripcion varchar(100)
);

DROP TABLE Constantes

select * from Constantes

insert into Constantes values ('MAXIMO_PRESTAMOS', '2', 'Es el maximo de prestamos que puede realizar un socio')
insert into Constantes values ('LAPSO_FACTURAS', '10', 'Es la cantidad de dias que pasa para que se cobre otra factura al socio')