-- Create a Sub-Label (Underlabel)
CREATE PROCEDURE sp_CreateSubLabel
    @parent_label_id INT,
    @sub_label_name NVARCHAR(50),
    @description NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the parent label exists
    IF NOT EXISTS (SELECT 1 FROM Label WHERE label_id = @parent_label_id)
    BEGIN
        PRINT 'Parent label does not exist.';
        RETURN;
    END

    -- Check if a sub-label with the same name already exists under the same parent
    IF EXISTS (SELECT 1 FROM Label WHERE label_name = @sub_label_name AND parent_label_id = @parent_label_id)
    BEGIN
        PRINT 'Sub-label already exists under this parent label.';
        RETURN;
    END

    -- Insert the new sub-label
    INSERT INTO Label (label_name, description, parent_label_id)
    VALUES (@sub_label_name, @description, @parent_label_id);

    PRINT 'Sub-label created successfully.';
END;
GO

-- Create a sub-label under "Transportation"
EXEC sp_CreateSubLabel @parent_label_id = 1, @sub_label_name = 'Fuel', @description = 'Fuel for vehicles';
