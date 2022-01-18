using System;
using System.Text.RegularExpressions;

public class Day06_02
{
    public void Main()
    {
        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\Day06.txt");

        // list of movements
        int[,] movements = new int[inputs.Length,4];

        // 2d lights array
        int[,] lights = new int[1000,1000];

        // zero all brightness
        for (int i = 0; i < lights.GetLength(0); i++)
        {
            for (int j = 0; j < lights.GetLength(1); j++)
            {
                lights[i,j] = 0;
            }
        }

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
                lights = BrightnessUp(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
            else if (inputs[i].Contains("turn off"))
            {
                lights = BrightnessDown(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
            else if (inputs[i].Contains("toggle"))
            {
                lights = BrightnessUpUp(lights, movements[i,0], movements[i,2], movements[i,1], movements[i,3]);
            }
        }

        int brightnessCount = 0;

        // count brightness
        for (int i = 0; i < lights.GetLength(0); i++)
        {
            for (int j = 0; j < lights.GetLength(1); j++)
            {
                if (lights[i,j] > 0)
                {
                    brightnessCount += lights[i,j];
                }
            }
        }

        Console.WriteLine(brightnessCount); 
    }

    private int[,] BrightnessUp(int[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                array[i,j] += 1;
            }
        }

        return array;
    }

    private int[,] BrightnessDown(int[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                array[i,j] -= 1;

                if (array[i,j] < 0)
                {
                    array[i,j] = 0;
                }
            }
        }

        return array;
    }

    private int[,] BrightnessUpUp(int[,] array, int xStart, int xEnd, int yStart, int yEnd)
    {
        for (int i = xStart; i < xEnd + 1; i++)
        {
            for (int j = yStart; j < yEnd + 1; j++)
            {
                array[i,j] += 2;
            }
        }

        return array;
    }
}