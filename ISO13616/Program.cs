using IBANConverter;

var iban = new IBAN("3120059467089", "015", AccountType.Seporde, "IR");


Console.WriteLine(iban.Value);

Console.ReadLine();
