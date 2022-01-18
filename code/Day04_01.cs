using System;
using System.Security.Cryptography;
using System.Text;

public class Day04_01
{
    public void Main()
    {
        // strings for things
        string secretKey = "ckczppom";
        string tempString = "";
        string hashString = "";

        int zeroes = 0;

        // increment string construction
        for (int i = 1; ; i++)
        {
            // construct string
            tempString = secretKey + i.ToString();

            // get hash of string
            hashString = GetHash(tempString);

            zeroes = 0;

            // check if we have zeroes
            for (int j = 0; j < hashString.Length; j++)
            {
                if (hashString[j].ToString() == "0")
                {
                    zeroes++;
                }
                else
                {
                    break;
                }
            }

            // stop if we have zeroes
            if (zeroes >= 5)
            {
                Console.WriteLine(tempString + " " + hashString);
                break;
            }
        }
    }

    private string GetHash(string s)
    {
        var md5Hash = MD5.Create();
        var sourceBytes = Encoding.UTF8.GetBytes(s);
        var hashBytes = md5Hash.ComputeHash(sourceBytes);
        var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

        return hash;
    }
}