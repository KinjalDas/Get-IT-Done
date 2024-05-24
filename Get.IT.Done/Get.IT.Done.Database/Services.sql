CREATE TABLE [dbo].[Services]
(
	[Id] uniqueidentifier NOT NULL,
    [Type] int NOT NULL,
    [Description] nvarchar(50) NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
)
