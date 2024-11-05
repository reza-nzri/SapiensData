CREATE TABLE Store (
    store_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    name NVARCHAR(100),
    brand_name NVARCHAR(100),
    tax_id NVARCHAR(20),
    address_id INT,
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);
GO

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
GO
