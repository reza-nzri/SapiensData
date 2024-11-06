-- Insert default payment methods into PaymentMethod table
INSERT INTO PaymentMethod (name, abbreviation, description)
VALUES
    ('Credit Card', 'CC', 'Payment made via credit card'),
    ('Debit Card', 'DC', 'Payment made via debit card'),
    ('Bank Transfer', 'BT', 'Payment made through bank transfer'),
    ('Cash', 'Cash', 'Payment made with cash'),
    ('Mobile Payment', 'MP', 'Payment made through mobile payment platforms');
GO
