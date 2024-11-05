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
    category_id INT,                      -- Placeholder if a Category table exists from AI Dataset
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
GO
