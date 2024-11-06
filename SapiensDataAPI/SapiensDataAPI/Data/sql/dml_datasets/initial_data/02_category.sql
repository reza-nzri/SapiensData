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
