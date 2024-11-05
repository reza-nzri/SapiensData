-- User-defined labels for categorization
CREATE TABLE Label (
    label_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    label_name NVARCHAR(50) NOT NULL UNIQUE,              -- Name of the label (e.g., "organic", "essential")
    description NVARCHAR(255),                            -- Brief description of what this label represents
    color_code NVARCHAR(7),                               -- Optional HEX color code for displaying the label (e.g., "#FF5733")
);
GO

CREATE TABLE LabelAssignment (
    label_assignment_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    label_id INT NOT NULL,                                -- Foreign key to the Label table
    entity_type NVARCHAR(50) NOT NULL,                    -- Type of the entity (e.g., "Product", "Expense", "Income")
    entity_id INT NOT NULL,                               -- ID of the entity being labeled (e.g., product_id, expense_id)
    assigned_at DATETIME DEFAULT GETDATE(),               -- Timestamp when the label was assigned
    FOREIGN KEY (label_id) REFERENCES Label(label_id) ON DELETE CASCADE
);
GO
