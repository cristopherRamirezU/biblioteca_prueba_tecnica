-- =============================================
-- Crear base de datos
-- =============================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BibliotecaDb')
BEGIN
    CREATE DATABASE BibliotecaDb;
END
GO

USE BibliotecaDb;
GO

-- =============================================
-- Tabla: Users
-- =============================================
IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL
);
GO

-- =============================================
-- Tabla: Favorites
-- =============================================
IF OBJECT_ID('Favorites', 'U') IS NOT NULL
    DROP TABLE Favorites;
GO

CREATE TABLE Favorites (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    ExternalId NVARCHAR(200) NOT NULL,
    Title NVARCHAR(300) NOT NULL,
    Authors NVARCHAR(500) NOT NULL,
    FirstPublishYear INT NULL,
    CoverUrl NVARCHAR(500) NULL,

    CONSTRAINT FK_Favorites_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
);
GO

-- =============================================
-- Índice único para evitar duplicados
-- (Un mismo usuario no puede guardar el mismo libro dos veces)
-- =============================================
CREATE UNIQUE INDEX UX_Favorites_User_External
ON Favorites(UserId, ExternalId);
GO

-- =============================================
-- Datos iniciales (seed opcional)
-- =============================================
IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = 'default')
BEGIN
    INSERT INTO Users (UserName) VALUES ('default');
END
GO
