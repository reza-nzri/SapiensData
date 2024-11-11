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
GO

CREATE TABLE PaymentMethod (
    payment_method_id INT PRIMARY KEY IDENTITY(1,1), -- Unique identifier for each payment method
    name NVARCHAR(50),                          -- Full name of the payment method (e.g., "Credit Card")
    abbreviation NVARCHAR(10),                  -- Abbreviation, if applicable (e.g., "CC" for Credit Card)
    description NVARCHAR(255)                   -- Description of the payment method
);
GO

CREATE TABLE UnitType (
    unit_id INT PRIMARY KEY IDENTITY(1,1),
    unit_name NVARCHAR(50),           -- Name of the unit (e.g., "kg", "pcs")
    unit_type NVARCHAR(50)            -- Type of the unit (e.g., "weight", "quantity")
);
GO

CREATE TABLE Frequency (
    frequency_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    frequency_name NVARCHAR(50) NOT NULL UNIQUE,  -- Frequency type (e.g., "one-time", "daily")
    description NVARCHAR(255),                    -- Description of the frequency (e.g., "Occurs once only", "Occurs daily")
    days_interval INT                            -- Number of days for the interval (e.g., 1 for daily, 7 for weekly)
);
GO

CREATE TABLE Category (
    category_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),               -- Unique identifier for each financial or shopping category
    category_name NVARCHAR(100) NOT NULL,                             -- Name of the category (e.g., "Variable Expenses", "Groceries", "fruit", "vegetables", "sauce")
    description NVARCHAR(500),                                        -- Detailed description of the category (e.g., for "financial", or groceries" or "shopping" items)
    parent_category_id INT,                                           -- Self-referencing foreign key for subcategories
    category_type NVARCHAR(50) CHECK (                                -- Only for financial category: Type of the category (e.g., "Variable", "Fixed", "Savings", "Additional")
        category_type IN ('Variable', 'Fixed', 'Savings', 'Irregular Savings', 'Targeted Savings', 'Additional')
    ),
    created_at DATETIME DEFAULT GETDATE(),                            -- Timestamp for the creation of the category
    updated_at DATETIME DEFAULT GETDATE(),                            -- Timestamp for the last update to the category
    FOREIGN KEY (parent_category_id) REFERENCES Category(category_id) ON DELETE NO ACTION -- FK for self-referencing parent category
);
GO
