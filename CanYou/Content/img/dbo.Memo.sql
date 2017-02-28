CREATE TABLE [dbo].[Memo]
(
	[Seq] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(50) NULL, 
    [TransDate] DATETIME NULL DEFAULT getdate(), 
    [MemoText] NCHAR(500) NULL
)
