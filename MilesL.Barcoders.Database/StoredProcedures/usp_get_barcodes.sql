CREATE PROCEDURE [dbo].[usp_get_barcodes]
AS
	SELECT
		[Id] AS [Id], 
		[Message] AS [Message], 
		[Format] AS [Format], 
		[DateScanned] AS [DateScanned]
	FROM
		[dbo].[Barcodes]
