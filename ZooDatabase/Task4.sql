SELECT Animals.[Type], [Name], [CellId], Cells.[Type] 
FROM dbo.[Animals] INNER JOIN dbo.[Cells] ON Animals.CellId = Cells.Id
ORDER BY Animals.[Type] DESC, Animals.[CellId];