UPDATE dbo.[Cells]
SET Cells.[Info] =  N'Хижак' 
FROM dbo.[Cells] INNER JOIN dbo.[Animals] ON Cells.Id = Animals.CellId
WHERE Animals.[Type] = N'Крокодил'