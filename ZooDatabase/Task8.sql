SELECT *
FROM dbo.[Feeds]
WHERE Feeds.Id =
	(SELECT Diets.[FeedId]
	FROM dbo.[Diets]
	INNER JOIN dbo.[Feeds] ON Diets.FeedId = Feeds.Id
	WHERE Diets.[Periodicity] = N'Щоденно'
	GROUP BY Diets.[FeedId]
	HAVING SUM([FeedCount]) =
		(SELECT 
			MIN([Feeds Sum])
		FROM 
		(SELECT
			Diets.[FeedId],
			SUM([FeedCount]) As [Feeds Sum]
		FROM dbo.[Diets]
		INNER JOIN dbo.[Feeds] ON Diets.FeedId = Feeds.Id
		WHERE Diets.[Periodicity] = N'Щоденно'
		GROUP BY Diets.[FeedId]) 
		AS [Sum]))
