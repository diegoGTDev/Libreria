
CREATE DATABASE Prueba;
use Prueba
CREATE TABLE Libro(
	IdLibro	INT PRIMARY KEY IDENTITY(1,1),
	Titulo VARCHAR(80) NOT NULL,
	Editorial VARCHAR(80) NOT NULL,
	Area VARCHAR(50) NOT NULL
);


CREATE TABLE Autor(
	IdAutor SMALLINT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Nacionalidad VARCHAR(50),
);


CREATE TABLE LibAut(
	IdAutor SMALLINT ,
	IdLibro INT ,
	FOREIGN KEY (IdLibro) REFERENCES Libro(IdLibro),
	FOREIGN KEY (IdAutor) REFERENCES Autor(IdAutor),
	PRIMARY KEY(IdAutor, IdLibro)
);

CREATE TABLE Estudiante(
	IdLector SMALLINT PRIMARY KEY IDENTITY(1,1),
	CI VARCHAR(20),
	Nombre VARCHAR(50),
	Direccion VARCHAR(100),
	Carrera VARCHAR(80),
	Edad TINYINT
);
CREATE TABLE Prestamo(
	IdLector SMALLINT FOREIGN KEY REFERENCES Estudiante(IdLector),
	IdLibro INT FOREIGN KEY REFERENCES Libro(IdLibro),
	FechaPrestamo DATE NOT NULL,
	FechaDevolucion DATE,
	DEVUELTO TINYINT,
	PRIMARY KEY(FechaPrestamo, IdLibro, IdLector)
)

INSERT INTO Libro VALUES ('El principito', 'Pearson', 'Lib1'),
('Interestellar', 'Santillana', 'Lib1'),
('Calculo para ingenieros', 'Math', 'Lib11'),
('Harry Potter', 'Disney', 'Lib4'),
('Star wars', 'Disney', 'Lib9');

INSERT INTO Estudiante (CI, Nombre, Direccion, Carrera, Edad) VALUES
('0908-23-626', 'Diego', 'Zona 7', 'Ing.Sistemas', 20),
('1234567890', 'Ana Garcia', 'Calle Falsa 123', 'Ingeniería de Software', 21),
('0987654321', 'Luis Fernandez', 'Avenida Siempre Viva 742', 'Medicina', 23),
('5678901234', 'Maria Rodriguez', 'Calle Luna 456', 'Derecho', 22),
('4321098765', 'Carlos Martinez', 'Avenida Sol 789', 'Arquitectura', 24);

INSERT INTO Autor (Nombre, Nacionalidad) VALUES
('Gillermo del toro', 'Mexicana'),
('Gabriel Garcia Marquez', 'Colombiana'),
('J.K. Rowling', 'Británica'),
('Haruki Murakami', 'Japonesa'),
('Isabel Allende', 'Chilena');

INSERT INTO LibAut (IdAutor, IdLibro) VALUES
(1, 1),
(2, 4),
(3, 2),
(4, 5),
(5, 3);
 SELECT * FROM Prestamo
 TRUNCATE table PRESTAMO