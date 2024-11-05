USE SapeinsData;

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
GO

CREATE TABLE CompanyAddress (
    company_address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    company_id INT,
    address_id INT,
    is_default BIT DEFAULT 0,
    address_type NVARCHAR(50) NOT NULL UNIQUE,                 -- Examples: "Home", "Work", "Billing", "Shipping"
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (company_id) REFERENCES Company(company_id),
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);
GO
