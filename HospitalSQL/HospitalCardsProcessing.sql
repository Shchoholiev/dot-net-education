CREATE TABLE dbo.[HospitalCardsProcessing](
	CONSTRAINT FK_HospitalCardsProcessing_Workers
	FOREIGN KEY (WorkerId) REFERENCES Workers (Id),
	CONSTRAINT FK_HospitalCardsProcessing_HospitalCards
	FOREIGN KEY (HospitalCardId) REFERENCES HospitalCards (Id),
	
	[WorkerId] INT NOT NULL,
	[HospitalCardId] INT NOT NULL,
)