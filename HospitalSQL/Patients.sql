CREATE TABLE dbo.[Patients](
	CONSTRAINT PK_Patient PRIMARY KEY (Id),
	CONSTRAINT FK_Patients_HospitalCards
	FOREIGN KEY (HospitalCardId) REFERENCES HospitalCards (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[FullName] NVARCHAR(100) NOT NULL,
	[Specialization] NVARCHAR(100) NOT NULL,
	[HospitalCardId] INT NOT NULL,
)