using System;
using System.Text.RegularExpressions;

public class Day06_01
{
    public void Main()
    {
        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\06.txt");

        // list of movements
        int[,] movements = new int[inputs.Length,4];

        // 2d lights array
        bool[,] lights = new bool[1000,1000];

        // turn off all lights
        lights = LightSwitchOff(lights, 0, 0, 999, 999);

        // EXTRACT MOVEMENTS
        // loop over inputs
        for (int i = 0; i < inputs.Length; i++)
        {
            // extract movements
            string[] numbers = Regex.Split(inputs[i], @"\D+");

            // track number of extracts to movements, there will always be 4
            int k = 0;

            // loop over extracts
            for (int j = 0; j < numbers.Length; j++)
            {
                // if extract isn't empty
                if (!string.IsNullOrEmpty(numbers[j]))
                {
                    // parse the number to an int and save it into our movements array
                    movements[i,k] = Int32.Parse(numbers[j]);
                    k++;
                }
            }
        }

        // PROCESS MOVEMENTS
        // i = 0 matches in both inputs and movements arrays
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i].Contains("turn on"))
            {
                lights = LightSwitchOn(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
            else if (inputs[i].Contains("turn off"))
            {
                lights = LightSwitchOff(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
            else if (inputs[i].Contains("toggle"))
            {
                lights = LightSwitchToggle(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
        }

        int lightsCount = 0;

        // count lights
        for (int i = 0; i < lights.GetLength(0); i++)
        {
            for(int j = 0; j < lights.GetLength(1); j++)
            {
                if (lights[i,j] == true)
                {
                    lightsCount++;
                }
            }
        }

        Console.WriteLine(lightsCount); 
    }

    private bool[,] LightSwitchOn(bool[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                array[i,j] = true;
            }
        }

        return array;
    }

    private bool[,] LightSwitchOff(bool[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                array[i,j] = false;
            }
        }

        return array;
    }

    private bool[,] LightSwitchToggle(bool[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        bool b;

        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                b = array[i,j];

                // flip reverse it
                if (b == true)
                {
                    array[i,j] = false;
                }
                else
                {
                    array[i,j] = true;
                }
            }
        }

        return array;
    }
}