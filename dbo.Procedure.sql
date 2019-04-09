CREATE PROCEDURE [sp_GetAllCategories]
AS
	WITH ParentCategories AS
	(
	SELECT CategoryId, ParentCategoryId, Name
	FROM Categories
	WHERE ParentCategoryId = null

	UNION ALL
	SELECT c.CategoryId, c.ParentCategoryId, c.Name
	FROM Categories c INNER JOIN ParentCategories pc
	ON c.ParentCategoryId = pc.CategoryId
	)
SELECT * FROM ParentCategories
RETURN
