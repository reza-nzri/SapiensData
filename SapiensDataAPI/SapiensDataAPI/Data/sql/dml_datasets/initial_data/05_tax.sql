-- Insert default tax rates into TaxRate table
INSERT INTO TaxRate (tax_code, vat_rate, description)
VALUES 
    ('A', 7.00, 'Reduced VAT rate for basic goods'),
    ('B', 19.00, 'Standard VAT rate for most goods and services'),
    ('C', 0.00, 'VAT exempt or zero-rated goods');
GO
