BEGIN TRANSACTION;
	DELETE Diets
	FROM dbo.[Diets]
	INNER JOIN dbo.[Animals]
		ON Diets.AnimalId = Animals.Id
	WHERE Animals.[Name] = N'Василь'

	DELETE FROM dbo.[Animals]
	WHERE Animals.[Name] = N'Василь'
COMMIT TRANSACTION;