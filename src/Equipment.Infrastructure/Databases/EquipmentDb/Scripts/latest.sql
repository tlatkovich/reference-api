IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250430141910_1'
)
BEGIN
    CREATE TABLE [Equipment] (
        [Id] uniqueidentifier NOT NULL,
        [EquipmentNumber] int NOT NULL IDENTITY(10000000, 1),
        [IsAttachment] bit NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [Make] nvarchar(max) NOT NULL,
        [Model] nvarchar(max) NOT NULL,
        [Year] int NOT NULL,
        [SerialNumber_Value] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NOT NULL,
        [ModifiedDate] datetime2 NULL,
        CONSTRAINT [PK_Equipment] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250430141910_1'
)
BEGIN
    CREATE TABLE [Attachments] (
        [Id] uniqueidentifier NOT NULL,
        [Make] nvarchar(max) NOT NULL,
        [Model] nvarchar(max) NOT NULL,
        [EquipmentId] uniqueidentifier NOT NULL,
        [EquipmentNumber_Value] int NOT NULL,
        CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Attachments_Equipment_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250430141910_1'
)
BEGIN
    CREATE INDEX [IX_Attachments_EquipmentId] ON [Attachments] ([EquipmentId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250430141910_1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250430141910_1', N'9.0.3');
END;

COMMIT;
GO

