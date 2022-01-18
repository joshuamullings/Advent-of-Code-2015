using System;
using System.Collections.Generic;

public class Day05_02
{
    public void Main()
    {
        /***
        Nice strings have all of the below:
            It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy(xy) or aabcdefgaa(aa), but not like aaa(aa, but it overlaps).
            It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi(efe), or even aaa.
        ***/

        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\05.txt");

        // flags
        bool doubleLetter;
        bool doublePair;

        // counts
        int niceStringCount = 0;

        // strings
        string s = "";
        string sDouble = "";

        // chars
        char c;
        char cNext;
        char cNextNext;

        // lists/arrays
        List<DoubleString> doubleStrings = new List<DoubleString>();

        // loop over strings
        for (int i = 0; i < inputs.Length; i++)
        {
            // reset
            doubleLetter = false;
            doublePair = false;
            doubleStrings.Clear();

            // update string for analysis
            s = inputs[i];

            // loop over string characters
            for (int j = 0; j < s.Length; j++)
            {
                // look one ahead first
                try
                {
                    // read current and next character
                    c = s[j];
                    cNext = s[j+1];

                    // construct double string
                    sDouble = c.ToString() + cNext.ToString();

                    // add to double string list along with position in string to keep track
                    doubleStrings.Add(new DoubleString(sDouble, j));                         
                }
                catch
                {
                    break;
                }

                // try two ahead next
                try
                {
                    // read nextnext character
                    cNextNext = s[j+2];

                    // double letter checks
                    if (c == cNextNext)
                    {
                        doubleLetter = true;
                    }
                }
                catch
                {
                    continue;
                }
            }

            // process double string list
            for (int j = 0; j < doubleStrings.Count; j++)
            {
                // hold tempory string
                string tempCompareString = doubleStrings[j].s;

                // compare each
                for (int k = 0; k < doubleStrings.Count; k++)
                {
                    // if the doubles match, are at least one entry apart, and aren't the same string
                    if (tempCompareString == doubleStrings[k].s &&
                            doubleStrings[k].count - doubleStrings[j].count >= 2 &&
                                j != k)
                    {
                        doublePair = true;
                    }
                }
            }

            // if we have a nice string
            if (doubleLetter == true && doublePair == true)
            {
                niceStringCount++;
            }
        }

        Console.WriteLine(niceStringCount);
    }
}

public class DoubleString
{
    public DoubleString(string S, int COUNT)
    {
        s = S;
        count = COUNT;
    }
    
    public string s { get; set; }
    public int count { get; set; }
}