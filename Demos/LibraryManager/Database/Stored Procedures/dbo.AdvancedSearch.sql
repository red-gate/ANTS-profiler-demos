
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[AdvancedSearch]
(
@Author VARCHAR(50),
@Title VARCHAR(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--Search for exact matches in Archive and fuzzy matches in Books
	SELECT * FROM dbo.Books WHERE (Author like '%'+@Author+'%' AND Title like '%'+@Title+'%')
	UNION
	SELECT * FROM dbo.Archive WHERE (Author = @Author AND Title = @Title)
END
GO
