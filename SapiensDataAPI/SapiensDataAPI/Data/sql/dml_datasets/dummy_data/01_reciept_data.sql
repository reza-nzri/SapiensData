-- Add Reciept: dataset\reciepts\reciept_media-markt_20241028_105959.jpg

INSERT INTO Address (street, house_number, postal_code, city, state, country) VALUES 
('Breitenbachstr.', '50', '41065', 'Mönchengladbach', NULL, 'Germany');


INSERT INTO Store (name, brand_name, tax_id, address_id) VALUES 
('Media Markt TV-HiFi-Elektro GmbH', 'Media Markt', 'DE 228434583', 1);

INSERT INTO PaymentMethod (name, abbreviation, description) VALUES 
('SEPA Direct Debit', 'SEPA', 'Contactless SEPA Lastschrift');

INSERT INTO Receipt (
    buy_datetime, trace_number, total_amount, net_amount, vat_amount, vat_percentage, 
    cashback_amount, currency, full_name_payment_method, iban, receipt_image_path, 
    payment_method_id, store_id
) VALUES (
    '2024-10-28 10:59:59', 'G542147135542410281059', 10.98, 9.22, 1.76, 19.00, 
    NULL, 'EUR', 'SEPA Direct Debit', 'DE5331############4352', '/path/to/receipt_image.jpg', 1, 1
);

INSERT INTO Product (full_name, short_name, store_description, quantity, q_unit, items_per_package, ipp_unit, line_total_price, unit_price, tax_code, brand, code) VALUES 
('PANASONIC CR2025L/2BP LITHIUM BATTERIE KNOPFZELLE', 'CR2025L/2BP BATTERY', 'LITHIUM BATTERIE KNOPFZELLE', 1, NULL, NULL, NULL, 5.99, NULL, 'b', 'PANASONIC', '28370571'),
('PANASONIC SR 626 GEBLISTERT BATTERIE KNOPFZELLE', 'SR 626 BATTERY', 'GEBLISTERT BATTERIE KNOPFZELLE', 1, NULL, NULL, NULL, 4.99, NULL, 'b', 'PANASONIC', '1253094');

INSERT INTO ReceiptPayment (receipt_id, payment_method_id, amount) VALUES 
(1, 1, 10.98);
