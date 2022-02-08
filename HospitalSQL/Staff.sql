CREATE TABLE dbo.[Staff](
	CONSTRAINT FK_Staff_Departments
	FOREIGN KEY (DepartmentId) REFERENCES Departments (Id),
	CONSTRAINT FK_Staff_Workers
	FOREIGN KEY (WorkerId) REFERENCES Workers (Id),
	
	[DepartmentId] INT NOT NULL,
	[WorkerId] INT NOT NULL,
)