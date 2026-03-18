USE tempdb
GO

-- Eliminar bd si existe
DROP DATABASE IF EXISTS BdPacientes
GO

-- Crear bd y tabla
CREATE DATABASE BdPacientes
GO

USE BdPacientes
GO

CREATE TABLE Pacientes(
	Id INT IDENTITY(1,1) NOT NULL,
	NombreCompleto VARCHAR(500) NOT NULL,
	NumeroIdentidad VARCHAR(20) NOT NULL,
	FechaNacimiento DATETIME NOT NULL,
	Telefono VARCHAR(10) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL
)
GO

INSERT INTO Pacientes (
	NombreCompleto, 
	NumeroIdentidad, 
	FechaNacimiento,
	Telefono)
VALUES
('Juan Perez', '0319197800322', '2000-01-01', '88994455'),
('John Connor', '0319197800324', '2002-01-01', '88994488'),
('Aquiles Brinco', '0319197800323', '2009-01-01', '88994411')
GO

SELECT * FROM Pacientes
GO
