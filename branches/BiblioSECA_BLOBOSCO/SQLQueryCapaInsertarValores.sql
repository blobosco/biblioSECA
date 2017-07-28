select * from Autor

select * from Categoria

select * from Socio

select * from Libro

select * from EstadoLibro

select * From Prestamo

insert into Autor values ('Juan')
insert into Autor values ('Jose')
insert into Autor values ('Martin')
insert into Autor values ('Pablo')
insert into Autor values ('Gabriel')
insert into Autor values ('Luis')
insert into Autor values ('Miguel')
insert into Autor values ('Jorge')
insert into Autor values ('Alejandro')

insert into Categoria values ('Ciencia Ficcion')
insert into Categoria values ('Terror')
insert into Categoria values ('Suspenso')
insert into Categoria values ('Historia')
insert into Categoria values ('Comedia')
insert into Categoria values ('Drama')
insert into Categoria values ('Policial')
insert into Categoria values ('Romantico')

insert into Libro values ('Harry Potter', 'Harry Potter es un mago', '11-4566-556-1', 50, 50, 1)
insert into Libro values ('50 leguas de viaje submarino', 'Viajar por el Oceano', '11-4578-786-1', 50, 50, 1)
insert into Libro values ('Libro3', 'Descripcion', '11-4566-558-1', 51, 53, 1)
insert into Libro values ('Libro4', 'Descripcion', '11-4566-559-1', 51, 53, 1)
insert into Libro values ('Libro5', 'Descripcion', '11-4566-560-1', 52, 53, 1)
insert into Libro values ('Libro6', 'Descripcion', '11-4566-561-1', 52, 54, 1)
insert into Libro values ('Libro7', 'Descripcion', '11-4566-562-1', 54, 53, 1)
insert into Libro values ('Libro8', 'Descripcion', '11-4566-563-1', 56, 51, 1)
insert into Libro values ('Libro9', 'Descripcion', '11-4566-564-1', 57, 56, 1)
insert into Libro values ('Libro10', 'Descripcion', '11-4566-564-1', 51, 52, 2)
insert into Libro values ('Libro11', 'Descripcion', '11-4566-564-1', 57, 54, 2)
insert into Libro values ('Libro12', 'Descripcion', '11-4566-564-1', 50, 53, 2)
insert into Libro values ('Libro13', 'Descripcion', '11-4566-564-1', 50, 53, 2)
insert into Libro values ('El Libro De La Selva', 'Descripcion', '11-4568-564-1', 54, 54, 1)

select * from Socio

insert into Socio values ('Juan', 'Perez', 'jperez', 1)
insert into Socio values ('Jose', 'Lopez', 'jlopez', 2)
insert into Socio values ('Luis', 'Ramirez', 'lramirez', 1)
insert into Socio values ('Gaston', 'Gonzalez', 'ggonzalez', 2)
insert into Socio values ('Rodrigo', 'Diaz', 'rdiaz', 1)
insert into Socio values ('Jonathan', 'Rodriguez', 'jrodriguez', 1)
insert into Socio values ('Federico', 'Hernandez', 'fhernandez', 2)
insert into Socio values ('Nicolas', 'Cordoba', 'ncordoba', 1)
insert into Socio values ('Daniel', 'Fernandez', 'dfernandez', 1)
insert into Socio values ('Jose', 'Lopez', 'jlopez', 2)
insert into Socio values ('Jose', 'Diazz', 'jdiaz', 1)
insert into Socio values ('Jose', 'Juarez', 'jjuarez', 1)

insert into Prestamo values ('20170726', '20170728', null, 45, 50, 1)
insert into Prestamo values ('20170726', '20170728', null, 47, 51, 1)
insert into Prestamo values ('20170726', '20170728', null, 49, 52, 1)
insert into Prestamo values ('20170726', '20170728', null, 50, 65, 1)
insert into Prestamo values ('20170726', '20170728', null, 55, 66, 1)
insert into Prestamo values ('20170726', '20170728', null, 56, 67, 1)
insert into Prestamo values ('20170726', '20170728', null, 56, 68, 1)
insert into Prestamo values ('20170724', '20170726', '20170726', 52, 53, 2)
insert into Prestamo values ('20170724', '20170726', '20170726', 53, 54, 2)
insert into Prestamo values ('20170724', '20170726', '20170726', 54, 55, 2)

update Prestamo set FechaDevolucion = '20170728' where IdPrestamo = 52

select * from Cuarentena
select * from Factura
select * from Penalizacion

update Prestamo set FechaDevolucion = null where IdPrestamo = 54

insert into Penalizacion values ('20170724', '20170726', 52)
insert into Penalizacion values ('20170724', '20170726', 53)
insert into Penalizacion values ('20170724', '20170726', 54)

insert into Cuarentena values (1, '20170904', 20)
insert into Cuarentena values (2, '20170904', 21)
insert into Cuarentena values (3, '20170904', 22)

insert into Factura values (1, null, 20)
insert into Factura values (2, null, 21)
insert into Factura values (3, null, 22)
