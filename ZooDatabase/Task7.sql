SELECT
	Animals.[Type],
	COUNT (*) AS [Animals Count]
FROM dbo.[Animals]
GROUP BY Animals.[Type]
HAVING COUNT (*) > (SELECT COUNT(*) FROM dbo.[Animals]) / 100