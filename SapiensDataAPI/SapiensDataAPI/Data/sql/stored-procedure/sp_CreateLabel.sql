-- Create a Primary Label
CREATE PROCEDURE sp_CreateLabel
    @label_name NVARCHAR(50),
    @description NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Label WHERE label_name = @label_name)
    BEGIN
        PRINT 'Label already exists with this name.';
        RETURN;
    END

    INSERT INTO Label (label_name, description)
    VALUES (@label_name, @description);

    PRINT 'Label created successfully.';
END;
GO

-- Create a primary label
EXEC sp_CreateLabel @label_name = 'Transportation', @description = 'Transportation expenses';
