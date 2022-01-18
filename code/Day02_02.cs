using System;
using System.Collections.Generic;

public class Day02_02
{
    public void Main()
    {
        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\02.txt");

        // list to hold dimentions
        List<int> dimentions = new List<int>(3 * inputs.Length);

        // loop over each string input
        for (int i = 0; i < inputs.Length; i++)
        {
            // convert each string to a tempory char array for manipulation
            char[] c = inputs[i].ToCharArray();

            // tempory array to contruct numbers
            char[] numberConstructor = new char[2];

            // number constructor iterator
            int numberIterator = 0;

            // loop over each string character
            for (int j = 0; j < c.Length; j++)
            {
                // check if character is x
                if (c[j].ToString() == "x")
                {
                    // if so, parse our current numberConstructor buffer to the dimentions list
                    dimentions.Add(Int32.Parse(numberConstructor));

                    // clear current numberConstructor buffer
                    Array.Clear(numberConstructor, 0, numberConstructor.Length);

                    // reset number iterator
                    numberIterator = 0;
                }
                // else it must be a number
                else
                {
                    // add character(which is numerical in this case) to the numberConstructor
                    numberConstructor[numberIterator] = c[j];

                    // increment iterator
                    numberIterator++;
                }
            }

            // end of char array
            // parse our current numberConstructor buffer to the dimentions list for one last time
            dimentions.Add(Int32.Parse(numberConstructor));
        }

        int total = 0;

        // loop over all dimentions, grouping them into 3s
        for (int i = 0 ; i < dimentions.Count; i += 3)
        {
            // specify dimentions inside a list
            List<int> dimentionsCalculation = new List<int>
            {
                dimentions[i], dimentions[i+1], dimentions[i+2]
            };

            // sort dimentions into order, revealing the smallest
            dimentionsCalculation.Sort();

            // find total
            total = total + 2 * dimentionsCalculation[0] +
                            2 * dimentionsCalculation[1] +
                                dimentionsCalculation[0] * 
                                    dimentionsCalculation[1] * 
                                        dimentionsCalculation[2];
        }

        // output
        Console.WriteLine(total);
    }
}