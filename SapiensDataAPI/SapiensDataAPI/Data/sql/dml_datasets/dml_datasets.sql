-- Inserts for PaymentMethod Table
INSERT INTO PaymentMethod (name, abbreviation, description) VALUES
('Credit Card', 'CC', 'Standard credit card payment, including Visa, MasterCard, Amex, etc.'),
('Debit Card', 'DC', 'Direct debit payment from a bank account'),
('Cash', NULL, 'Payment made with physical currency'),
('Bank Transfer', 'BT', 'Electronic transfer of funds directly from a bank account'),
('Mobile Payment', 'MP', 'Payment via mobile app, such as Apple Pay, Google Pay, or Samsung Pay'),
('PayPal', NULL, 'Online payment through a linked PayPal account'),
('Gift Card', 'GC', 'Payment using a pre-paid gift card'),
('Cryptocurrency', 'CRYPTO', 'Payment made using digital currency, such as Bitcoin or Ethereum'),
('SEPA Direct Debit', 'SEPA DD', 'Single Euro Payments Area direct debit payment in Europe'),
('Cheque', 'CHQ', 'Traditional paper check payment'),
('Wire Transfer', 'WT', 'Electronic transfer of funds via a network, such as SWIFT or Western Union'),
('Apple Pay', 'AP', "Payment made using Apple’s mobile payment service"),
('Google Pay', 'GP', 'Payment made using Google’s mobile payment service'),
('Samsung Pay', 'SP', 'Payment made using Samsung’s mobile payment service'),
('Amazon Pay', 'AMZ', 'Payment made via Amazon’s online payment service'),
('Alipay', 'ALI', 'Payment made using Alipay, a popular mobile payment service in China'),
('WeChat Pay', 'WCP', 'Payment made using WeChat Pay, a popular mobile payment service in China'),
('Prepaid Card', 'PC', 'Payment made using a prepaid card'),
('Bank Draft', 'BD', 'A payment made via a bank draft or cashier’s check');
GO



-- Insert commonly used units
INSERT INTO UnitType (unit_name, unit_type) VALUES 
('kg', 'weight'),
('g', 'weight'),
('lb', 'weight'),
('oz', 'weight'),
('pcs', 'quantity'),
('pack', 'quantity'),
('l', 'volume'),
('ml', 'volume');
GO

INSERT INTO Frequency (frequency_name, description, days_interval)
VALUES 
  ('one-time', 'Occurs once only', NULL),
  ('daily', 'Occurs every day', 1),
  ('weekly', 'Occurs every week', 7),
  ('bi-weekly', 'Occurs every two weeks', 14),
  ('monthly', 'Occurs every month', 30),
  ('quarterly', 'Occurs every three months', 90),
  ('annually', 'Occurs every year', 365);
GO

INSERT INTO IncomeCategory (category_name, description) VALUES 
  ('salary', 'Regular earnings from employment'),
  ('bonus', 'Additional earnings or incentives from work'),
  ('investment', 'Income from investments such as stocks or bonds'),
  ('rental', 'Income generated from renting property'),
  ('business', 'Income from business operations'),
  ('unemployment benefit', 'Financial assistance during unemployment'), -- "Arbeitslosengeld"
  ('freelance', 'Earnings from freelance work or contracts'),
  ('gift', 'Income received as a gift from others'),
  ('interest', 'Income generated from interest on deposits'),
  ('dividend', 'Earnings from stock dividends'),
  ('tax refund', 'Income from tax returns or refunds'),
  ('insurance refund', 'Refund from insurance claims'),
  ('electricity refund', 'Reimbursement for electricity expenses'),
  ('government assistance', 'Financial aid provided by the government for education or living expenses, including programs like BAföG in Germany'),
  ('education grant', 'Grants or scholarships awarded specifically for educational purposes'),
  ('other', 'Miscellaneous income not covered by other categories');
GO

INSERT INTO ExpenseCategory (category_name, description) VALUES 
  ('housing', 'Expenses related to housing, such as rent or mortgage'),
  ('utilities', 'Monthly utility expenses like electricity, water, and gas'),
  ('groceries', 'Expenses for food and household supplies'),
  ('transportation', 'Expenses for public transport or personal vehicle costs'),
  ('entertainment', 'Recreational activities and hobbies'),
  ('medical', 'Medical bills, medications, and health-related costs'),
  ('insurance', 'Various insurance payments like health, auto, and home insurance'),
  ('education', 'Education-related expenses like tuition and books'),
  ('loan_payment', 'Loan or debt repayment costs'),
  ('travel', 'Travel and accommodation expenses'),
  ('dining', 'Expenses for dining out at restaurants'),
  ('gifts', 'Money spent on gifts for others'),
  ('investment', 'Investments in stocks, bonds, or other assets'),
  ('maintenance', 'Household or vehicle maintenance expenses'),
  ('subscription', 'Recurring subscriptions like streaming services'),
  ('personal_care', 'Personal care products and services'),
  ('taxes', 'Income or property taxes'),
  ('childcare', 'Expenses related to childcare or babysitting'),
  ('pet_care', 'Expenses for pets, including food and vet bills'),
  ('other', 'Miscellaneous expenses');
Go

-- Insert Subcategories for 'housing'
INSERT INTO ExpenseCategory (category_name, description, parent_category_id) VALUES 
    ('rent', 'Monthly housing rent payments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'housing')),
    ('mortgage', 'Mortgage payments for owned property', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'housing')),

-- Insert Subcategories for 'utilities'
    ('electricity', 'Electricity bills and expenses', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'utilities')),
    ('water', 'Water and sewage expenses', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'utilities')),
    ('gas', 'Natural gas expenses for heating and cooking', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'utilities')),

-- Insert Subcategories for 'transportation'
    ('public_transport', 'Expenses for buses, trains, and other public transportation', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'transportation')),
    ('fuel', 'Fuel expenses for personal vehicles', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'transportation')),
    ('car_maintenance', 'Maintenance and repairs for personal vehicles', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'transportation')),
    ('ride_share', 'Expenses for ride-sharing services like Uber or Lyft', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'transportation')),

-- Insert Subcategories for 'entertainment'
    ('movies', 'Tickets and subscriptions for movies and cinemas', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'entertainment')),
    ('sports', 'Expenses for sports events and activities', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'entertainment')),
    ('concerts', 'Tickets for concerts and live performances', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'entertainment')),
    ('hobbies', 'Hobbies and recreational activities', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'entertainment')),

-- Insert Subcategories for 'medical'
    ('doctor_visits', 'Payments for doctor appointments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'medical')),
    ('medications', 'Expenses for prescribed medications', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'medical')),
    ('dental', 'Expenses for dental care and treatments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'medical')),

-- Insert Subcategories for 'insurance'
    ('health_insurance', 'Monthly health insurance premiums', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'insurance')),
    ('auto_insurance', 'Insurance premiums for vehicles', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'insurance')),
    ('home_insurance', 'Insurance premiums for homeowners or renters', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'insurance')),

-- Insert Subcategories for 'education'
    ('tuition', 'Tuition fees for schools and colleges', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'education')),
    ('books', 'Expenses for textbooks and study materials', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'education')),
    ('courses', 'Payments for courses or workshops', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'education')),

-- Insert Subcategories for 'maintenance'
    ('home_maintenance', 'Repairs and upkeep for home', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'maintenance')),
    ('vehicle_maintenance', 'Repairs and servicing for vehicles', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'maintenance')),

-- Insert Subcategories for 'subscription'
    ('streaming_services', 'Monthly subscriptions to streaming platforms', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'subscription')),
    ('magazines', 'Magazine and newspaper subscriptions', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'subscription')),

-- Insert Subcategories for 'personal_care'
    ('haircare', 'Expenses for haircuts and salon visits', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'personal_care')),
    ('skincare', 'Skincare products and treatments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'personal_care')),
    ('fitness', 'Gym memberships and fitness classes', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'personal_care')),

-- Insert Subcategories for 'taxes'
    ('income_tax', 'Income tax payments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'taxes')),
    ('property_tax', 'Property tax payments', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'taxes')),

-- Insert Subcategories for 'childcare'
    ('babysitting', 'Payments for babysitting services', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'childcare')),
    ('preschool', 'Expenses for preschool or daycare', (SELECT category_id FROM ExpenseCategory WHERE category_name = 'childcare'));
GO

-----------

-- Insert Main Categories
INSERT INTO Category (category_name, description, category_type)
VALUES 
    ('Variable Expenses', 'Expenses that vary monthly based on usage or consumption.', 'Variable'),
    ('Savings Expenses', 'Savings-related expenses.', 'Savings'),
    ('Fixed Expenses', 'Expenses that are the same amount every month.', 'Fixed'),
    ('Irregular Savings Expenses', 'Occasional savings expenses that occur irregularly.', 'Irregular Savings'),
    ('Targeted Savings Expenses', 'Specific savings goals with a target amount and timeframe.', 'Targeted Savings'),
    ('Additional Expenses', 'Additional criteria for classifying expenses.', 'Additional');

-- Insert Subcategories for Variable Expenses
INSERT INTO Category (category_name, description, parent_category_id, category_type)
VALUES 
    ('Groceries', 'Expenses for food and household supplies.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Personal Care Items', 'Pharmacy and other personal care products.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Fuel / Public Transportation', 'Transportation costs including fuel and public transit.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Parking', 'Expenses for vehicle parking.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Clothing and Shoes', 'Expenses on clothing and footwear.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Childcare', 'Expenses for daycare and child maintenance.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Work Lunch and Snacks', 'Meals and snacks purchased during work hours.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Eating Out', 'Expenses for dining out at restaurants.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Entertainment', 'Expenses for entertainment and recreational activities.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Tobacco / Alcohol', 'Expenses for tobacco and alcoholic products.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Lottery', 'Expenses for lottery tickets.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Child Maintenance', 'Support and maintenance for children.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Sports and Recreation', 'Expenses for sports, recreation, and other hobbies.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Hair Care Services', 'Costs for hair care and salon services.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Magazines / Newspapers / Books', 'Expenses for publications and books.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable'),
    ('Children’s Lessons and Activities', 'Expenses for children’s extracurricular activities.', (SELECT category_id FROM Category WHERE category_name = 'Variable Expenses'), 'Variable');

-- Insert Subcategories for Savings Expenses
INSERT INTO Category (category_name, description, parent_category_id, category_type)
VALUES 
    ('Irregular Savings Expenses', 'Occasional savings expenses that occur irregularly.', (SELECT category_id FROM Category WHERE category_name = 'Savings Expenses'), 'Irregular Savings'),
    ('Targeted Savings Expenses', 'Specific savings goals with a target amount and timeframe.', (SELECT category_id FROM Category WHERE category_name = 'Savings Expenses'), 'Targeted Savings');

-- Insert Subcategories for Fixed Expenses
INSERT INTO Category (category_name, description, parent_category_id, category_type)
VALUES 
    ('Mortgage', 'Monthly mortgage payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Rent', 'Monthly rent payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Property Tax', 'Monthly property tax payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Condo/HOA Fees', 'Monthly condo or homeowner association fees.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Home / Renter’s Insurance', 'Insurance for home or rented property.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Utility Bills', 'Monthly utility bills like cable, electricity, water, etc.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Car Lease / Loan Payments', 'Monthly car lease or loan payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Car Insurance', 'Monthly car insurance payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Life / Disability Insurance', 'Monthly life, disability, or health insurance payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Bank Fees', 'Monthly bank fees.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed'),
    ('Debt Payments', 'Monthly debt payments.', (SELECT category_id FROM Category WHERE category_name = 'Fixed Expenses'), 'Fixed');

-- Insert Additional Expenses as Questions for Classification
INSERT INTO Category (category_name, description, parent_category_id, category_type)
VALUES 
    ('Frequent and Regular', 'Does this expense occur frequently and regularly, remaining unchanged?', (SELECT category_id FROM Category WHERE category_name = 'Additional Expenses'), 'Additional'),
    ('Store Purchases', 'Do I buy it from a store? Can I control the amount spent?', (SELECT category_id FROM Category WHERE category_name = 'Additional Expenses'), 'Additional'),
    ('Advance Savings', 'Should I save in advance for this?', (SELECT category_id FROM Category WHERE category_name = 'Additional Expenses'), 'Additional');
