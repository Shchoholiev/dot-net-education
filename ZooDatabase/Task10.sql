CREATE PROCEDURE [AddAnimal]
	@Id INT,
	@Name NVARCHAR(100),
	@Type NVARCHAR(100),
	@CellId INT
AS
	INSERT INTO dbo.[Animals]
	VALUES (@Id, @Name, @Type, @CellId)
GO