-- Insert default payment methods into PaymentMethod table
INSERT INTO PaymentMethod (name, abbreviation, description)
VALUES
    ('Credit Card', 'CC', 'Payment made via credit card'),
    ('Debit Card', 'DC', 'Payment made via debit card'),
    ('Bank Transfer', 'BT', 'Payment made through bank transfer'),
    ('Cash', 'Cash', 'Payment made with cash'),
    ('Mobile Payment', 'MP', 'Payment made through mobile payment platforms'),
    ('PayPal', 'PP', 'Payment made using PayPal account'),
    ('Gift Card', 'GC', 'Payment made using a gift card'),
    ('Cryptocurrency', 'Crypto', 'Payment made using cryptocurrency (e.g., Bitcoin)'),
    ('Google Pay', 'GP', 'Payment made using Google Pay'),
    ('Apple Pay', 'AP', 'Payment made using Apple Pay'),
    ('Voucher', 'V', 'Payment made using a voucher or discount code'),
    ('Cheque', 'Cheque', 'Payment made with a cheque'),
    ('Prepaid Card', 'PC', 'Payment made using a prepaid card'),
    ('Loyalty Points', 'LP', 'Payment made using loyalty points'),
    ('Contactless Card', 'CCL', 'Payment made via contactless card');
GO
