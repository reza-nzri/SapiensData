'use client'
import { useState, useEffect } from 'react';
import Image from 'next/image';

export default function ReceiptDisplay({ data }) {
  // Check if data is null or undefined
  if (!data) {
    return <p>Loading...</p>; // Or display a message indicating that data is not available
  }

  // Destructure necessary fields from the API response
  const {
    fileName,
    contentType,
    uploadDate,
    store,
    product,
    receipt,
    taxRate,
    receiptTaxDetail,
    imageData, // Assuming image is in the response
  } = data;

  if (!data) {
    return <p>Loading...</p>; // Or display a message indicating that data is not available
  }

  if (!store) {
    return <p>Loading...</p>; // Or display a message indicating that data is not available
  }

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold text-center mb-6">Receipt Details</h1>

      {/* Store Information */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Store Information</h2>
        <p><strong>Name:</strong> {store.name}</p>
        <p><strong>Brand:</strong> {store.brand_name}</p>
        <p><strong>Tax ID:</strong> {store.tax_id}</p>
        <p><strong>Address:</strong> {store.street}, {store.city}, {store.postal_code}, {store.country}</p>
      </section>

      {/* Receipt Details */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Receipt Information</h2>
        <p><strong>Purchase Date:</strong> {new Date(receipt.buy_datetime).toLocaleString()}</p>
        <p><strong>Trace Number:</strong> {receipt.trace_number}</p>
        <p><strong>Total Amount:</strong> {receipt.total_amount} {receipt.currency}</p>
        <p><strong>Cashback Amount:</strong> {receipt.cashback_amount} {receipt.currency}</p>
        <p><strong>Payment Method:</strong> {receipt.full_name_payment_method}</p>
      </section>

      {/* Tax Information */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Tax Information</h2>
        {taxRate.map((tax, index) => (
          <div key={index}>
            <p><strong>Tax Code:</strong> {tax.tax_code}</p>
            <p><strong>VAT Rate:</strong> {tax.vat_rate}%</p>
            <p><strong>Net Amount:</strong> {tax.net_amount} EUR</p>
            <p><strong>VAT Amount:</strong> {tax.vat_amount} EUR</p>
          </div>
        ))}
      </section>

      {/* Product Details */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Product Information</h2>
        {product.map((item, index) => (
          <div key={index} className="border-b py-4">
            <h3 className="text-lg font-semibold">{item.full_name}</h3>
            <p><strong>Quantity:</strong> {item.quantity}</p>
            <p><strong>Unit Price:</strong> {item.unit_price} EUR</p>
            <p><strong>Total Price:</strong> {item.inline_total_price} EUR</p>
            <p><strong>Brand:</strong> {item.brand}</p>
            <p><strong>Product Code:</strong> {item.code}</p>
          </div>
        ))}
      </section>

      {/* Receipt Tax Details */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Receipt Tax Detail</h2>
        {receiptTaxDetail.map((detail, index) => (
          <div key={index}>
            <p><strong>Net Sales Amount:</strong> {detail.net_sales_amount} EUR</p>
            <p><strong>VAT Amount:</strong> {detail.vat_amount} EUR</p>
          </div>
        ))}
      </section>

      {/* Image Preview */}
      <section className="mb-6">
        <h2 className="text-xl font-semibold">Receipt Image</h2>
        {imageData ? (
          <Image
          src={`data:${contentType};base64,${imageData}`}
          alt="Receipt"
          width={500}  // Provide a width and height
          height={300} // Provide a height
          className="border"
        />
        ) : (
          <p>No image available</p>
        )}
        <p><strong>File Name:</strong> {fileName}</p>
      </section>

      {/* Upload Date */}
      <section className="mb-6">
        <p><strong>Uploaded On:</strong> {new Date(uploadDate).toLocaleString()}</p>
      </section>
    </div>
  );
}
