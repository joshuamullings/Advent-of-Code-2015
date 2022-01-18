using System;

public class Day05_01
{
    public void Main()
    {
        /***
        Nice strings have all of the below:
            It contains at least three vowels(aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
            It contains at least one letter that appears twice in a row, like xx, abcdde(dd), or aabbccdd(aa, bb, cc, or dd).
            It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
        ***/

        // conditions
        string[] vowels = new string[] { "a", "e", "i", "o", "u" };
        string[] disallowedDoubles = new string[] { "ab", "cd", "pq", "xy" };

        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\Day05.txt");

        // flags
        bool doubleLetter;
        bool doubleDisallowed;

        // counts
        int vowelCount = 0;
        int niceStringCount = 0;

        // strings
        string s = "";
        string sDisallowedDoubles = "";

        // chars
        char c;
        char cNext;

        // loop over strings
        for (int i = 0; i < inputs.Length; i++)
        {
            // reset
            doubleLetter = false;
            doubleDisallowed = false;
            vowelCount = 0;

            // update string for analysis
            s = inputs[i];

            // loop over string characters
            for (int j = 0; j < s.Length; j++)
            {
                // vowels check
                if (s[j].ToString() == vowels[0] || s[j].ToString() == vowels[1] || 
                    s[j].ToString() == vowels[2] || s[j].ToString() == vowels[3] || 
                    s[j].ToString() == vowels[4]) 
                {
                    vowelCount++;
                }

                try
                {
                    // read current and next character
                    c = s[j];
                    cNext = s[j+1];
                }
                catch
                {
                    // end of string, jump out as any futher checks are unesscary
                    break;
                }

                // double letter checks
                if (c == cNext)
                {
                    doubleLetter = true;
                }

                // construct double string
                sDisallowedDoubles = c.ToString() + cNext.ToString();

                // double disallowed letter
                if (sDisallowedDoubles == disallowedDoubles[0] || sDisallowedDoubles == disallowedDoubles[1] || 
                    sDisallowedDoubles == disallowedDoubles[2] || sDisallowedDoubles == disallowedDoubles[3])
                {
                    doubleDisallowed = true;
                    
                    // jump out, as any further checks are unesscary
                    break;
                }
            }

            // if we have a nice string
            if (vowelCount >= 3 && doubleLetter == true && doubleDisallowed == false)
            {
                niceStringCount++;
            }
        }

        Console.WriteLine(niceStringCount);
    }
}