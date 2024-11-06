using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SapiensDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    house_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__CAA247C81434C0EC", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    api_endpoint = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    api_version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "v1"),
                    contact_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bank__4076F70387093681", x => x.bank_id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    parent_category_id = table.Column<int>(type: "int", nullable: true),
                    category_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__D54EE9B481C94F07", x => x.category_id);
                    table.ForeignKey(
                        name: "FK__Category__parent__4316F928",
                        column: x => x.parent_category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    industry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    registration_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tax_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    founded_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__3E267235E7687D3B", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    expense_category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    parent_category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExpenseC__01F417D73F5C647A", x => x.expense_category_id);
                    table.ForeignKey(
                        name: "FK__ExpenseCa__paren__2A164134",
                        column: x => x.parent_category_id,
                        principalTable: "ExpenseCategory",
                        principalColumn: "expense_category_id");
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    frequency_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    frequency_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    days_interval = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Frequenc__F32AB2AB880FB888", x => x.frequency_id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategory",
                columns: table => new
                {
                    income_category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    parent_category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__IncomeCa__95C31FD04B6F8760", x => x.income_category_id);
                    table.ForeignKey(
                        name: "FK__IncomeCat__paren__17F790F9",
                        column: x => x.parent_category_id,
                        principalTable: "IncomeCategory",
                        principalColumn: "income_category_id");
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    label_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    color_code = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Label__E44FFA5872065241", x => x.label_id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    payment_method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentM__8A3EA9EB9B8919FC", x => x.payment_method_id);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    unit_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UnitType__D3AF5BD72F731E9A", x => x.unit_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    profile_picture_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    account_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    recovery_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    account_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    recovery_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    alt_emails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    job_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    app_language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "en"),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    linkedin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    facebook = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    instagram = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    twitter = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    github = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    youtube = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tiktok = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    snapchat = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_login = table.Column<DateTime>(type: "datetime", nullable: true),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "[User]"),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B9BE370F03BB93CC", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    brand_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tax_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store__A2F2A30C9852CCAC", x => x.store_id);
                    table.ForeignKey(
                        name: "FK__Store__address_i__76969D2E",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    company_address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    address_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyA__5650FC57CC4984E6", x => x.company_address_id);
                    table.ForeignKey(
                        name: "FK__CompanyAd__addre__73BA3083",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__CompanyAd__compa__72C60C4A",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "LabelAssignment",
                columns: table => new
                {
                    label_assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label_id = table.Column<int>(type: "int", nullable: false),
                    entity_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    entity_id = table.Column<int>(type: "int", nullable: false),
                    assigned_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LabelAss__F27DEC24E3563F24", x => x.label_assignment_id);
                    table.ForeignKey(
                        name: "FK__LabelAssi__label__49C3F6B7",
                        column: x => x.label_id,
                        principalTable: "Label",
                        principalColumn: "label_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    store_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    q_unit = table.Column<int>(type: "int", nullable: true),
                    items_per_package = table.Column<int>(type: "int", nullable: true),
                    ipp_unit = table.Column<int>(type: "int", nullable: true),
                    inline_total_weight = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    weight_per_unit = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    w_unit = table.Column<int>(type: "int", nullable: true),
                    inline_total_volume = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    volume_per_unit = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    v_unit = table.Column<int>(type: "int", nullable: true),
                    inline_total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    up_unit = table.Column<int>(type: "int", nullable: true),
                    vat_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    is_bio = table.Column<bool>(type: "bit", nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    origin_country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: true),
                    tax_code = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__47027DF51756F8BB", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__Product__ipp_uni__02084FDA",
                        column: x => x.ipp_unit,
                        principalTable: "UnitType",
                        principalColumn: "unit_id");
                    table.ForeignKey(
                        name: "FK__Product__q_unit__01142BA1",
                        column: x => x.q_unit,
                        principalTable: "UnitType",
                        principalColumn: "unit_id");
                    table.ForeignKey(
                        name: "FK__Product__up_unit__04E4BC85",
                        column: x => x.up_unit,
                        principalTable: "UnitType",
                        principalColumn: "unit_id");
                    table.ForeignKey(
                        name: "FK__Product__v_unit__03F0984C",
                        column: x => x.v_unit,
                        principalTable: "UnitType",
                        principalColumn: "unit_id");
                    table.ForeignKey(
                        name: "FK__Product__w_unit__02FC7413",
                        column: x => x.w_unit,
                        principalTable: "UnitType",
                        principalColumn: "unit_id");
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    bank_id = table.Column<int>(type: "int", nullable: false),
                    account_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    account_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    iban = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "EUR"),
                    api_access_token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    account_balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    last_synced_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BankAcco__46A222CD37890FB4", x => x.account_id);
                    table.ForeignKey(
                        name: "FK__BankAccou__bank___662B2B3B",
                        column: x => x.bank_id,
                        principalTable: "Bank",
                        principalColumn: "bank_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__BankAccou__user___65370702",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debt",
                columns: table => new
                {
                    debt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    debt_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    amount_owed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interest_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m),
                    due_date = table.Column<DateOnly>(type: "date", nullable: true),
                    creditor_user_id = table.Column<int>(type: "int", nullable: true),
                    creditor_company_id = table.Column<int>(type: "int", nullable: true),
                    creditor_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    creditor_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    creditor_company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "open"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    times_remaining = table.Column<int>(type: "int", nullable: true),
                    next_reminder = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Debt__A7DCE7F913425E57", x => x.debt_id);
                    table.ForeignKey(
                        name: "FK__Debt__creditor_c__4F47C5E3",
                        column: x => x.creditor_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK__Debt__creditor_u__4E53A1AA",
                        column: x => x.creditor_user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    income_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    income_date = table.Column<DateOnly>(type: "date", nullable: false),
                    income_category_id = table.Column<int>(type: "int", nullable: true),
                    source_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    source_user_id = table.Column<int>(type: "int", nullable: true),
                    source_company_id = table.Column<int>(type: "int", nullable: true),
                    source_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    gross_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tax_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    net_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "EUR"),
                    is_recurring = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    frequency_id = table.Column<int>(type: "int", nullable: false),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    payer_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    received_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Income__8DC777A62C4377E8", x => x.income_id);
                    table.ForeignKey(
                        name: "FK__Income__frequenc__25518C17",
                        column: x => x.frequency_id,
                        principalTable: "Frequency",
                        principalColumn: "frequency_id");
                    table.ForeignKey(
                        name: "FK__Income__income_c__2180FB33",
                        column: x => x.income_category_id,
                        principalTable: "IncomeCategory",
                        principalColumn: "income_category_id");
                    table.ForeignKey(
                        name: "FK__Income__payment___245D67DE",
                        column: x => x.payment_method_id,
                        principalTable: "PaymentMethod",
                        principalColumn: "payment_method_id");
                    table.ForeignKey(
                        name: "FK__Income__source_c__236943A5",
                        column: x => x.source_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK__Income__source_u__22751F6C",
                        column: x => x.source_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__Income__user_id__208CD6FA",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    investment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    investment_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    loaned_to_user_id = table.Column<int>(type: "int", nullable: true),
                    loaned_to_company_id = table.Column<int>(type: "int", nullable: true),
                    loaned_to_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    loaned_to_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    investment_date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    interest_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Investme__2093C283C4A88188", x => x.investment_id);
                    table.ForeignKey(
                        name: "FK__Investmen__loane__55F4C372",
                        column: x => x.loaned_to_user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Investmen__loane__56E8E7AB",
                        column: x => x.loaned_to_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Savings",
                columns: table => new
                {
                    savings_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    savings_goal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    target_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    saved_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    target_date = table.Column<DateOnly>(type: "date", nullable: true),
                    frequency_id = table.Column<int>(type: "int", nullable: true),
                    contribution_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    interest_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m),
                    accumulated_interest = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "in-progress"),
                    notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    last_updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Savings__AC1BA043D0E18128", x => x.savings_id);
                    table.ForeignKey(
                        name: "FK__Savings__frequen__44CA3770",
                        column: x => x.frequency_id,
                        principalTable: "Frequency",
                        principalColumn: "frequency_id");
                    table.ForeignKey(
                        name: "FK__Savings__user_id__43D61337",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    company_address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    address_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAddr__5650FC5748220D98", x => x.company_address_id);
                    table.ForeignKey(
                        name: "FK__UserAddre__addre__5AEE82B9",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__UserAddre__user___59FA5E80",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserRelationship",
                columns: table => new
                {
                    relationship_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    related_user_id = table.Column<int>(type: "int", nullable: false),
                    relationship_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRela__C0CFD554024C1505", x => x.relationship_id);
                    table.ForeignKey(
                        name: "FK__UserRelat__relat__60A75C0F",
                        column: x => x.related_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__UserRelat__user___5FB337D6",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    session_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    login_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    logout_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    device = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    browser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    operating_system = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    session_token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    login_attempts = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    failed_login_attempts = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    session_duration = table.Column<int>(type: "int", nullable: true, computedColumnSql: "(datediff(minute,[login_time],[logout_time]))", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserSess__69B13FDCEE3067BE", x => x.session_id);
                    table.ForeignKey(
                        name: "FK__UserSessi__user___68487DD7",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    receipt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buy_datetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    trace_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    cashback_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    total_loyalty = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    full_name_payment_method = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    iban = table.Column<string>(type: "char(34)", unicode: false, fixedLength: true, maxLength: 34, nullable: true),
                    receipt_image_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Receipt__91F52C1FA2C53D87", x => x.receipt_id);
                    table.ForeignKey(
                        name: "FK__Receipt__payment__08B54D69",
                        column: x => x.payment_method_id,
                        principalTable: "PaymentMethod",
                        principalColumn: "payment_method_id");
                    table.ForeignKey(
                        name: "FK__Receipt__store_i__09A971A2",
                        column: x => x.store_id,
                        principalTable: "Store",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "StoreAddress",
                columns: table => new
                {
                    company_address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_id = table.Column<int>(type: "int", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    is_default = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    address_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StoreAdd__5650FC573D98C8C0", x => x.company_address_id);
                    table.ForeignKey(
                        name: "FK__StoreAddr__addre__7E37BEF6",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK__StoreAddr__store__7D439ABD",
                        column: x => x.store_id,
                        principalTable: "Store",
                        principalColumn: "store_id");
                });

            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    transaction_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    transaction_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    balance_after = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BankTran__85C600AF22A200E2", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__BankTrans__accou__6BE40491",
                        column: x => x.account_id,
                        principalTable: "BankAccount",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptPayment",
                columns: table => new
                {
                    receipt_payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_id = table.Column<int>(type: "int", nullable: true),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReceiptP__CE878B50AB921B4A", x => x.receipt_payment_id);
                    table.ForeignKey(
                        name: "FK__ReceiptPa__payme__14270015",
                        column: x => x.payment_method_id,
                        principalTable: "PaymentMethod",
                        principalColumn: "payment_method_id");
                    table.ForeignKey(
                        name: "FK__ReceiptPa__recei__1332DBDC",
                        column: x => x.receipt_id,
                        principalTable: "Receipt",
                        principalColumn: "receipt_id");
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                columns: table => new
                {
                    tax_rate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tax_code = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    vat_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    net_amount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    vat_amount = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    receipt_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaxRate__4B78B3339E326A41", x => x.tax_rate_id);
                    table.ForeignKey(
                        name: "FK__TaxRate__receipt__0C85DE4D",
                        column: x => x.receipt_id,
                        principalTable: "Receipt",
                        principalColumn: "receipt_id");
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    expense_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    source_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    source_user_id = table.Column<int>(type: "int", nullable: true),
                    source_company_id = table.Column<int>(type: "int", nullable: true),
                    source_first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    source_last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    source_company_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    expense_date = table.Column<DateOnly>(type: "date", nullable: false),
                    expense_category_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: "EUR"),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    payment_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "completed"),
                    receipt_id = table.Column<int>(type: "int", nullable: true),
                    tax_rate_id = table.Column<int>(type: "int", nullable: true),
                    frequency_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    last_updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Expense__404B6A6B714931B5", x => x.expense_id);
                    table.ForeignKey(
                        name: "FK__Expense__expense__3587F3E0",
                        column: x => x.expense_category_id,
                        principalTable: "ExpenseCategory",
                        principalColumn: "expense_category_id");
                    table.ForeignKey(
                        name: "FK__Expense__frequen__395884C4",
                        column: x => x.frequency_id,
                        principalTable: "Frequency",
                        principalColumn: "frequency_id");
                    table.ForeignKey(
                        name: "FK__Expense__payment__367C1819",
                        column: x => x.payment_method_id,
                        principalTable: "PaymentMethod",
                        principalColumn: "payment_method_id");
                    table.ForeignKey(
                        name: "FK__Expense__receipt__37703C52",
                        column: x => x.receipt_id,
                        principalTable: "Receipt",
                        principalColumn: "receipt_id");
                    table.ForeignKey(
                        name: "FK__Expense__source___339FAB6E",
                        column: x => x.source_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__Expense__source___3493CFA7",
                        column: x => x.source_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK__Expense__tax_rat__3864608B",
                        column: x => x.tax_rate_id,
                        principalTable: "TaxRate",
                        principalColumn: "tax_rate_id");
                    table.ForeignKey(
                        name: "FK__Expense__user_id__32AB8735",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptTaxDetail",
                columns: table => new
                {
                    receipt_tax_detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_id = table.Column<int>(type: "int", nullable: false),
                    tax_rate_id = table.Column<int>(type: "int", nullable: false),
                    net_sales_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    vat_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReceiptT__190DF74F5F3FD40C", x => x.receipt_tax_detail_id);
                    table.ForeignKey(
                        name: "FK__ReceiptTa__recei__0F624AF8",
                        column: x => x.receipt_id,
                        principalTable: "Receipt",
                        principalColumn: "receipt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ReceiptTa__tax_r__10566F31",
                        column: x => x.tax_rate_id,
                        principalTable: "TaxRate",
                        principalColumn: "tax_rate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_bank_id",
                table: "BankAccount",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_user_id",
                table: "BankAccount",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__BankAcco__28187BEB28D4E40D",
                table: "BankAccount",
                column: "api_access_token",
                unique: true,
                filter: "[api_access_token] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__BankAcco__AF91A6AD635085E3",
                table: "BankAccount",
                column: "account_number",
                unique: true,
                filter: "[account_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_account_id",
                table: "BankTransaction",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_parent_category_id",
                table: "Category",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Company__125DB2A3DA5EC4D6",
                table: "Company",
                column: "registration_number",
                unique: true,
                filter: "[registration_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Company__129B8671141E5918",
                table: "Company",
                column: "tax_id",
                unique: true,
                filter: "[tax_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_address_id",
                table: "CompanyAddress",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_company_id",
                table: "CompanyAddress",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "UQ__CompanyA__071A9587B0D05465",
                table: "CompanyAddress",
                column: "address_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debt_creditor_company_id",
                table: "Debt",
                column: "creditor_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Debt_creditor_user_id",
                table: "Debt",
                column: "creditor_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_expense_category_id",
                table: "Expense",
                column: "expense_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_frequency_id",
                table: "Expense",
                column: "frequency_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_payment_method_id",
                table: "Expense",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_receipt_id",
                table: "Expense",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_source_company_id",
                table: "Expense",
                column: "source_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_source_user_id",
                table: "Expense",
                column: "source_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_tax_rate_id",
                table: "Expense",
                column: "tax_rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_user_id",
                table: "Expense",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategory_parent_category_id",
                table: "ExpenseCategory",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__ExpenseC__5189E255EEF6BF80",
                table: "ExpenseCategory",
                column: "category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Frequenc__A9909F222F5DF4F4",
                table: "Frequency",
                column: "frequency_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Income_frequency_id",
                table: "Income",
                column: "frequency_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_income_category_id",
                table: "Income",
                column: "income_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_payment_method_id",
                table: "Income",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_source_company_id",
                table: "Income",
                column: "source_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_source_user_id",
                table: "Income",
                column: "source_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Income_user_id",
                table: "Income",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategory_parent_category_id",
                table: "IncomeCategory",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__IncomeCa__5189E2550F873F42",
                table: "IncomeCategory",
                column: "category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investments_loaned_to_company_id",
                table: "Investments",
                column: "loaned_to_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_loaned_to_user_id",
                table: "Investments",
                column: "loaned_to_user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Label__A74BEA651F478188",
                table: "Label",
                column: "label_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabelAssignment_label_id",
                table: "LabelAssignment",
                column: "label_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ipp_unit",
                table: "Product",
                column: "ipp_unit");

            migrationBuilder.CreateIndex(
                name: "IX_Product_q_unit",
                table: "Product",
                column: "q_unit");

            migrationBuilder.CreateIndex(
                name: "IX_Product_up_unit",
                table: "Product",
                column: "up_unit");

            migrationBuilder.CreateIndex(
                name: "IX_Product_v_unit",
                table: "Product",
                column: "v_unit");

            migrationBuilder.CreateIndex(
                name: "IX_Product_w_unit",
                table: "Product",
                column: "w_unit");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_payment_method_id",
                table: "Receipt",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_store_id",
                table: "Receipt",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPayment_payment_method_id",
                table: "ReceiptPayment",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPayment_receipt_id",
                table: "ReceiptPayment",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTaxDetail_receipt_id",
                table: "ReceiptTaxDetail",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTaxDetail_tax_rate_id",
                table: "ReceiptTaxDetail",
                column: "tax_rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_frequency_id",
                table: "Savings",
                column: "frequency_id");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_user_id",
                table: "Savings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_address_id",
                table: "Store",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddress_address_id",
                table: "StoreAddress",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddress_store_id",
                table: "StoreAddress",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "UQ__StoreAdd__071A9587EC1B4587",
                table: "StoreAddress",
                column: "address_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_receipt_id",
                table: "TaxRate",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "UQ__User__713342DDA1F6D29E",
                table: "User",
                column: "account_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__F3DBC5725409B28E",
                table: "User",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_address_id",
                table: "UserAddress",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_user_id",
                table: "UserAddress",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__UserAddr__071A95874A01A788",
                table: "UserAddress",
                column: "address_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_related_user_id",
                table: "UserRelationship",
                column: "related_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_user_id",
                table: "UserRelationship",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_user_id",
                table: "UserSession",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__UserSess__E598F5C8FA9398C8",
                table: "UserSession",
                column: "session_token",
                unique: true,
                filter: "[session_token] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "Debt");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "LabelAssignment");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ReceiptPayment");

            migrationBuilder.DropTable(
                name: "ReceiptTaxDetail");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "StoreAddress");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "UserRelationship");

            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropTable(
                name: "IncomeCategory");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "TaxRate");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
