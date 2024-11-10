-- Insert unit types into UnitType table
INSERT INTO UnitType (unit_name, unit_type)
VALUES
    -- Weight units
    ('kg', 'weight'),             -- Kilogram
    ('g', 'weight'),              -- Gram
    ('mg', 'weight'),             -- Milligram
    ('ton', 'weight'),            -- Metric Ton
    ('lb', 'weight'),             -- Pound
    ('oz', 'weight'),             -- Ounce

    -- Volume units
    ('l', 'volume'),              -- Liter
    ('ml', 'volume'),             -- Milliliter
    ('cl', 'volume'),             -- Centiliter
    ('m3', 'volume'),             -- Cubic Meter
    ('gal', 'volume'),            -- Gallon (US)
    ('qt', 'volume'),             -- Quart (US)
    ('pt', 'volume'),             -- Pint (US)
    ('fl oz', 'volume'),          -- Fluid Ounce (US)
    ('cup', 'volume'),            -- Cup (US)

    -- Length units
    ('m', 'length'),              -- Meter
    ('cm', 'length'),             -- Centimeter
    ('mm', 'length'),             -- Millimeter
    ('km', 'length'),             -- Kilometer
    ('in', 'length'),             -- Inch
    ('ft', 'length'),             -- Foot
    ('yd', 'length'),             -- Yard
    ('mi', 'length'),             -- Mile

    -- Area units
    ('m2', 'area'),               -- Square Meter
    ('cm2', 'area'),              -- Square Centimeter
    ('mm2', 'area'),              -- Square Millimeter
    ('km2', 'area'),              -- Square Kilometer
    ('ha', 'area'),               -- Hectare
    ('ac', 'area'),               -- Acre
    ('ft2', 'area'),              -- Square Foot
    ('in2', 'area'),              -- Square Inch
    ('yd2', 'area'),              -- Square Yard
    ('mi2', 'area'),              -- Square Mile

    -- Temperature units
    ('C', 'temperature'),         -- Celsius
    ('F', 'temperature'),         -- Fahrenheit
    ('K', 'temperature'),         -- Kelvin

    -- Quantity units
    ('pcs', 'quantity'),          -- Pieces
    ('dozen', 'quantity'),        -- Dozen
    ('gross', 'quantity'),        -- Gross (144 pieces)
    ('score', 'quantity'),        -- Score (20 pieces)
    ('pack', 'quantity'),         -- Pack
    ('box', 'quantity'),          -- Box
    ('unit', 'quantity'),         -- Generic unit

    -- Time units
    ('sec', 'time'),              -- Second
    ('min', 'time'),              -- Minute
    ('hr', 'time'),               -- Hour
    ('day', 'time'),              -- Day
    ('wk', 'time'),               -- Week
    ('mo', 'time'),               -- Month
    ('yr', 'time');               -- Year
GO

