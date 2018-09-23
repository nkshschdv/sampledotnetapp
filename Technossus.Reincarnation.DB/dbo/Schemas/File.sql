CREATE TABLE [dbo].[File] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [ParentId]    BIGINT          NULL,
    [FileName]    NVARCHAR (1000)  NOT NULL,
    [ContentType] NVARCHAR (100)  NULL,
    [DocBytes]    VARBINARY (MAX) NULL,
    [FileSize]    BIGINT          NULL,
    [CreatedDate] DATETIME2 (7)   NOT NULL,
    [UpdatedDate] DATETIME2 (7)   NOT NULL,
    [CreatedById] NVARCHAR (128)  NOT NULL,
    [UpdatedById] NVARCHAR (128)  NOT NULL,
    [IsDeleted]   BIT             CONSTRAINT [DF_File_IsDeleted] DEFAULT ((0)) NOT NULL,
    [AzureImagePath] NVARCHAR(1000) NULL, 
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_File_File] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[File] ([Id])
);