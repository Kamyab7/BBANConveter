using ISO13616;

var ibanSepah = new IBAN("3120059467089", "015", AccountType.Seporde, "IR");

var iban = new IBAN("8480771708", "012", AccountType.Seporde, "IR");

var iban2 = new IBAN("020000005236350887", "012", AccountType.Seporde, "IR");

Console.WriteLine(ibanSepah.Value);

Console.WriteLine(iban.Value);

Console.WriteLine(iban2.Value);

Console.ReadLine();
