USE SapeinsData;

CREATE TABLE IncomeCategory (
    income_category_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    category_name NVARCHAR(50) NOT NULL UNIQUE,       -- Name of the income category (e.g., "salary", "bonus")
    description NVARCHAR(255),                        -- Brief description of the income category
    parent_category_id INT,                           -- Self-referencing foreign key for subcategories
    FOREIGN KEY (parent_category_id) REFERENCES IncomeCategory(income_category_id) ON DELETE NO ACTION
);
GO

CREATE TABLE Income (
    income_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),        -- Unique identifier for each income record
    user_id INT NOT NULL,                                    -- ID of the [User] associated with the income
    income_date DATE,                               -- Date the income was receiv
    income_category_id INT,
    source_type NVARCHAR(20) CHECK (source_type IN ('[User]', 'company', 'external_person')), -- Indicates if the source is a [User], company, or an external person
    source_user_id INT,                                      -- If the source is a registered [User], reference to the [User] table
    source_company_id INT,                                   -- If the source is a company, reference to the Company table
    source_name NVARCHAR(100),                               -- First and last name for an external person, or company name if applicable
    description NVARCHAR(255),                               -- Description or notes regarding the income
    gross_amount DECIMAL(18, 2),                             -- Total gross income before any deductions or taxes "Brutto"
    tax_amount DECIMAL(18, 2) DEFAULT 0,                     -- Amount withheld for taxes
    net_amount DECIMAL(18, 2),                               -- Net income after deductions (computed column)
    currency NVARCHAR(10) DEFAULT 'EUR',                     -- Currency in which the income was received (EUR, USD)
    is_recurring BIT DEFAULT 0,                              -- Indicates if this income is part of a recurring series
    frequency_id INT,
    payment_method_id INT,
    payer_name NVARCHAR(100),                                -- Name of the person or entity that paid the income
    received_at DATETIME DEFAULT GETDATE(),                  -- Timestamp of when the income was recorded in the system
    last_updated_at DATETIME DEFAULT GETDATE(),              -- Timestamp for the last update to the income record
    FOREIGN KEY (user_id) REFERENCES [User](user_id),
    FOREIGN KEY (income_category_id) REFERENCES IncomeCategory(income_category_id),
    FOREIGN KEY (source_user_id) REFERENCES [User](user_id),
    FOREIGN KEY (source_company_id) REFERENCES Company(company_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (frequency_id) REFERENCES Frequency(frequency_id)
);
GO

CREATE TABLE ExpenseCategory (
    expense_category_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    category_name NVARCHAR(50) NOT NULL UNIQUE,    -- Name of the expense category (e.g., "housing", "utilities")
    description NVARCHAR(255),                     -- Brief description of the category
    budget DECIMAL(18, 2) DEFAULT 0,               -- Allocated budget for this category
    parent_category_id INT,                        -- Self-referencing foreign key for subcategories
    FOREIGN KEY (parent_category_id) REFERENCES ExpenseCategory(expense_category_id) ON DELETE NO ACTION
);
GO

CREATE TABLE Expense (
    expense_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),     -- Unique identifier for each expense record
    user_id INT NOT NULL,                                  -- ID of the [User] associated with the expense
    source_type NVARCHAR(20) CHECK (source_type IN ('[User]', 'company', 'external_person')), -- Indicates if the source is a [User], company, or an external person
    source_user_id INT,                                    -- If the source is a registered [User], reference to the [User] table
    source_company_id INT,                                 -- If the source is a company, reference to the Company table
    source_first_name NVARCHAR(50),                        -- First name for an external person if applicable
    source_last_name NVARCHAR(50),                         -- last name for an external person if applicable
    source_company_name NVARCHAR(100),                     -- for an external company if applicable
    expense_date DATE NOT NULL,                            -- Date the expense was incurred
    expense_category_id INT, 
    description NVARCHAR(255),                             -- Description or notes regarding the expense
    amount DECIMAL(18, 2) NOT NULL,                        -- Total amount of the expense
    currency NVARCHAR(10) DEFAULT 'EUR',                   -- Currency used in the transaction (e.g., "EUR", "USD")
    payment_method_id INT,                                 -- ID of the payment method used for the expense
    payment_status NVARCHAR(20) CHECK (payment_status IN (
        'completed', 'pending', 'failed', 'refunded'
    )) DEFAULT 'completed',                                -- Status of the payment
	receipt_id INT,
    tax_rate_id INT,                                       -- if applicable; FK linking to the Receipt table, if a receipt is associated
    frequency_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),                 -- Timestamp when the expense was added
    last_updated_at DATETIME DEFAULT GETDATE(),            -- Timestamp for the last update to the expense record
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (source_user_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (source_company_id) REFERENCES Company(company_id),
    FOREIGN KEY (expense_category_id) REFERENCES ExpenseCategory(expense_category_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id),
    FOREIGN KEY (tax_rate_id) REFERENCES TaxRate(tax_rate_id),
    FOREIGN KEY (frequency_id) REFERENCES Frequency(frequency_id)
);
GO

CREATE TABLE Savings (
    savings_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),           
    user_id INT NOT NULL,                                        -- Foreign key to [User] table (indicating who owns this savings entry)
    savings_goal NVARCHAR(255) NOT NULL,                         -- Name or purpose of the savings goal (e.g., "Vacation Fund")
    target_amount DECIMAL(18, 2) NOT NULL,                       -- Total target amount for the savings goal
    saved_amount DECIMAL(18, 2) DEFAULT 0,                       -- Amount saved so far toward the target
    start_date DATE NOT NULL DEFAULT GETDATE(),                  -- Date when the savings plan started
    target_date DATE,                                            -- Planned date by which to achieve the savings goal
    frequency_id INT,
    contribution_amount DECIMAL(18, 2),                          -- Suggested or actual contribution per period
    interest_rate DECIMAL(5, 2) DEFAULT 0,                       -- Annual interest rate applied to the savings, if applicable (e.g., for investment accounts)
    accumulated_interest DECIMAL(18, 2) DEFAULT 0,               -- Interest earned so far on the savings, if applicable
    status NVARCHAR(20) CHECK (status IN (                       -- Status of the savings goal (e.g., "in-progress", "achieved", "on-hold", "canceled")
        'in-progress', 'achieved', 'on-hold', 'canceled'
    )) NOT NULL DEFAULT 'in-progress',
    notes NVARCHAR(500),                                         -- Additional notes or comments regarding the savings goal
    last_updated_at DATETIME DEFAULT GETDATE(),                  -- Timestamp for the last update to the savings record
    created_at DATETIME DEFAULT GETDATE(),                       -- Timestamp for the creation of the savings record
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE CASCADE,
    FOREIGN KEY (frequency_id) REFERENCES Frequency(frequency_id)
);
GO

CREATE TABLE Debt (
    debt_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                     -- Foreign key to [User] table (who owes the debt)
    debt_type NVARCHAR(50) CHECK (debt_type IN (              -- Type of debt (e.g., "personal loan", "credit card", "mortgage")
        'personal loan', 'credit card', 'mortgage', 'loan from friend', 'other'
    )),
    amount_owed DECIMAL(18, 2) NOT NULL,                      -- Total amount owed
    interest_rate DECIMAL(5, 2) DEFAULT 0,                    -- Interest rate on the debt
    due_date DATE,                                            -- Due date for debt repayment
    creditor_user_id INT,                                     -- Foreign key to [User] table for registered creditor
    creditor_company_id INT,                                  -- Foreign key to Company table for creditor if it's a company
    creditor_first_name NVARCHAR(50),                         -- First name of an external person (if not in app)
    creditor_last_name NVARCHAR(50),                          -- Last name of an external person (if not in app)
    creditor_company_name NVARCHAR(100),                      -- Company name if creditor is an external company
    status NVARCHAR(20) CHECK (status IN (                    -- Status of the debt (e.g., "open", "closed", "in progress")
        'open', 'closed', 'in progress', 'overdue'
    )) NOT NULL DEFAULT 'open',
    description NVARCHAR(255),                                -- Description of the debt purpose (e.g., "For travel to Dortmund")
    frequency NVARCHAR(50) CHECK (frequency IN (              -- Payment frequency (e.g., "monthly", "quarterly")
        'one-time', 'weekly', 'bi-weekly', 'monthly', 'quarterly', 'annually'
    )),
    times_remaining INT,                                      -- Remaining times for installment payments
    next_reminder DATETIME,                                   -- Date for the next payment reminder
    created_at DATETIME DEFAULT GETDATE(),                    -- Timestamp for debt entry creation
    updated_at DATETIME DEFAULT GETDATE(),                    -- Timestamp for the last update to debt details
    FOREIGN KEY (creditor_user_id) REFERENCES [User](user_id) ON DELETE CASCADE,
    FOREIGN KEY (creditor_company_id) REFERENCES Company(company_id)
);
GO

CREATE TABLE Investments (
    investment_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                     -- Foreign key to [User] table
    investment_type NVARCHAR(50) CHECK (investment_type IN (  -- Type of investment (e.g., "stocks", "bonds", "real estate")
        'stocks', 'bonds', 'real estate', 'mutual funds', 'savings account', 'other'
    )),
    amount DECIMAL(18, 2) NOT NULL,                           -- Amount invested
    loaned_to_user_id INT,                                    -- FK to [User] table if money was loaned to an app [User]
    loaned_to_company_id INT,                                 -- FK to Company table if money was loaned to a company
    loaned_to_first_name NVARCHAR(50),                        -- First name if loaned to an external person not in app
    loaned_to_last_name NVARCHAR(50),                         -- Last name if loaned to an external person not in app
    investment_date DATE NOT NULL DEFAULT GETDATE(),          -- Date of the investment
    description NVARCHAR(255),                                -- Optional description of the investment
    interest_rate DECIMAL(5, 2),                              -- Interest or return rate for the investment
    created_at DATETIME DEFAULT GETDATE(),                    -- Timestamp for the creation of the investment record
    updated_at DATETIME DEFAULT GETDATE(),                    -- Timestamp for the last update to investment details
    FOREIGN KEY (loaned_to_user_id) REFERENCES [User](user_id) ON DELETE CASCADE,
    FOREIGN KEY (loaned_to_company_id) REFERENCES Company(company_id)
);
GO
