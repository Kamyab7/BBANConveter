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
        [TestCase("3120059467089", "015", AccountType.Seporde, "IR", "IR220150000003120059467089","22")]
        [TestCase("611828005118352001", "056", AccountType.Seporde, "IR", "IR730560611828005118352001","73")]
        [TestCase("020000008490224981", "012", AccountType.Seporde, "IR", "IR330120020000008490224981","33")]
        public void Test1(string accountNumber, string bankId, AccountType accountType, string countryCode,string expectedIBANValue,string expectedCD)
        {
            var iban = new IBAN(accountNumber, bankId, accountType, countryCode);

            iban.AccountNumber.Should().Be(accountNumber);
            iban.AccountType.Should().Be(accountType);
            iban.CC.Should().Be(countryCode);
            iban.CD.Should().Be(expectedCD);
            iban.Value.Should().Be(expectedIBANValue);
            iban.IsValid.Should().BeTrue();
        }
    }
}