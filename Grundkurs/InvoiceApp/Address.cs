﻿namespace InvoiceApp;

public class Address
{
    public string Street { get; set; } = "";
    public string Number { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";

    public override string ToString() => $"{Street} {Number}, {PostalCode} {City}";
}
