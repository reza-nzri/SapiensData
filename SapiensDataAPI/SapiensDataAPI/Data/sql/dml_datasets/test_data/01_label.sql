-- Usage Example
INSERT INTO LabelAssignment (label_id, entity_type, entity_id) VALUES 
  (1, 'Product', 1),   -- Assign "organic" label to product with product_id = 1
  (4, 'Product', 1),   -- Assign "eco-friendly" label to product with product_id = 1
  (2, 'Expense', 5),   -- Assign "essential" label to Expense with expense_id = 5
  (3, 'Income', 3);    -- Assign "luxury" label to Income with income_id = 3
GO
