using IBANConverter;

var iban = new IBAN("3120059467089", "015", AccountType.Seporde, "IR");

if (iban.IsValid)
    Console.WriteLine("Valid");
else
    Console.WriteLine("InValid");


Console.WriteLine(iban.Value);

Console.ReadLine();
