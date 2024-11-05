USE SapeinsData;

CREATE TABLE [User] (
    user_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    username NVARCHAR(50) UNIQUE NOT NULL,         -- Username for login
    password_hash NVARCHAR(255) NOT NULL,          -- Hashed password for secure storage
    prefix NVARCHAR(10),                           -- Name prefix (e.g., Mr., Dr.)
    first_name NVARCHAR(50),                       -- [User]'s first name
    middle_name NVARCHAR(50),                      -- Middle name or initial
    last_name NVARCHAR(50),                        -- [User]'s last name
    suffix NVARCHAR(10),                           -- Name suffix (e.g., Jr., Sr.)
    nickname NVARCHAR(50),                         -- [User]'s preferred nickname
    gender CHAR(1) CHECK (gender IN ('M', 'F', 'O')), -- Gender: 'M' = Male, 'F' = Female, 'O' = Other
    birthday DATE,                                 -- [User]'s date of birth
    profile_picture_path NVARCHAR(255),            -- File path or URL to profile picture
    account_email NVARCHAR(100) UNIQUE NOT NULL,   -- Primary account email
    recovery_email NVARCHAR(100),                  -- Email for account recovery
    account_phone NVARCHAR(20),                    -- Primary phone number for account
    recovery_phone NVARCHAR(20),                   -- Phone number for account recovery
    alt_emails NVARCHAR(255),                      -- Comma-separated list of alternate emails with titles (e.g., "work: example@work.com, personal: example@home.com")
    company_name NVARCHAR(100),                    -- [User]'s company name
    job_title NVARCHAR(100),                       -- Job title
    department NVARCHAR(100),                      -- Department in the company
    app_language NVARCHAR(10) DEFAULT 'en',        -- Preferred app language (e.g., 'en', 'de')
    website NVARCHAR(255),                         -- Personal or professional website URL
    linkedin NVARCHAR(255),
    facebook NVARCHAR(255),
    instagram NVARCHAR(255),
    twitter NVARCHAR(255),
    github NVARCHAR(255),
    youtube NVARCHAR(255),
    tiktok NVARCHAR(255),
    snapchat NVARCHAR(255),
    created_at DATETIME DEFAULT GETDATE(),         -- Account creation date and time
    updated_at DATETIME DEFAULT GETDATE(),         -- Last update date and time
    last_login DATETIME,                           -- Last login timestamp
    role NVARCHAR(50) DEFAULT '[User]',              -- [User] role (e.g., '[User]', 'admin')
    status NVARCHAR(20) DEFAULT 'active',          -- Account status (e.g., 'active', 'suspended')
);
GO

CREATE TABLE UserAddress (
    company_address_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT,
    address_id INT,
    is_default BIT DEFAULT 0,
    address_type NVARCHAR(50) NOT NULL UNIQUE,                 -- Examples: "Home", "Work", "Billing", "Shipping"
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [User](user_id),
    FOREIGN KEY (address_id) REFERENCES Address(address_id)
);
GO

CREATE TABLE UserRelationship (
    relationship_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                    -- The [User] who has the relationship
    related_user_id INT NOT NULL,                            -- The related [User]'s ID
    relationship_type NVARCHAR(50) CHECK (relationship_type IN (
    'friend', 'family', 'colleague', 'acquaintance', 'neighbor', 
    'classmate', 'teammate', 'mentor', 'supervisor', 'subordinate', 'partner', 
    'spouse', 'sibling', 'parent', 'child', 'other'
    )),
    created_at DATETIME DEFAULT GETDATE(),                   -- Timestamp when the relationship was added
    FOREIGN KEY (user_id) REFERENCES [User](user_id) ON DELETE NO ACTION,
    FOREIGN KEY (related_user_id) REFERENCES [User](user_id) ON DELETE NO ACTION
);
GO

CREATE TABLE UserSession (
    session_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    user_id INT NOT NULL,                                -- Foreign key to [User]
    login_time DATETIME DEFAULT GETDATE(),               -- Login timestamp
    logout_time DATETIME,                                -- Logout timestamp
    ip_address NVARCHAR(45),                             -- IP address from which the [User] logged in
    device NVARCHAR(100),                                -- Device information or [User] agent
    browser NVARCHAR(50),                                -- Browser used during session
    operating_system NVARCHAR(50),                       -- Operating system of the device
    session_token NVARCHAR(255) UNIQUE,                  -- Unique session token for authentication
    is_active BIT DEFAULT 1,                             -- Status of session: 1 = active, 0 = inactive
    location NVARCHAR(100),                              -- Approximate location based on IP
    login_attempts INT DEFAULT 1,                        -- Number of login attempts during this session
    failed_login_attempts INT DEFAULT 0,                 -- Number of failed login attempts
    session_duration AS DATEDIFF(MINUTE, login_time, logout_time),  -- Computed duration of the session in minutes
    FOREIGN KEY (user_id) REFERENCES [User](user_id)
);
GO
