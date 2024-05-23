CREATE TABLE [dbo].[ServiceRequest]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Statement] NVARCHAR(50) NULL, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [Location.Latitude] DECIMAL(8,6) NULL,
    [Location.Longitude] DECIMAL(9,6) NULL,
)
