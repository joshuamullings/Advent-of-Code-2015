using System;
using System.Collections.Generic;

public class Day03_02
{
    public void Main()
    {
        // string of input characters
        string input = System.IO.File.ReadAllText(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\Day03.txt");

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
        bool[,] santaRobot = new bool[5000, 5000];

        // start movement at center
        int xCoordSanta = 2500;
        int yCoordSanta = 2500;
        int xCoordSantaRobot = 2500;
        int yCoordSantaRobot = 2500;

        // start location recieves a present
        santa[2500, 2500] = true;
        santaRobot[2500, 2500] = true;

        // loop over list, finding direction of movement, updating coord and delivering a present
        // this time for santa and robot santa
        for (int i = 0; i < list.Count; i++)
        {
            // santa movement
            if (list[i].ToString() == "^")
            {
                yCoordSanta--;
                santa[xCoordSanta, yCoordSanta] = true;
            }
            else if (list[i].ToString() == "v")
            {
                yCoordSanta++;
                santa[xCoordSanta, yCoordSanta] = true;
            }
            else if (list[i].ToString() == "<")
            {
                xCoordSanta--;
                santa[xCoordSanta, yCoordSanta] = true;
            }
            else
            {
                xCoordSanta++;
                santa[xCoordSanta, yCoordSanta] = true;
            }

            // next instruction
            i++;

            // robot santa movement
            if (list[i].ToString() == "^")
            {
                yCoordSantaRobot--;
                santaRobot[xCoordSantaRobot, yCoordSantaRobot] = true;
            }
            else if (list[i].ToString() == "v")
            {
                yCoordSantaRobot++;
                santaRobot[xCoordSantaRobot, yCoordSantaRobot] = true;
            }
            else if (list[i].ToString() == "<")
            {
                xCoordSantaRobot--;
                santaRobot[xCoordSantaRobot, yCoordSantaRobot] = true;
            }
            else
            {
                xCoordSantaRobot++;
                santaRobot[xCoordSantaRobot, yCoordSantaRobot] = true;
            }
        }

        // final presents array
        bool[,] presents = new bool[5000, 5000];

        // combine arrays
        for (int i = 0; i < 5000; i++)
        {
            for (int j = 0; j < 5000; j++)
            {
                if (santa[i, j] == true)
                {
                    presents[i, j] = true;
                }

                if (santaRobot[i, j] == true)
                {
                    presents[i, j] = true;
                }
            }
        }  

        int presentTotal = 0;

        // loop over bool array
        for (int i = 0; i < 5000; i++)
        {
            for (int j = 0; j < 5000; j++)
            {
                if (presents[i, j] == true)
                {
                    presentTotal++;
                }
            }
        }  

        Console.WriteLine(presentTotal);
    }
}