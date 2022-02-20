-- 1) Создать базу данных "книги" (Books)

CREATE DATABASE Books;

-- 2) Создать таблицы из диаграммы
-- 3) Расставить ограничения (constraints, unique, check)

CREATE TABLE dbo.[Authors](
	CONSTRAINT PK_Author PRIMARY KEY (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.[Publishers](
	CONSTRAINT PK_Publisher PRIMARY KEY (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
)

CREATE TABLE dbo.[Serias](
	CONSTRAINT PK_Serias PRIMARY KEY (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[TomCount] INT NOT NULL,
)

CREATE TABLE dbo.[Books](
	CONSTRAINT PK_Books PRIMARY KEY (Id),

	CONSTRAINT FK_Books_Serias
	FOREIGN KEY (SeriaId) REFERENCES Serias (Id),

	CONSTRAINT UK_ISBN UNIQUE (ISBN),

	CONSTRAINT FK_Books_Publishers
	FOREIGN KEY (PublisherId) REFERENCES Publishers (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[SeriaId] INT NULL,
	[ISBN] NVARCHAR(17) NOT NULL,
	[PublisherId] INT NULL,
	[LangCode] NVARCHAR(100) NOT NULL
)

CREATE TABLE dbo.[BooksAuthors](
	CONSTRAINT PK_BooksAuthors PRIMARY KEY (BookId, AuthorId),
	CONSTRAINT FK_BooksAuthors_Books
	FOREIGN KEY (BookId) REFERENCES Books (Id),
	CONSTRAINT FK_BooksAuthors_Authors
	FOREIGN KEY (AuthorId) REFERENCES Authors (Id),

	[BookId] INT NOT NULL,
	[AuthorId] INT NOT NULL,
)

-- 4) Заполнить БД данными

INSERT INTO dbo.[Authors]
VALUES
	('Phil Szostak'),
	('Kate Humble')

INSERT INTO dbo.[Publishers]
VALUES
	('Abrams'),
	('Octopus Publishing Group')

INSERT INTO dbo.[Serias]
VALUES
	('The Art of Star Wars', 2)

INSERT INTO dbo.[Books]
VALUES
	('The Art of Star Wars: The Mandalorian (Season Two)', 1, 9781419756511, 1, 'en'),
	('Home Cooked: Recipes from the Farm', NULL, 9781856754620, 1, 'en')

INSERT INTO dbo.[BooksAuthors]
VALUES
	(1, 1),
	(2, 2)

-- 5) Реализовать CRUD операции (ADO)

GO
CREATE PROCEDURE [AddBook]
	@Title NVARCHAR(100),
	@SeriaId INT,
	@ISBN NVARCHAR(13),
	@PublisherId INT,
	@LangCode NVARCHAR(100)
AS
	INSERT INTO dbo.[Books]
	VALUES (@Title, @SeriaId, @ISBN, @PublisherId, @LangCode)
GO

CREATE PROCEDURE [GetAllBooks]
AS
	SELECT * FROM dbo.[Books]
GO

CREATE PROCEDURE [UpdateBook]
	@Title NVARCHAR(100),
	@SeriaId INT,
	@ISBN NVARCHAR(13),
	@PublisherId INT,
	@LangCode NVARCHAR(100)
AS
	UPDATE dbo.[Books]
	SET 
		Title = @Title, 
		SeriaId = @SeriaId, 
		ISBN = @ISBN,
		PublisherId = @PublisherId,
		LangCode = @LangCode
GO

CREATE PROCEDURE [DeleteBookById]
	@BookId INT
AS
	DELETE FROM dbo.[Books]
	WHERE Books.Id = @BookId
GO

-- 6) Реализовать процедуру выборки книг по ид серии

CREATE PROCEDURE [GetBooksBySeriaId]
	@SeriaId INT
AS
	SELECT 
		Books.*
	FROM dbo.[Books]
		INNER JOIN dbo.[Serias] ON Books.SeriaId = Serias.Id
GO

-- 7) Создать роль LibraryMan и дать разрешение на добавление данных

CREATE ROLE LibraryMan;
GRANT INSERT TO LibraryMan;

-- 8) Создать роль LibraryReader и дать разрешения только на чтение

CREATE ROLE LibraryReader;
GRANT SELECT TO LibraryReader;

-- 9) создать соотвуствующих юзеров и назначить роли

CREATE LOGIN WriterLogin WITH PASSWORD = '1111';
CREATE USER Writer FOR LOGIN WriterLogin;
ALTER ROLE LibraryMan ADD MEMBER Writer;

CREATE LOGIN ReaderLogin WITH PASSWORD = '1111';
CREATE USER Reader FOR LOGIN ReaderLogin;
ALTER ROLE LibraryReader ADD MEMBER Reader;