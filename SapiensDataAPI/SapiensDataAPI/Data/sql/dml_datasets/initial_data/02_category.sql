-- Insert main grocery categories
INSERT INTO Category (category_name, description, parent_category_id)
VALUES 
    ('Groceries', 'General category for all grocery items', NULL),
    ('Fruits', 'Category for all types of fruits', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Vegetables', 'Category for all types of vegetables', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Dairy', 'Category for all dairy products', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Meat', 'Category for meat products', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Seafood', 'Category for seafood products', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Beverages', 'Category for beverages and drinks', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Snacks', 'Category for snack foods', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Bakery', 'Category for bakery items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Frozen Foods', 'Category for frozen food items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Canned Goods', 'Category for canned food items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Condiments', 'Category for condiments and sauces', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Spices', 'Category for spices and seasonings', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Grains', 'Category for grains and rice', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Pasta', 'Category for pasta products', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Breakfast Foods', 'Category for breakfast items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Oils', 'Category for cooking oils', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Packaged Meals', 'Category for ready-to-eat and packaged meals', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Cleaning Supplies', 'Category for household cleaning supplies', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Personal Care', 'Category for personal care items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Household Items', 'Category for miscellaneous household items', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Baby Products', 'Category for products for babies', (SELECT category_id FROM Category WHERE category_name = 'Groceries')),
    ('Pet Supplies', 'Category for pet-related products', (SELECT category_id FROM Category WHERE category_name = 'Groceries'));
GO

-- Insert subcategories under specific main categories
INSERT INTO Category (category_name, description, parent_category_id)
VALUES
    ('Citrus Fruits', 'Subcategory for citrus fruits like oranges and lemons', (SELECT category_id FROM Category WHERE category_name = 'Fruits')),
    ('Berries', 'Subcategory for berries like strawberries and blueberries', (SELECT category_id FROM Category WHERE category_name = 'Fruits')),
    ('Leafy Greens', 'Subcategory for leafy green vegetables', (SELECT category_id FROM Category WHERE category_name = 'Vegetables')),
    ('Root Vegetables', 'Subcategory for root vegetables like carrots and potatoes', (SELECT category_id FROM Category WHERE category_name = 'Vegetables')),
    ('Milk', 'Subcategory for milk products', (SELECT category_id FROM Category WHERE category_name = 'Dairy')),
    ('Cheese', 'Subcategory for various cheeses', (SELECT category_id FROM Category WHERE category_name = 'Dairy')),
    ('Yogurt', 'Subcategory for yogurt products', (SELECT category_id FROM Category WHERE category_name = 'Dairy')),
    ('Poultry', 'Subcategory for poultry meats like chicken and turkey', (SELECT category_id FROM Category WHERE category_name = 'Meat')),
    ('Beef', 'Subcategory for beef products', (SELECT category_id FROM Category WHERE category_name = 'Meat')),
    ('Pork', 'Subcategory for pork products', (SELECT category_id FROM Category WHERE category_name = 'Meat')),
    ('Fish', 'Subcategory for fish', (SELECT category_id FROM Category WHERE category_name = 'Seafood')),
    ('Shellfish', 'Subcategory for shellfish', (SELECT category_id FROM Category WHERE category_name = 'Seafood')),
    ('Juices', 'Subcategory for fruit and vegetable juices', (SELECT category_id FROM Category WHERE category_name = 'Beverages')),
    ('Sodas', 'Subcategory for carbonated drinks', (SELECT category_id FROM Category WHERE category_name = 'Beverages')),
    ('Chips', 'Subcategory for chips and crisps', (SELECT category_id FROM Category WHERE category_name = 'Snacks')),
    ('Cookies', 'Subcategory for cookies and biscuits', (SELECT category_id FROM Category WHERE category_name = 'Snacks')),
    ('Ice Cream', 'Subcategory for frozen ice cream and desserts', (SELECT category_id FROM Category WHERE category_name = 'Frozen Foods')),
    ('Sauces', 'Subcategory for sauces', (SELECT category_id FROM Category WHERE category_name = 'Condiments')),
    ('Herbs and Spices', 'Subcategory for fresh herbs and spices', (SELECT category_id FROM Category WHERE category_name = 'Spices')),
    ('Rice', 'Subcategory for various types of rice', (SELECT category_id FROM Category WHERE category_name = 'Grains')),
    ('Pasta Shapes', 'Subcategory for various pasta shapes', (SELECT category_id FROM Category WHERE category_name = 'Pasta')),
    ('Instant Meals', 'Subcategory for instant meals', (SELECT category_id FROM Category WHERE category_name = 'Packaged Meals')),
    ('Bathroom Cleaners', 'Subcategory for bathroom cleaning products', (SELECT category_id FROM Category WHERE category_name = 'Cleaning Supplies')),
    ('Laundry Detergents', 'Subcategory for laundry cleaning products', (SELECT category_id FROM Category WHERE category_name = 'Cleaning Supplies')),
    ('Shampoos', 'Subcategory for hair shampoos', (SELECT category_id FROM Category WHERE category_name = 'Personal Care')),
    ('Soaps', 'Subcategory for soaps and body washes', (SELECT category_id FROM Category WHERE category_name = 'Personal Care')),
    ('Diapers', 'Subcategory for baby diapers', (SELECT category_id FROM Category WHERE category_name = 'Baby Products')),
    ('Baby Food', 'Subcategory for baby food', (SELECT category_id FROM Category WHERE category_name = 'Baby Products')),
    ('Dog Food', 'Subcategory for dog food', (SELECT category_id FROM Category WHERE category_name = 'Pet Supplies')),
    ('Cat Food', 'Subcategory for cat food', (SELECT category_id FROM Category WHERE category_name = 'Pet Supplies'));
GO

-- Insert default categories into ExpenseCategory table
INSERT INTO ExpenseCategory (category_name, description)
VALUES 
    ('Housing', 'Expenses related to housing, such as rent or mortgage'),
    ('Utilities', 'Monthly utility expenses like electricity, water, and gas'),
    ('Groceries', 'Expenses for food and household supplies'),
    ('Transportation', 'Expenses for public transport or personal vehicle costs'),
    ('Entertainment', 'Recreational activities and hobbies'),
    ('Medical', 'Medical bills, medications, and health-related costs'),
    ('Insurance', 'Various insurance payments like health, auto, and home insurance'),
    ('Education', 'Education-related expenses like tuition and books'),
    ('Loan Payment', 'Loan or debt repayment costs'),
    ('Dining', 'Expenses for dining out at restaurants'),
    ('Investment', 'Investments in stocks, bonds, or other assets'),
    ('Maintenance', 'Household or vehicle maintenance expenses'),
    ('Subscription', 'Recurring subscriptions like streaming services'),
    ('Personal Care', 'Personal care products and services'),
    ('Taxes', 'Income or property taxes'),
    ('Childcare', 'Expenses related to childcare or babysitting'),
    ('Pet Care', 'Expenses for pets, including food and vet bills'),
    ('Other', 'Miscellaneous expenses');
GO

-- Insert default income categories into IncomeCategory table
INSERT INTO IncomeCategory (category_name, description)
VALUES 
    ('Salary', 'Monthly salary from employment'),
    ('Bonus', 'Performance-related or annual bonuses'),
    ('Investment', 'Income from investment returns'),
    ('Rental', 'Income from rental properties'),
    ('Business', 'Income from business ventures or freelancing'),
    ('Freelance', 'Income from freelance work'),
    ('Gift', 'Gift money received'),
    ('Interest', 'Interest earned from bank accounts or deposits'),
    ('Dividend', 'Dividend income from stocks'),
    ('Tax Refund', 'Refund from tax overpayments'),
    ('Insurance Refund', 'Refund from insurance claims'),
    ('Electricity Refund', 'Reimbursement from utility overpayments'),
    ('Other', 'Other types of income');
GO
