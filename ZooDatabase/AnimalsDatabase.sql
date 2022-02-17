CREATE TABLE dbo.[Animals](
	CONSTRAINT PK_Animal PRIMARY KEY (Id),
	CONSTRAINT FK_Animals_Cells
	FOREIGN KEY (CellId) REFERENCES Cells (Id),

	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Type] NVARCHAR(100) NOT NULL,
	[CellId] INT NOT NULL,
)

INSERT INTO dbo.[Animals]
VALUES 
	(5, N'Тенді', N'Слон', 15),
	(17, N'Грета', N'Жираф', 27),
	(18, N'Грета', N'Жираф', 27),
	(25, N'Гена', N'Крокодил', 38)