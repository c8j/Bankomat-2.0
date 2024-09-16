﻿namespace InvoiceApp;

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
    public List<InvoiceItem> InvoiceItems { get; }

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

    /* METHODS */
    public override string ToString()
    {
        return $"Fakturanummer: {InvoiceNumber} - Fakturadatum: {InvoiceDate} - Förfallodatum: {DueDate} - Kund: {Customer.ID} ({Customer}) - Totalt: {TotalValue}";
    }

    public void AddItem(int productID, int numberOfItems)
    {
        InvoiceItems.Add(new InvoiceItem(new Product(productID), numberOfItems));
        TotalValue += InvoiceItems.Last().RowPrice;
    }

    public void ListItems()
    {
        foreach (InvoiceItem invoiceItem in InvoiceItems)
        {
            Console.WriteLine(invoiceItem);
        }
    }
}
