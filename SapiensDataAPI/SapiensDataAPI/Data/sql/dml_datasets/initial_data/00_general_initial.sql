-- Insert initial data for a sample user in User table
INSERT INTO [User] (username, password_hash, first_name, last_name, account_email, role, status, created_at)
VALUES 
    ('johndoe', HASHBYTES('SHA2_256', 'password123'), 'John', 'Doe', 'johndoe@example.com', 'user', 'active', GETDATE()),
    ('adminuser', HASHBYTES('SHA2_256', 'adminpassword'), 'Admin', 'User', 'admin@example.com', 'admin', 'active', GETDATE());
GO

-- Insert default address entries (example entries for testing purposes)
INSERT INTO Address (street, house_number, postal_code, city, state, country)
VALUES 
    ('123 Main St', '45A', '12345', 'Sample City', 'Sample State', 'Sample Country'),
    ('456 Elm St', '2B', '67890', 'Another City', 'Another State', 'Another Country');
GO

-- Insert initial bank account details for sample users
INSERT INTO BankAccount (user_id, bank_name, account_number, iban, account_type, created_at)
VALUES 
    (1, 'Sample Bank', '123456789', 'DE12345678901234567890', 'Checking', GETDATE()),
    (2, 'Test Bank', '987654321', 'DE09876543210987654321', 'Savings', GETDATE());
GO
