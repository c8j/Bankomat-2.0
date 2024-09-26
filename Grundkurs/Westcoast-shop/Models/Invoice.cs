﻿namespace Westcoast_shop.Models;

public class Invoice
{
    /* PROPERTIES */
    //Base info
    public int InvoiceNumber { get; }
    public DateTime InvoiceDate { get; }
    public DateTime DueDate { get; }
    public decimal TotalValue { get; private set; }
    public bool IsPaid { get; set; } = false;
    //TODO: Implement method that changes state

    //Sender(Company)
    public Person Sender { get; }

    /* Customer */
    public Customer Customer { get; }

    /* Fakturans rader */
    public List<ProductItem> InvoiceItems { get; }

    /* CONSTRUCTORS */

    public Invoice(int senderID, int customerID)
    {
        Sender = new Person(senderID);
        Customer = new Customer(customerID);

        //Generera fakturanummer
        InvoiceNumber = new Random().Next(10000, 33001);

        //Skapa fakturadatum
        InvoiceDate = DateTime.Now;

        //Räkna fram förfallodatum
        DueDate = InvoiceDate.AddDays(Customer.PaymentTerms);

        //Initiera listan av fakturarader
        InvoiceItems = [];
    }

    public Invoice(int senderID, int customerID, SaleOrder saleOrder) : this(senderID, customerID)
    {
        InvoiceItems = saleOrder.ProductItems;
    }

    /* METHODS */
    public override string ToString()
    {
        return $"Fakturanummer: {InvoiceNumber} - Fakturadatum: {InvoiceDate} - Förfallodatum: {DueDate} - Kund: {Customer.ID} ({Customer}) - Totalt: {TotalValue}";
    }

    public void AddItem(int productID, int numberOfItems)
    {
        InvoiceItems.Add(new ProductItem(new Product(productID), numberOfItems));
        TotalValue += InvoiceItems.Last().TotalPrice;
    }

    public void ListItems()
    {
        foreach (ProductItem invoiceItem in InvoiceItems)
        {
            Console.WriteLine(invoiceItem);
        }
    }
}
