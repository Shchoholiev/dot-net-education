CREATE TABLE dbo.[Feeds](
	CONSTRAINT PK_Feed PRIMARY KEY (Id),

	[Id] INT NOT NULL,
	[Feed] NVARCHAR(100) NOT NULL,
	[CountInStorage] INT NOT NULL,
	[Unit] NVARCHAR(100) NOT NULL,
	[Order] INT NULL,
)

INSERT INTO dbo.[Feeds]
VALUES 
	(11, N'Яблуко', 2000, N'кг', null),
	(22, N'Сіно', 3000, N'кг', null),
	(33, N'Морква', 150, N'кг', null),
	(44, N'Молоко', 30, N'літр', 50),
	(55, N'Яловичина', 230, N'кг', null)