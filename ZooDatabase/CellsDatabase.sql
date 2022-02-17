CREATE TABLE dbo.[Cells](
	CONSTRAINT PK_Cell PRIMARY KEY (Id),

	[Id] INT NOT NULL,
	[Type] NVARCHAR(100) NULL,
	[Size] INT NOT NULL,
	[Info] NVARCHAR(100) NULL,
)

INSERT INTO dbo.[Cells]
VALUES 
	(15, N'Вольєр', 100, N'Є басейн'),
	(27, N'Вольєр', 50, N'Висока огорожа'),
	(38, N'Тераріум', 15, NULL),
	(35, N'Басейн', 34, NULL)