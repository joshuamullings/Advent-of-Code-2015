using System;
using System.Collections.Generic;

public class Day03_01
{
    public void Main()
    {
        // string of input characters
        string input = System.IO.File.ReadAllText(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\03.txt");

        // create a list to hold each char
        List<char> list = new List<char>();

        // loop over all chars..
        for (int i = 0; i < input.Length; i++)
        {
            // adding each one to the list
            list.Add(input[i]);
        }

        // bool array with more than enough space to work in
        bool[,] santa = new bool[5000, 5000];

        // start movement at center
        int xCoord = 2500;
        int yCoord = 2500;

        // start location recieves a present
        santa[2500, 2500] = true;

        // loop over list, finding direction of movement, updating coord and delivering a present
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ToString() == "^")
            {
                yCoord--;
                santa[xCoord, yCoord] = true;
            }
            else if (list[i].ToString() == "v")
            {
                yCoord++;
                santa[xCoord, yCoord] = true;
            }
            else if (list[i].ToString() == "<")
            {
                xCoord--;
                santa[xCoord, yCoord] = true;
            }
            else
            {
                xCoord++;
                santa[xCoord, yCoord] = true;
            }
        }

        int presentTotal = 0;

        // loop over bool array
        for (int i = 0; i < 5000; i++)
        {
            for (int j = 0; j < 5000; j++)
            {
                if (santa[i, j] == true)
                {
                    presentTotal++;
                }
            }
        }  

        Console.WriteLine(presentTotal);
    }
}