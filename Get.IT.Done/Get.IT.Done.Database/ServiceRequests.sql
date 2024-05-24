CREATE TABLE [dbo].[ServiceRequests]
(
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [ServiceLocation] geography NOT NULL,
    [ServiceRequestedTimeTamp] datetime2 NOT NULL,
    CONSTRAINT [PK_ServiceRequests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ServiceRequests_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_ServiceRequests_ServiceId] ON [dbo].[ServiceRequests] ([ServiceId])
