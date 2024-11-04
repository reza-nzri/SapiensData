CREATE VIEW vw_ExpenseCategoryHierarchy AS
SELECT 
    c1.category_name AS MainCategory,
    c2.category_name AS SubCategory
FROM 
    ExpenseCategory c1
LEFT JOIN 
    ExpenseCategory c2 ON c1.category_id = c2.parent_category_id
ORDER BY 
    c1.category_name, c2.category_name;
