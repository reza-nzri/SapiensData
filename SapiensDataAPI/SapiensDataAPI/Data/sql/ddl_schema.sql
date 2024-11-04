CREATE DATABASE SapeinsData;
GO

USE SapeinsData;

CREATE TABLE Address (
    address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    street NVARCHAR(100),
    house_number NVARCHAR(10),
    postal_code NVARCHAR(10),
    city NVARCHAR(50),
    state NVARCHAR(50),
    country NVARCHAR(50)
);

CREATE TABLE PaymentMethod (
    payment_method_id INT PRIMARY KEY IDENTITY(1,1), -- Unique identifier for each payment method
    name NVARCHAR(50),                          -- Full name of the payment method (e.g., "Credit Card")
    abbreviation NVARCHAR(10),                  -- Abbreviation, if applicable (e.g., "CC" for Credit Card)
    description NVARCHAR(255)                   -- Description of the payment method
);

CREATE TABLE UnitType (
    unit_id INT PRIMARY KEY IDENTITY(1,1),
    unit_name NVARCHAR(50),           -- Name of the unit (e.g., "kg", "pcs")
    unit_type NVARCHAR(50)            -- Type of the unit (e.g., "weight", "quantity")
);

-- User-defined labels for categorization
CREATE TABLE Label (
    label_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    label_name NVARCHAR(50) NOT NULL UNIQUE,              -- Name of the label (e.g., "organic", "essential")
    description NVARCHAR(255),                            -- Brief description of what this label represents
    color_code NVARCHAR(7),                               -- Optional HEX color code for displaying the label (e.g., "#FF5733")
);

CREATE TABLE LabelAssignment (
    label_assignment_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    label_id INT NOT NULL,                                -- Foreign key to the Label table
    entity_type NVARCHAR(50) NOT NULL,                    -- Type of the entity (e.g., "Product", "Expense", "Income")
    entity_id INT NOT NULL,                               -- ID of the entity being labeled (e.g., product_id, expense_id)
    assigned_at DATETIME DEFAULT GETDATE(),               -- Timestamp when the label was assigned
    FOREIGN KEY (label_id) REFERENCES Label(label_id) ON DELETE CASCADE
);

CREATE TABLE Store (
    store_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    name NVARCHAR(100),
    brand_name NVARCHAR(100),
    tax_id NVARCHAR(20),
    address_id INT,
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE StoreAddress (
    company_address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    store_id INT,
    address_id INT,
    is_default BIT DEFAULT 0,
    address_type NVARCHAR(50) NOT NULL UNIQUE                 -- Examples: "Home", "Work", "Billing", "Shipping"
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (store_id) REFERENCES Store(store_id),
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE Receipt (
    receipt_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    buy_datetime DATETIME,
    trace_number NVARCHAR(50),
    total_amount DECIMAL(18, 2),              -- Total amount for the receipt (e.g., 10€)
    cashback_amount DECIMAL(18, 2),           -- Amount of cash received as cashback (e.g., 15€)
    currency NVARCHAR(10),                    -- Currency used in the transaction (e.g., "EUR", "USD")
    total_loyalty DECIMAL(18, 2) DEFAULT 0,   -- Amount of loyalty discount or points applied to the receipt
    full_name_payment_method NVARCHAR(255),
    iban CHAR(34),
    receipt_image_path NVARCHAR(255),         -- File path or URL to the receipt image
    payment_method_id INT,
    store_id INT,
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (store_id) REFERENCES Store(store_id)
);

CREATE TABLE TaxRate (
    tax_rate_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    tax_code CHAR(3),                  -- Tax code (e.g., A, B, C)
    vat_rate DECIMAL(5, 2) NOT NULL,            -- VAT rate in percentage (e.g., 7.00, 19.00, 0.00 in %)
    net_amount DECIMAL(5, 2) NOT NULL,          -- Total net sales amount excluding VAT (e.g., 7.00, 19.00, 0.00 in %)
    vat_amount DECIMAL(5, 2),                   -- Total VAT amount (taxed)
    receipt_id INT,
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id)
);

CREATE TABLE ReceiptTaxDetail (
    receipt_tax_detail_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    receipt_id INT NOT NULL,                    -- Foreign key to Receipt
    tax_rate_id INT NOT NULL,                   -- Foreign key to TaxRate
    net_sales_amount DECIMAL(18, 2),            -- Net sales amount for this tax rate
    vat_amount DECIMAL(18, 2),                  -- VAT amount for this tax rate
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id) ON DELETE CASCADE,
    FOREIGN KEY (tax_rate_id) REFERENCES TaxRate(tax_rate_id) ON DELETE CASCADE
);

CREATE TABLE ReceiptPayment (
    receipt_payment_id INT PRIMARY KEY IDENTITY(1,1),
    receipt_id INT,                           -- Foreign key to Receipt
    payment_method_id INT,                    -- Foreign key to PaymentMethod
    amount DECIMAL(18, 2),                    -- Amount paid using this payment method
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id)
);

CREATE TABLE Product (
    product_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    full_name NVARCHAR(255),              -- Full name from receipt
    short_name NVARCHAR(100),             -- Simplified name
    store_description NVARCHAR(500),      -- Store-provided description
    user_description NVARCHAR(500),       -- User-defined description
    quantity INT,                         -- Quantity of packages purchased
    q_unit INT,                           -- Unit for quantity (e.g., "pcs", "pack")
    items_per_package INT,                -- Number of items per package (e.g., 3 batteries per pack)
    ipp_unit INT,                         -- Unit for Number of items per package (e.g., "pcs")
    inline_total_weight DECIMAL(10, 3),   -- Weight for weighted items
    weight_per_unit DECIMAL(10, 3),       -- Weight per individual unit (e.g., 0.5 kg per bottle)
    w_unit INT,                           -- Unit for weight (e.g., "kg", "g")
    inline_total_volume DECIMAL(10, 3),   -- Volume for volumetric items
    volume_per_unit DECIMAL(10, 3),       -- Volume per individual unit (e.g., 0.2 L per bottle)
    v_unit INT,                           -- Unit for volume (e.g., "l", "ml")
    inline_total_price DECIMAL(18, 2),    -- Total price for this line item on the receipt (if specified by store)
    unit_price DECIMAL(18, 2),            -- Price per unit (if specified by store)
    up_unit INT,                          -- Unit for unit_price (e.g., "kg", "g", "L")
    vat_rate DECIMAL(5, 2),               -- VAT rate for the product (e.g., 19.00 for 19%)
    is_bio BIT,                           -- Indicator for organic (bio) product (1 if bio, 0 otherwise)
    code NVARCHAR(50),                    -- Product code
    category_id INT,                      -- Placeholder if a Category table exists
    brand NVARCHAR(50),                   -- Brand of the product
    origin_country NVARCHAR(50),          -- Country of origin
    expiration_date DATE,                 -- Expiration date for perishables
    tax_code CHAR(3),                     -- (e.g. A, B, C)
    FOREIGN KEY (q_unit) REFERENCES UnitType(unit_id),
    FOREIGN KEY (ipp_unit) REFERENCES UnitType(unit_id),
    FOREIGN KEY (w_unit) REFERENCES UnitType(unit_id),
    FOREIGN KEY (v_unit) REFERENCES UnitType(unit_id),
    FOREIGN KEY (up_unit) REFERENCES UnitType(unit_id)
);

CREATE TABLE Company (
    company_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,                              -- Full name of the company
    industry NVARCHAR(50),                                    -- Industry or sector (e.g., 'Finance', 'Technology')
    description NVARCHAR(255),                                -- Brief description of the company
    registration_number NVARCHAR(50) UNIQUE,                  -- Unique company registration or ID number
    tax_id NVARCHAR(50) UNIQUE,                               -- Tax identification number (if applicable)
    website NVARCHAR(255),                                    -- Company website URL
    contact_email NVARCHAR(100),                              -- Primary contact email
    contact_phone NVARCHAR(20),                               -- Primary contact phone number
    founded_date DATE                                         -- Date the company was founded
);

CREATE TABLE CompanyAddress (
    company_address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    company_id INT,
    address_id INT,
    is_default BIT DEFAULT 0,
    address_type NVARCHAR(50) NOT NULL UNIQUE                 -- Examples: "Home", "Work", "Billing", "Shipping"
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (company_id) REFERENCES Company(company_id),
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE User (
    user_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    username NVARCHAR(50) UNIQUE NOT NULL,         -- Username for login
    password_hash NVARCHAR(255) NOT NULL,          -- Hashed password for secure storage
    prefix NVARCHAR(10),                           -- Name prefix (e.g., Mr., Dr.)
    first_name NVARCHAR(50),                       -- User's first name
    middle_name NVARCHAR(50),                      -- Middle name or initial
    last_name NVARCHAR(50),                        -- User's last name
    suffix NVARCHAR(10),                           -- Name suffix (e.g., Jr., Sr.)
    nickname NVARCHAR(50),                         -- User's preferred nickname
    gender CHAR(1) CHECK (gender IN ('M', 'F', 'O')), -- Gender: 'M' = Male, 'F' = Female, 'O' = Other
    birthday DATE,                                 -- User's date of birth
    profile_picture_path NVARCHAR(255),            -- File path or URL to profile picture
    account_email NVARCHAR(100) UNIQUE NOT NULL,   -- Primary account email
    recovery_email NVARCHAR(100),                  -- Email for account recovery
    account_phone NVARCHAR(20),                    -- Primary phone number for account
    recovery_phone NVARCHAR(20),                   -- Phone number for account recovery
    alt_emails NVARCHAR(255),                      -- Comma-separated list of alternate emails with titles (e.g., "work: example@work.com, personal: example@home.com")
    company_name NVARCHAR(100),                    -- User's company name
    job_title NVARCHAR(100),                       -- Job title
    department NVARCHAR(100),                      -- Department in the company
    app_language NVARCHAR(10) DEFAULT 'en',        -- Preferred app language (e.g., 'en', 'de')
    website NVARCHAR(255),                         -- Personal or professional website URL
    linkedin NVARCHAR(255),
    facebook NVARCHAR(255),
    instagram NVARCHAR(255),
    twitter NVARCHAR(255),
    github NVARCHAR(255),
    youtube NVARCHAR(255),
    tiktok NVARCHAR(255),
    snapchat NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),         -- Account creation date and time
    updated_at DATETIME DEFAULT GETDATE(),         -- Last update date and time
    last_login DATETIME,                           -- Last login timestamp
    role NVARCHAR(50) DEFAULT 'user',              -- User role (e.g., 'user', 'admin')
    status NVARCHAR(20) DEFAULT 'active',          -- Account status (e.g., 'active', 'suspended')
);

CREATE TABLE UserAddress (
    company_address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT,
    address_id INT,
    is_default BIT DEFAULT 0,
    address_type NVARCHAR(50) NOT NULL UNIQUE                 -- Examples: "Home", "Work", "Billing", "Shipping"
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES User(user_id),
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE UserRelationship (
    relationship_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                    -- The user who has the relationship
    related_user_id INT NOT NULL,                            -- The related user's ID
    relationship_type NVARCHAR(50) CHECK (relationship_type IN (
    'friend', 'family', 'colleague', 'acquaintance', 'neighbor', 
    'classmate', 'teammate', 'mentor', 'supervisor', 'subordinate', 'partner', 
    'spouse', 'sibling', 'parent', 'child', 'other'
    )),
    created_at DATETIME DEFAULT GETDATE(),                   -- Timestamp when the relationship was added
    FOREIGN KEY (user_id) REFERENCES User(user_id) ON DELETE CASCADE,
    FOREIGN KEY (related_user_id) REFERENCES User(user_id) ON DELETE CASCADE
);

CREATE TABLE UserSession (
    session_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                -- Foreign key to User
    login_time DATETIME DEFAULT GETDATE(),               -- Login timestamp
    logout_time DATETIME,                                -- Logout timestamp
    ip_address NVARCHAR(45),                             -- IP address from which the user logged in
    device NVARCHAR(100),                                -- Device information or user agent
    browser NVARCHAR(50),                                -- Browser used during session
    operating_system NVARCHAR(50),                       -- Operating system of the device
    session_token NVARCHAR(255) UNIQUE,                  -- Unique session token for authentication
    is_active BIT DEFAULT 1,                             -- Status of session: 1 = active, 0 = inactive
    location NVARCHAR(100),                              -- Approximate location based on IP
    login_attempts INT DEFAULT 1,                        -- Number of login attempts during this session
    failed_login_attempts INT DEFAULT 0,                 -- Number of failed login attempts
    session_duration AS DATEDIFF(MINUTE, login_time, logout_time),  -- Computed duration of the session in minutes
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE IncomeCategory (
    income_category_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    category_name NVARCHAR(50) NOT NULL UNIQUE,       -- Name of the income category (e.g., "salary", "bonus")
    description NVARCHAR(255),                        -- Brief description of the income category
    parent_category_id INT,                           -- Self-referencing foreign key for subcategories
    FOREIGN KEY (parent_category_id) REFERENCES IncomeCategory(income_category_id) ON DELETE SET NULL
);

CREATE TABLE Frequency (
    frequency_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    frequency_name NVARCHAR(50) NOT NULL UNIQUE,  -- Frequency type (e.g., "one-time", "daily")
    description NVARCHAR(255),                    -- Description of the frequency (e.g., "Occurs once only", "Occurs daily")
    days_interval INT,                            -- Number of days for the interval (e.g., 1 for daily, 7 for weekly)
);

CREATE TABLE Income (
    income_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),        -- Unique identifier for each income record
    user_id INT NOT NULL,                                    -- ID of the user associated with the income
    income_date DATE NOT NULL,                               -- Date the income was receiv
    income_category_id INT,
    source_type NVARCHAR(20) CHECK (source_type IN ('user', 'company', 'external_person')), -- Indicates if the source is a user, company, or an external person
    source_user_id INT,                                      -- If the source is a registered user, reference to the User table
    source_company_id INT,                                   -- If the source is a company, reference to the Company table
    source_name NVARCHAR(100),                               -- First and last name for an external person, or company name if applicable
    description NVARCHAR(255),                               -- Description or notes regarding the income
    gross_amount DECIMAL(18, 2),                             -- Total gross income before any deductions or taxes "Brutto"
    tax_amount DECIMAL(18, 2) DEFAULT 0,                     -- Amount withheld for taxes
    net_amount DECIMAL(18, 2),                               -- Net income after deductions (computed column)
    currency NVARCHAR(10) DEFAULT 'EUR',                     -- Currency in which the income was received (EUR, USD)
    is_recurring BIT DEFAULT 0,                              -- Indicates if this income is part of a recurring series
    frequency_id INT NOT NULL,
    payment_method_id INT,
    payer_name NVARCHAR(100),                                -- Name of the person or entity that paid the income
    received_at DATETIME DEFAULT GETDATE(),                  -- Timestamp of when the income was recorded in the system
    last_updated_at DATETIME DEFAULT GETDATE(),              -- Timestamp for the last update to the income record
    FOREIGN KEY (user_id) REFERENCES User(user_id),
    FOREIGN KEY (income_category_id) REFERENCES IncomeCategory(income_category_id),
    FOREIGN KEY (source_user_id) REFERENCES User(user_id),
    FOREIGN KEY (source_company_id) REFERENCES Company(company_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (frequency_id) REFERENCES Frequency(frequency_id)
);

CREATE TABLE ExpenseCategory (
    expense_category_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    category_name NVARCHAR(50) NOT NULL UNIQUE,    -- Name of the expense category (e.g., "housing", "utilities")
    description NVARCHAR(255),                     -- Brief description of the category
    budget DECIMAL(18, 2) DEFAULT 0,               -- Allocated budget for this category
    parent_category_id INT,                        -- Self-referencing foreign key for subcategories
    FOREIGN KEY (parent_category_id) REFERENCES ExpenseCategory(expense_category_id) ON DELETE SET NULL
);

CREATE TABLE Expense (
    expense_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),     -- Unique identifier for each expense record
    user_id INT NOT NULL,                                  -- ID of the user associated with the expense
    source_type NVARCHAR(20) CHECK (source_type IN ('user', 'company', 'external_person')), -- Indicates if the source is a user, company, or an external person
    source_user_id INT,                                     -- If the source is a registered user, reference to the User table
    source_company_id INT,                                  -- If the source is a company, reference to the Company table
    source_name NVARCHAR(100),                              -- First and last name for an external person, or company name if applicable
    expense_date DATE NOT NULL,                             -- Date the expense was incurred
    expense_category_id INT, 
    description NVARCHAR(255),                             -- Description or notes regarding the expense
    amount DECIMAL(18, 2) NOT NULL,                        -- Total amount of the expense
    currency NVARCHAR(10) DEFAULT 'EUR',                   -- Currency used in the transaction (e.g., "EUR", "USD")
    payment_method_id INT,                                 -- ID of the payment method used for the expense
    payment_status NVARCHAR(20) CHECK (payment_status IN (
        'completed', 'pending', 'failed', 'refunded'
    )) DEFAULT 'completed',                                -- Status of the payment
    tax_rate_id INT,                                       -- if applicable; FK linking to the Receipt table, if a receipt is associated
    frequency_id INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),                 -- Timestamp when the expense was added
    last_updated_at DATETIME DEFAULT GETDATE(),            -- Timestamp for the last update to the expense record
    FOREIGN KEY (user_id) REFERENCES User(user_id) ON DELETE CASCADE,
    FOREIGN KEY (source_user_id) REFERENCES User(user_id) ON DELETE CASCADE,
    FOREIGN KEY (source_company_id) REFERENCES Company(company_id),
    FOREIGN KEY (expense_category_id) REFERENCES ExpenseCategory(expense_category_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id),
    FOREIGN KEY (tax_rate_id) REFERENCES TaxRate(tax_rate_id),
    FOREIGN KEY (frequency_id) REFERENCES Frequency(frequency_id)
);
GO


/*
Savings: savings_goal, 
Debt: debt_type, amount_owed, interest_rate, due_date, ID of the creditor, Status (open usw), Description (bsp: For travel to dortmond), Freq. Times (wie oft muss man in ratt zahlen), Next Reminder
Investments` Tabelle: investment_type, amount, investment_date
BudgetCategories: category_name` (z.B. "Lebensmittel", "Miete", "Transport"), monthly / weekly / usw budget
*/

/*
Variable Expenses:
Groceries
Personal Care Items (Pharmacy)
Fuel / Public Transportation
Parking
Clothing and Shoes
Childcare
Work Lunch and Snacks
Eating Out
Entertainment
Tobacco / Alcohol
Lottery
Child Maintenance
Sports and Recreation, Other Hobbies
Hair Care Services / Salon
Magazines / Newspapers / Books
Children’s Lessons and Activities
*/

/*
Savings Expenses:
Irregular Savings Expenses
Targeted Savings Expenses
*/

/*
Fixed Expenses:
Mortgage
Rent
Property Tax (if paid monthly)
Condo/HOA Fees
Home / Renter’s Insurance
Utility Bills (Cable, Cell, Electricity, Water, etc.)
Car Lease / Loan Payments
Car Insurance (if paid monthly)
Life / Disability / Extended Health Insurance (or others)
Bank Fees
Debt Payments for Your Debt Repayment Plan
*/

/*
Irregular Savings Expenses:
Property Tax (if paid quarterly or annually)
Home Insurance (if paid annually)
Car Insurance (if paid quarterly or annually)
Clothing and Shoes (if purchased once or twice a year)
Healthcare Expenses
Veterinary Bills
Gifts
Car Maintenance
*/

/*
Targeted Savings Expenses:
Goals that we save and invest for to purchase or achieve something
Retirement Savings
Determine how much you need to save, when you need to save it by, and divide by the number of months left until that date. This will show how much you need to save each month. This type of savings is not accessible until the event occurs.
Emergency Savings
Travel Prepayment Savings
Education Savings
*/

/*
Additional Expenses:
1. Does this expense occur frequently and regularly and remain unchanged? (Fixed Expenses)
2. Do I buy it from a store? Can I control how much I spend on this expense? (Variable)
3. Should I save in advance for this? (Savings)
*/
