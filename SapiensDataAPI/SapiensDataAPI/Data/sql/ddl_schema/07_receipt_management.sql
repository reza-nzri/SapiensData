USE SapeinsData;

CREATE TABLE Receipt (
    receipt_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    buy_datetime DATETIME,
    trace_number NVARCHAR(50),
    total_amount DECIMAL(18, 2),              -- Total amount for the receipt (e.g., 10€)
    cashback_amount DECIMAL(18, 2),           -- Amount of cash received as cashback (e.g., 15€)
    currency NVARCHAR(10),                    -- Currency used in the transaction (e.g., "EUR", "USD")
    total_loyalty DECIMAL(18, 2) DEFAULT 0,   -- Amount of loyalty discount or points applied to the receipt
    full_name_payment_method NVARCHAR(255),   -- e.g., "Kartenzahlung kontaktlos SEPA Lastschrift online"
    iban CHAR(34),
    receipt_image_path NVARCHAR(255),         -- File path or URL to the receipt image
    user_id INT,                              -- ID of the user who uploaded the image
    upload_date DATETIME DEFAULT GETDATE(),   -- Date the image was uploaded
    payment_method_id INT,
    store_id INT,
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id),
    FOREIGN KEY (store_id) REFERENCES Store(store_id),
    FOREIGN KEY (user_id) REFERENCES [User](user_id)
);
GO

CREATE TABLE TaxRate (
    tax_rate_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    tax_code CHAR(3),                           -- Tax code (e.g., A, B, C)
    vat_rate DECIMAL(5, 2),            -- VAT rate in percentage (e.g., 7.00, 19.00, 0.00 in %)
    description NVARCHAR(50),
    net_amount DECIMAL(5, 2),          -- Total net sales amount excluding VAT (e.g., 7.00, 19.00, 0.00 in %)
    vat_amount DECIMAL(5, 2),                   -- Total VAT amount (taxed)
    receipt_id INT,
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id)
);
GO

CREATE TABLE ReceiptTaxDetail (
    receipt_tax_detail_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    receipt_id INT NOT NULL,                    -- Foreign key to Receipt
    tax_rate_id INT NOT NULL,                   -- Foreign key to TaxRate
    net_sales_amount DECIMAL(18, 2),            -- Net sales amount for this tax rate
    vat_amount DECIMAL(18, 2),                  -- VAT amount for this tax rate
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id) ON DELETE CASCADE,
    FOREIGN KEY (tax_rate_id) REFERENCES TaxRate(tax_rate_id) ON DELETE CASCADE
);
GO

CREATE TABLE ReceiptPayment (
    receipt_payment_id INT PRIMARY KEY IDENTITY(1,1),
    receipt_id INT,                           -- Foreign key to Receipt
    payment_method_id INT,                    -- Foreign key to PaymentMethod
    amount DECIMAL(18, 2),                    -- Amount paid using this payment method
    FOREIGN KEY (receipt_id) REFERENCES Receipt(receipt_id),
    FOREIGN KEY (payment_method_id) REFERENCES PaymentMethod(payment_method_id)
);
GO
