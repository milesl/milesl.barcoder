CREATE PROCEDURE [dbo].[usp_add_barcode]
	@message nvarchar(max),
	@format nvarchar(50)
AS
	INSERT INTO [dbo].[Barcodes]
	([Message], [Format])
	OUTPUT 
	INSERTED.[Id], INSERTED.[Message], INSERTED.[Format], INSERTED.[DateScanned]
	VALUES
	(@message, @format)