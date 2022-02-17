CREATE TABLE dbo.[Diets](
	CONSTRAINT FK_Diets_Animals
	FOREIGN KEY (AnimalId) REFERENCES Animals (Id),
	CONSTRAINT FK_Diets_Feeds
	FOREIGN KEY (FeedId) REFERENCES Feeds (Id),

	[AnimalId] INT NOT NULL,
	[FeedId] INT NOT NULL,
	[FeedCount] INT NOT NULL,
	[Periodicity] NVARCHAR(100) NOT NULL,
)

INSERT INTO dbo.[Diets]
VALUES 
	(5, 11, 10, N'Щоденно'),
	(5, 33, 20, N'Щоденно'),
	(5, 22, 4, N'По парних'),
	(17, 11, 13, N'Щоденно'),
	(25, 55, 6, N'Раз в три дні')