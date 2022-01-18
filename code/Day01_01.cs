using System;

public class Day01_01
{
    public void Main()
    {
        // string of input characters
        string input = System.IO.File.ReadAllText(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\Day01.txt");

        // start at floor 0
        int floor = 0;

        // loop over every input
        for (int i = 0; i < input.Length; i++)
        {
            // hold a single character
            string c = input[i].ToString();

            // check input
            if (c == "(")
            {
                floor++; // go up a floor
            } 
            else
            {
                floor--; // go down a floor
            }
        }

        // output
        Console.WriteLine(floor);
    }
}