using FluentAssertions;

namespace IBANConverter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("3120059467089", "015", AccountType.Seporde, "IR", "IR220150000003120059467089")]
        public void Test1(string accountNumber, string bankId, AccountType accountType, string countryCode,string expectedIBANValue)
        {
            var iban = new IBAN(accountNumber, bankId, accountType, countryCode);

            iban.AccountNumber.Should().Be(accountNumber);
            iban.AccountType.Should().Be(accountType);
            iban.CC.Should().Be(countryCode);
            iban.Value.Should().Be(expectedIBANValue);
        }
    }
}