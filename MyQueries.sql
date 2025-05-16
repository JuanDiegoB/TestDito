CREATE DATABASE TestDito;
GO

USE TestDito;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- [Key]

    Name NVARCHAR(100) NOT NULL, -- [Required], [StringLength(100)]

    Lastname NVARCHAR(100) NOT NULL, -- [Required], [StringLength(100)]

    IdentificationType NVARCHAR(2) NOT NULL CHECK (
        IdentificationType IN ('CC', 'RC', 'TI', 'PA')
    ), -- [Required], [StringLength(2)]

    IdentificationNumber NVARCHAR(20) NOT NULL, -- [Required], [StringLength(20)]

    Password NVARCHAR(100) NOT NULL, -- [Required], [StringLength(100)]

    Email NVARCHAR(100) NOT NULL, -- [Required], [StringLength(100)]

    IsAdmin BIT NOT NULL DEFAULT 0 -- bool en C#, se traduce a BIT con valor por defecto
);
GO

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_Email UNIQUE (Email);
GO

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_IdentificationNumber UNIQUE (IdentificationNumber);
GO

INSERT INTO Users (
    Name, Lastname, IdentificationType, IdentificationNumber, Password, Email, IsAdmin
)
VALUES (
    'Admin', 'User', 'CC', '1000000001','$2a$10$7I2t8VO8DeF/1IqYMsXWX.NAeEsgmFZuvWqAifruVD7nLDkM1sn4S','admin@testdito.com', 1
);
GO

INSERT INTO Users (
    Name, Lastname, IdentificationType, IdentificationNumber, Password, Email, IsAdmin
)
VALUES 
('Juan', 'Pérez', 'TI', '1000000002', '$2a$10$DKr5m.QiI6Fs2mTVr0I5r.9wEW9XQZCJMdP8CmS/g3aBjXYYoIlbS', 'juan.perez@testdito.com', 0),
('María', 'Gómez', 'CC', '1000000003', '$2a$10$zWjbsJp3gI89sY/IXqAT4OcPBUn2Gz/PAW6AVvLVQxExz7lj7OYbe', 'maria.gomez@testdito.com', 0),
('Luis', 'Martínez', 'RC', '1000000004', '$2a$10$6N1.YsVgv0SVjDw5IHTR9uXbwYVQplJmmDFTJopQAxOnjHHquErzq', 'luis.martinez@testdito.com', 0);
GO