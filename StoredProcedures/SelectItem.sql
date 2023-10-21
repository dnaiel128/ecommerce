USE [eCommerce]
GO
/****** Object:  StoredProcedure [dbo].[SelectItem]    Script Date: 10/21/2023 6:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Daniel
-- Create date: 21.10.2022
-- Description:	Get Item by ID
-- =============================================
ALTER PROCEDURE [dbo].[SelectItem] 
	-- Add the parameters for the stored procedure here
	@ItemId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	SELECT TOP 1* 
	FROM Items
	WHERE Id = @ItemId
END
