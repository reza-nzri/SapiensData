USE SapeinsData;

CREATE TABLE Store (
    name NVARCHAR(100),
    brand_name NVARCHAR(100),
    tax_id NVARCHAR(20),

  -- FK(address_id): Address(address_id)
    street NVARCHAR(100),
    house_number NVARCHAR(10),
    postal_code NVARCHAR(10),
    city NVARCHAR(50),
    state NVARCHAR(50),
    country NVARCHAR(50),

    address_type NVARCHAR(50) UNIQUE                 -- Examples: "Home", "Work", "Billing", "Shipping" --> StoreAddress(company_address_id)
);
GO

CREATE TABLE Product (
    full_name NVARCHAR(255),              -- Full name from receipt
    short_name NVARCHAR(100),             -- Simplified name
    store_description NVARCHAR(500),      -- Store-provided description
    user_description NVARCHAR(500),       -- User-defined description

    quantity INT,                         -- Quantity of packages purchased
    q_unit_name NVARCHAR(50),             -- Name of the unit for quantity (e.g., "Pieces", "Dozen", "Gross" (144 pieces), "Score" (20 pieces), "Pack", "Box", "Generic unit") --> FK(q_unit): UnitType(unit_name)

    items_per_package INT,                -- Number of items per package (e.g., 3 batteries per pack)
    ipp_unit_name NVARCHAR(50),           -- Name of the unit for Number of items per package (e.g., "Pieces", "Dozen", "Gross" (144 pieces), "Score" (20 pieces), "Pack", "Box", "Generic unit") --> FK(ipp_unit): UnitType(unit_name)

    inline_total_weight DECIMAL(10, 3),   -- Weight for weighted items

    weight_per_unit DECIMAL(10, 3),       -- Weight per individual unit (e.g., 0.5 kg per bottle)
    w_unit_name NVARCHAR(50),             -- Name of the unit for weight (e.g., "kg", "g") --> FK(w_unit): UnitType(unit_name)

    inline_total_volume DECIMAL(10, 3),   -- Volume for volumetric items

    volume_per_unit DECIMAL(10, 3),       -- Volume per individual unit (e.g., 0.2 L per bottle)
    v_unit_name NVARCHAR(50),             -- Name of the unit ffor volume (e.g., "l", "ml") --> FK(v_unit): UnitType(unit_name)

    inline_total_price DECIMAL(18, 2),    -- Total price for this line item on the receipt (if specified by store)

    unit_price DECIMAL(18, 2),            -- Price per unit (if specified by store)
    up_unit_name NVARCHAR(50),            -- Name of the unit for unit_price (e.g., "kg", "g", "L") --> FK(up_unit): UnitType(unit_name)

    vat_rate DECIMAL(5, 2),               -- VAT rate for the product (e.g., 19.00 for 19%)
    is_bio BIT,                           -- Indicator for organic (bio) product (1 if bio, 0 otherwise)
    code NVARCHAR(50),                    -- Product code

    category_name NVARCHAR(50),           -- Category(category_id) e.g., (Fruits, Vegetables, Dairy, Meat, Seafood, Beverages, Snacks, Bakery, Frozen Foods, Canned Goods, Condiments, Spices, Grains, Pasta, Rice, Breakfast Foods, Oils, Sauces, Packaged Meals, Cleaning Supplies, Personal Care, Household Items, Baby Products, Pet Supplies)

    brand NVARCHAR(50),                   -- Brand of the product
    origin_country NVARCHAR(50),          -- Country of origin
    expiration_date DATE,                 -- Expiration date for perishables
    tax_code CHAR(3)                      -- (e.g. 1="A", 2="B", 3="C")
);
GO

CREATE TABLE Receipt (
    buy_datetime DATETIME,
    trace_number NVARCHAR(50),
    total_amount DECIMAL(18, 2),              -- Total amount for the receipt (e.g., 10€)
    cashback_amount DECIMAL(18, 2),           -- Amount of cash received as cashback (e.g., 15€)
    currency NVARCHAR(10),                    -- Currency used in the transaction (e.g., "EUR", "USD")
    total_loyalty DECIMAL(18, 2) DEFAULT 0,   -- Amount of loyalty discount or points applied to the receipt

    full_name_payment_method NVARCHAR(255),   -- e.g., "Kartenzahlung kontaktlos SEPA Lastschrift online"
    payment_method_name NVARCHAR(50),         -- Full name of the payment method (e.g., "Credit Card") --> FK(ReceiptPayment.payment_method_id): PaymentMethod(payment_method_id)
    receipt_payment_amount NVARCHAR(50),      -- Amount paid using this payment method --> FK ReceiptPayment.amount

    iban CHAR(34)
);
GO

CREATE TABLE TaxRate (
    tax_code CHAR(3),                           -- Tax code (e.g., A, B, C)
    vat_rate DECIMAL(5, 2) NOT NULL,            -- VAT rate in percentage (e.g., 7.00, 19.00, 0.00 in %)
    net_amount DECIMAL(5, 2) NOT NULL,          -- Total net sales amount excluding VAT (e.g., 7.00, 19.00, 0.00 in %)
    vat_amount DECIMAL(5, 2),                   -- Total VAT amount (taxed)
);
GO

CREATE TABLE ReceiptTaxDetail (
    net_sales_amount DECIMAL(18, 2),            -- Net sales amount for this tax rate
    vat_amount DECIMAL(18, 2),                  -- VAT amount for this tax rate
);
GO
