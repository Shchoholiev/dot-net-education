CREATE TABLE dbo.[HospitalCards](
	CONSTRAINT PK_HospitalCard PRIMARY KEY (Id),
	CONSTRAINT FK_HospitalCards_Illnesses
	FOREIGN KEY (IllnessId) REFERENCES Illnesses (Id),

	[Id] INT IDENTITY(1,1) NOT NULL,
	[IllnessId] INT NOT NULL,
)