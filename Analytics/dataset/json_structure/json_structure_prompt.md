# Convert OCR Text to Json with AI

**Objective:** The goal is to extract recognized text from a receipt using OCR technology and format it according to the structure defined in the "json_structure.json" file.

Please convert the text extracted from the "OCR-Text from Receipt" into the template structure provided in "json_structure.json" and return the formatted JSON. If certain data or information from the "OCR-Text from Receipt" is missing, please fill the corresponding properties in the JSON structure with an empty string `""`. It is important that the complete JSON file is returned regardless of missing information.

Based on the details in the "OCR-Text from Receipt," populate and complete the JSON structure. Pay attention to the language of the "OCR-Text from Receipt." If the text or receipt is in German, ensure that the JSON is also in German, particularly for the names of food products and categories, which must be written exactly as in the original receipt.

- reciept.iban must be written in the same way as reciept censored only with X and no # or other symbols must be used. e.g.: “iban”: “DE4450XXXXXXXXXXXXXXXX4931”
- Automatically categorize each product in the receipt and add the new data attributes as a category for the product.
- Just write me the answer and the json result. Don't write me any other text or explanation or anything else, just write me the full json.
- if no data from ocr text was found for an attribute, then do not write it yourself, write it as an empty string. e.g. the data of date and time are not in ocr text, so their corresponding attributes in json should be empty string "".  
- Search for 'hh:mm:ss' If not found, then 'hh:mm:00'

If the OCR text contains the following, it means the corresponding data should be added:

- **"incl. 19.00% Mwst (b) 1,76"** → `{"TaxRate":{"tax_code": "B", "vat_rate": "19.00", "vat_amount": "1.76"}}`
- **"Netto-Warenwert: (b) 9,22"** → `{"Receipt": {"net_amount": "9.22"}}`
- If no **"origin_country"** is found in the OCR text, leave it as an empty string `""`.
- In OCR text, when you see **"number*number"** (e.g., "2,000*3,000"), this generally indicates the quantity of the product. Here, in this case, **("unit_price" * "quantity")** equals the value of **"inline_total_price"**. For example: **(2.00 Euro * 3 = 6.00 Euro)**.
- **"2 x Coca Cola 0,2l 2,20 19% 4,40"** → `{"Product":{"full_name": "Coca Cola", "quantity": "2", "unit_price": "2.20", "vat_rate": "19.00", "v_unit_name": "l", "volume_per_unit": "0.2", "inline_total_price": "4.40"}}`
- If the store name or location is in Germany, keep all text in German and use **Euro** as the currency in receipts.
- **"Verkäufe 19% exkl. 3,70"** corresponds to the data for **net_amount** under `"TaxRate.vat_rate": "19.00"`.
- **"Mwst 19% 0,70"** corresponds to the data for **vat_amount** under `"TaxRate.vat_rate": "19.00"`.
- **"Verkäufe 7% exkl. 12,62"** corresponds to the data for **net_amount** under `"TaxRate.vat_rate": "7.00"`.
- **"Mwst 7% 0,88"** corresponds to the data for **vat_amount** under `"TaxRate.vat_rate": "7.00"`.
- The sum of **["vat_rate" + "net_amount" at 7%]** and **["vat_rate" + "net_amount" at 19%]** is usually equal to `{"Receipt":{"total_amount"}}`.
- The sum of **"vat_rate" + "net_amount"** is typically equal to `{"Receipt":{"total_amount"}}`.
- **"A 07,0% Netto 101,31 MwSt 7,09"** → This data corresponds to **{TaxRate.net_amount: "101.31"}** and **{TaxRate.vat_amount: "7.09"}** at **7%**.
- **"B 19,0% Netto 0,57 MwSt 0,11"** → This data corresponds to **{TaxRate.net_amount: "0.57"}** and **{TaxRate.vat_amount: "0.11"}** at **19%**.
- There is typically this TaxRate if none is provided in the OCR text: **('A', 7.00%)**, **('B', 19.00%)**, **('C', 0.00%)**.
- **"MWST-ZW 19%"** corresponds to **Receipt.total_amount**.
- **"MWST 19%"** corresponds to **TaxRate.net_amount**.
- **"Netto 19%"** corresponds to **TaxRate.vat_amount**.
- **"MWST BRUTTO NETTO B 7% 0,27 4,12 3,58"** is simply a table showing:
  **{"tax_code": "B", "vat_rate": "7%", "MWST": "0.27", "BRUTTO": "4.12", "NETTO": "3.58"}**.
- **"1 19,00 % von 4,00 0,64"** → Meaning in a row: **"tax_code"** is 1, which means **"B"**, **"vat_rate"**, **Receipt.total_amount**, and **TaxRate.vat_amount**.
- **"MwSt. Spezifikation MwSt Exkl. Inkl. 19% 0,82 4,34 5,16 Summe 0,82 4,34 5,16"** is a table with:
  **{TaxRate.vat_amount: 0.82, Receipt.total_amount: 5.16, TaxRate.net_amount: 4.34}**. The **sum row** indicates the total value of the tax.

### Learn about the Data Sequence for Each Store's Receipts:

- **Media Markt**: Includes information like (in sequence): store, products, total price, datetime, payment, transaction details, slogan, thank-you message, transaction, and barcode.

## Various OCR attribute options

- 

**json_structure.json:**

```json

```

json_structure_example.json:

```json

```

### Explanation of the json file

- All “unit_name”:
  - kg, g, mg, ton, lb, oz, l, ml, cl, m3, gal, qt, pt, fl oz, cup, m, cm, mm, km, in, ft, yd, mi, m2, cm2, mm2, km2, ha, ac, ft2, in2, yd2, mi2, C, F, K, pcs, dozen, gross, score, pack, box, unit, sec, min, hr, day, wk, mo, yr
- All “payment_method_name”:
  - Credit Card, Debit Card, Bank Transfer, Cash, Mobile Payment, PayPal, Gift Card, Cryptocurrency, Google Pay, Apple Pay, Voucher, Cheque, Prepaid Card, Loyalty Points, Contactless Card
- **Store:**
  - **address_type:** Examples: "Home", "Work", "Billing", "Shipping"
- **Product:**
  - **full_name:** Full name from receipt
  - **short_name:** Simplified name
  - **store_description:** Store-provided description
  - **user_description:** User-defined description
  - **quantity:** Quantity of packages purchased
  - **q_unit_name:** Name of the unit for quantity (e.g., "Pieces", "Dozen", "Gross" (144 pieces), "Score" (20 pieces), "Pack", "Box", "Generic unit")
  - **items_per_package:** Number of items per package (e.g., 3 batteries per pack)
  - **ipp_unit_name:** Name of the unit for Number of items per package (e.g., "Pieces", "Dozen", "Gross" (144 pieces), "Score" (20 pieces), "Pack", "Box", "Generic unit")
  - **inline_total_weight:** Weight for weighted items
  - **weight_per_unit:** Weight per individual unit (e.g., 0.5 kg per bottle)
  - **w_unit_name:** Name of the unit for weight (e.g., "kg", "g")
  - **inline_total_volume:** Volume for volumetric items
  - **volume_per_unit:** Volume per individual unit (e.g., 0.2 L per bottle)
  - **v_unit_name:** Name of the unit for volume (e.g., "l", "ml")
  - **inline_total_price:** Total price for this line item on the receipt (if specified by store)
  - **unit_price:** Price per unit (if specified by store)
  - **up_unit_name:** Name of the unit for unit_price (e.g., "kg", "g", "L")
  - **vat_rate:** VAT rate for the product (e.g., 19.00 for 19%)
  - **is_bio:** Indicator for organic (bio) product (1 if bio, 0 otherwise)
  - **code:** Product code
  - **category_name:** Category(category_id) e.g., (Fruits, Vegetables, Dairy, Meat, Seafood, Beverages, Snacks, Bakery, Frozen Foods, Canned Goods, Condiments, Spices, Grains, Pasta, Rice, Breakfast Foods, Oils, Sauces, Packaged Meals, Cleaning Supplies, Personal Care, Household Items, Baby Products, Pet Supplies)
  - **brand:** Brand of the product
  - **origin_country:** Country of origin
  - **expiration_date:** Expiration date for perishables
  - **tax_code:** (e.g. 1="A", 2="B", 3="C")
- **Receipt:**
  - **total_amount:** Total amount for the receipt (e.g., 10€)
  - **trace_number:**  "Beleg-Nr." or "BNr" and "Trace-Nr." or "TA-Nr,"
  - **cashback_amount:** Amount of cash received as cashback (e.g., 15€)
  - **currency:** Currency used in the transaction (e.g., "EUR", "USD")
  - **total_loyalty:** Amount of loyalty discount or points applied to the receipt
  - **full_name_payment_method:** e.g., "Kartenzahlung kontaktlos SEPA Lastschrift online"
  - **payment_method_name:** Full name of the payment method (e.g., "Credit Card")
  - **receipt_payment_amount:** Amount paid using this payment method
- **TaxRate:**
  - **tax_code:** Tax code (e.g., A, B, C)
  - **vat_rate:** VAT rate in percentage (e.g., 7.00, 19.00, 0.00 in %)
  - **net_amount:** Total net sales amount excluding VAT (e.g., 7.00, 19.00, 0.00 in %)
  - **vat_amount:** Total VAT amount (taxed)
- **ReceiptTaxDetail:**
  - **net_sales_amount:** Net sales amount for this tax rate
  - **vat_amount:** VAT amount for this tax rate

**Input OCR-Text from Receipt:**

```txt

```
