SELECT 
	Animals.[Type],
	Animals.[Name],
	COUNT(*) AS [Feeds Types Count],
	SUM([FeedCount]) AS [Feed Count]
FROM dbo.[Diets] 
	INNER JOIN dbo.[Animals] ON Diets.AnimalId = Animals.Id
	INNER JOIN dbo.[Feeds] ON Diets.FeedId = Feeds.Id
	GROUP BY Animals.[Type], Animals.[Name]