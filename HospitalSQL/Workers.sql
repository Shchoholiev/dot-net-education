CREATE TABLE dbo.[Workers](
	CONSTRAINT PK_Worker PRIMARY KEY (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[FullName] NVARCHAR(100) NOT NULL,
	[Salary] INT,
	[WorkHours] INT,
)