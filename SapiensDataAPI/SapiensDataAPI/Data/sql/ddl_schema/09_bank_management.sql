USE SapeinsData;

CREATE TABLE Bank (
    bank_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    bank_name NVARCHAR(100) NOT NULL,                        -- Name of the bank (e.g., "Deutsche Bank")
    api_endpoint NVARCHAR(255) NOT NULL,                     -- URL endpoint for the bank's API
    api_version NVARCHAR(20) DEFAULT 'v1',                   -- API version used for integration
    contact_email NVARCHAR(100),                             -- Support or contact email for the bank
    contact_phone NVARCHAR(20),                              -- Support or contact phone for the bank
    created_at DATETIME DEFAULT GETDATE(),                   -- Timestamp when the bank was added
    updated_at DATETIME DEFAULT GETDATE()                    -- Timestamp for the last update to bank details
);
GO

CREATE TABLE BankAccount (
    account_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                    -- Foreign key to [User] table
    bank_id INT NOT NULL,                                    -- Foreign key to Bank table
    account_number NVARCHAR(50) UNIQUE,                      -- [User]'s bank account number (In future features: encrypted)
    account_type NVARCHAR(50) CHECK (                        -- Type of bank account (e.g., "checking", "savings", "credit")
        account_type IN ('checking', 'savings', 'credit', 'investment', 'loan')
    ),
    iban NVARCHAR(34),                                       -- International Bank Account Number
    currency NVARCHAR(10) DEFAULT 'EUR',                     -- Currency of the account balance
    api_access_token NVARCHAR(255) UNIQUE,                   -- API access token for secure bank connection
    account_balance DECIMAL(18, 2) DEFAULT 0,                -- Current balance in the account
    last_synced_at DATETIME,                                 -- Timestamp of the last successful balance sync
    created_at DATETIME DEFAULT GETDATE(),                   -- Timestamp when the account was added
    updated_at DATETIME DEFAULT GETDATE(),                   -- Timestamp for the last update to account details
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE CASCADE,
    FOREIGN KEY (bank_id) REFERENCES Bank(bank_id) ON DELETE CASCADE
);
GO

CREATE TABLE BankTransaction (
    transaction_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    account_id INT NOT NULL,                                 -- Foreign key to BankAccount table
    transaction_date DATETIME NOT NULL,                      -- Date of the transaction
    transaction_type NVARCHAR(50) CHECK (                    -- Type of transaction (e.g., "deposit", "withdrawal", "payment")
        transaction_type IN ('deposit', 'withdrawal', 'payment', 'transfer', 'fee', 'interest')
    ),
    amount DECIMAL(18, 2) NOT NULL,                          -- Amount of the transaction
    description NVARCHAR(255),                               -- Description of the transaction
    balance_after DECIMAL(18, 2),                            -- Account balance after the transaction
    created_at DATETIME DEFAULT GETDATE(),                   -- Timestamp when the transaction was recorded
    updated_at DATETIME DEFAULT GETDATE(),                   -- Timestamp for the last update to transaction details
    FOREIGN KEY (account_id) REFERENCES BankAccount(account_id) ON DELETE CASCADE
);
GO
