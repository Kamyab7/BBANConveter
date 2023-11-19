using System.ComponentModel.DataAnnotations;

namespace IBANConverter;

public class IBAN
{
    /// <summary>
    /// Country Code
    /// </summary>
    [StringLength(2)]
    public string? CC { get; set; }


    /// <summary>
    /// Check Digit
    /// </summary>
    [StringLength(2)]
    public string? CD => CalculateCD();


    /// <summary>
    /// Basic Bank Account Number
    /// </summary>
    [StringLength(22)]
    public string? BBAN => CalculateBBAN();


    /// <summary>
    /// International Bank Account Number
    /// </summary>
    [StringLength(26)]
    public string? Value => CalculateIBAN();


    /// <summary>
    /// Bank Account Number
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Bank Id
    /// </summary>
    public string BankId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public AccountType AccountType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Zeros => CalculateZeros();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="bankId"></param>
    /// <param name="accountType"></param>
    public IBAN(string accountNumber, string bankId, AccountType accountType, string countryCode)
    {
        AccountNumber = accountNumber;

        BankId = bankId;

        AccountType = accountType;

        CC = countryCode;
    }

    public bool IsValid => ValidateIBAN();

    private bool ValidateIBAN()
    {
        string firstFourChar = Value.Substring(0, 4);

        string manipulatedString = Value.Substring(4) + firstFourChar;

        foreach (var c in manipulatedString)
        {
            if (Dictionary.ContainsKey(c))
            {
                manipulatedString = manipulatedString.Replace(c.ToString(), Dictionary[c].ToString());
            }
        }

        if (manipulatedString.Length == 28 && Convert.ToDecimal(manipulatedString) % 97 == 1)
            return true;

        return false;
    }

    private string CalculateIBAN()
    {
        return $"{CC}{CD}{BBAN}";
    }


    private Dictionary<char, int> Dictionary = new Dictionary<char, int>()
    {
        ['A'] = 10,
        ['B'] = 11,
        ['C'] = 12,
        ['D'] = 13,
        ['E'] = 14,
        ['F'] = 15,
        ['G'] = 16,
        ['H'] = 17,
        ['I'] = 18,
        ['J'] = 19,
        ['K'] = 20,
        ['L'] = 21,
        ['M'] = 22,
        ['N'] = 23,
        ['O'] = 24,
        ['P'] = 25,
        ['Q'] = 26,
        ['R'] = 27,
        ['S'] = 28,
        ['T'] = 29,
        ['T'] = 30,
        ['T'] = 31,
        ['W'] = 32,
        ['X'] = 33,
        ['Y'] = 34,
        ['Z'] = 35,
    };

    private string CalculateCD()
    {
        string temp = $"{BBAN}{Dictionary[CC[0]]}{Dictionary[CC[1]]}" + "00";
        char[] a = temp.ToCharArray();
        int r = 0;

        foreach (char v in a)
        {
            r = (((r * 10) + int.Parse(v.ToString())) % 97);
        }

        int cd = 98 - r;

        return cd.ToString();
    }

    private string CalculateBBAN()
    {
        return $"{BankId}{(int)AccountType}{Zeros}{AccountNumber}";
    }

    private string CalculateZeros()
    {
        string zeros = String.Empty;
        int numberOfZeros = 18 - AccountNumber.Length;

        for (int i = 0; i < numberOfZeros; i++)
        {
            zeros += "0";
        }

        return zeros;
    }
}

public enum AccountType
{
    Seporde,
    Tashilat,
}
