-- Insert default frequencies into Frequency table
INSERT INTO Frequency (frequency_name, description, days_interval)
VALUES
    ('One-Time', 'Occurs only once', NULL),
    ('Daily', 'Occurs every day', 1),
    ('Weekly', 'Occurs once a week', 7),
    ('Bi-Weekly', 'Occurs every two weeks', 14),
    ('Monthly', 'Occurs once a month', 30),
    ('Quarterly', 'Occurs every three months', 90),
    ('Annually', 'Occurs once a year', 365);
GO
