-- Obtener todos los libros del autor XXXX o categoría YYYY

select * from Libro where IdAutor = 50 or IdCategoria = 50

-- Obtener todos los libros que tenga título que comience con ‘xxx’

select * from Libro where Titulo like 'Libro%'

-- Obtener el nombre de los libros que fueron prestados al socio XXXX id = 56

select * from Prestamo where IdSocio = 56

SELECT Titulo
FROM Libro
INNER JOIN Prestamo ON Prestamo.IdLibro = Libro.IdLibro 
WHERE Prestamo.IdSocio = 56;

-- Obtener el nombre de los libros que fueron prestados a socios y fueron penalizados en dicho préstamo

SELECT Titulo
FROM ((Libro
INNER JOIN Prestamo ON Prestamo.IdLibro = Libro.IdLibro)
INNER JOIN Penalizacion ON Prestamo.IdPrestamo = Penalizacion.IdPrestamo);

-- Obtener ranking de los 5 socios más penalizados

SELECT DISTINCT TOP 5 s.IdSocio, COUNT(*) AS totalPenalizaciones
FROM Socio s, Prestamo p, Penalizacion pen
WHERE s.IdSocio = p.IdSocio AND p.IdPrestamo = pen.IdPrestamo
GROUP BY s.IdSocio
ORDER BY totalPenalizaciones DESC;

-- Obtener ranking de libros con mayor cantidad de penalizaciones

SELECT DISTINCT l.IdLibro, COUNT(*) AS totalPenalizaciones
FROM Libro l, Prestamo p, Penalizacion pen
WHERE l.IdLibro = p.IdLibro AND p.IdPrestamo = pen.IdPrestamo
GROUP BY l.IdLibro
ORDER BY totalPenalizaciones DESC;

--Listar los autores cuyos libros tengan más de dos usuarios con penalizaciones

SELECT a.Nombre, l.Titulo
FROM Libro l 
INNER JOIN Prestamo p ON l.IdLibro = p.IdLibro
INNER JOIN Penalizacion pen ON p.IdPrestamo = pen.IdPrestamo
INNER JOIN Autor a on a.IdAutor = l.IdAutor

GROUP BY a.Nombre, l.Titulo
HAVING COUNT(p.IdLibro) > 2




