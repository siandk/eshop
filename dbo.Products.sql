CREATE PROCEDURE [sp_GetCategoryProducts]
	@rootId int
AS
	WITH ParentCategories AS
	(
	SELECT CategoryId, ParentCategoryId, Name
	FROM Categories
	WHERE CategoryId = @rootId

	UNION ALL
	SELECT c.CategoryId, c.ParentCategoryId, c.Name
	FROM Categories c INNER JOIN ParentCategories pc
	ON c.ParentCategoryId = pc.CategoryId
	)
SELECT p.ProductId, p.Published, p.Description, p.Name, p.UnitPrice, p.CategoryId, p.ManufacturerId
FROM ParentCategories pc
INNER JOIN Products p
ON p.CategoryId = pc.CategoryId

SELECT m.ManufacturerId, m.Name
FROM ParentCategories pc
INNER JOIN Products p
ON p.CategoryId = pc.CategoryId
INNER JOIN Manufacturers m
ON m.ManufacturerId = p.ManufacturerId
RETURN
