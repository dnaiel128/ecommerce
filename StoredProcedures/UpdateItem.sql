USE [eCommerce]
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 10/21/2023 6:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel
-- Create date: 21.10.2023
-- Description:	Update Item
-- =============================================
ALTER PROCEDURE [dbo].[UpdateItem]
	@ItemId INT,
    @NewName NVARCHAR(MAX),
    @NewPrice DECIMAL(8, 2),
    @NewDescription NVARCHAR(MAX),
	@NewImagePath NVARCHAR(MAX)
AS
BEGIN
	UPDATE Items
    SET Name = @NewName,
        Price = @NewPrice,
        Description = @NewDescription,
		ImageFolderPath = @NewImagePath
    WHERE Id = @ItemId
END
