SELECT 
	DISTINCT [CellId], 
	[Size], 
	(SELECT COUNT(*) FROM dbo.[Animals] WHERE Animals.CellId = Cells.Id ) AS [Animals Count],
	(SELECT COUNT(DISTINCT Animals.[Type]) FROM dbo.[Animals] WHERE Animals.CellId = Cells.Id) AS [Animals Types Count]
FROM dbo.[Animals] INNER JOIN dbo.[Cells] ON Animals.CellId = Cells.Id 
WHERE Cells.[Size] > 200
ORDER BY Animals.[Type] DESC, Animals.[CellId];