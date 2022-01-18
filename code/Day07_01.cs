using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day07_01
{
    public void Main()
    {
        // Instructions Booklet
        // ->       SixteenBit.Assign(UInt16)
        // AND      SixteenBit.And(SixteenBit)
        // OR       SixteenBit.Or(SixteenBit)
        // NOT      SixteenBit.Not()
        // LSHIFT   SixteenBit.LShift(int shift)
        // RSHIFT   SixteenBit.RShift(int shift)

        // string array of inputs
        string[] inputs = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Programming\Advent of Code\2015\Inputs\Day07.txt");

        // list of instructions
        List<SixteenBit> instructions = new List<SixteenBit>() { };

        // populate new list with blank enteries for updating later, some will be unused and removed
        // don't ask, it just works..
        for (int i = 0; i < inputs.Length; i++)
        {
            instructions.Add(new SixteenBit() { name = "", bits = "0000000000000000" } );
        }

        // parse each input
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i].Contains("AND"))
            {
                string[] output = Regex.Split(inputs[i], "[^a-z]+");

                // output[0] input1
                // output[1] input2
                // output[2] output

                int j = 0;
                int k = 0;

                // loop over instruction names
                for (; j < instructions.Count; j++)
                {
                    // once a match is found
                    if (instructions[j].name == output[0])
                    {
                        break;
                    }
                }

                for (; k < instructions.Count; k++)
                {
                    // once a match is found
                    if (instructions[k].name == output[1])
                    {
                        break;
                    }
                }

                instructions[i].name = output[2];
                instructions[i].And(instructions[j].bits, instructions[k].bits);
            }
            else if (inputs[i].Contains("OR"))
            {
                string[] output = Regex.Split(inputs[i], "[^a-z]+");

                // output[0] input1
                // output[1] input2
                // output[2] output

                int j = 0;
                int k = 0;

                // loop over instruction names
                for (; j < instructions.Count; j++)
                {
                    // once a match is found
                    if (instructions[j].name == output[0])
                    {
                        break;
                    }
                }

                for (; k < instructions.Count; k++)
                {
                    // once a match is found
                    if (instructions[k].name == output[1])
                    {
                        break;
                    }
                }

                instructions[i].name = output[2];
                instructions[i].Or(instructions[j].bits, instructions[k].bits);
            }
            else if (inputs[i].Contains("NOT"))
            {
                string[] output = Regex.Split(inputs[i], "[^a-z]+");

                // output[1] input1
                // output[2] output

                int j = 0;

                // loop over instruction names
                for (; j < instructions.Count; j++)
                {
                    // once a match is found
                    if (instructions[j].name == output[1])
                    {
                        break;
                    }
                }

                instructions[i].name = output[2];
                instructions[i].Not(instructions[j].bits);
            }
            else if (inputs[i].Contains("LSHIFT"))
            {
                string[] output = Regex.Split(inputs[i], "[^a-z0-9]+");

                // output[0] input1
                // output[1] value
                // output[2] output

                int j = 0;

                // loop over instruction names
                for (; j < instructions.Count; j++)
                {
                    // once a match is found
                    if (instructions[j].name == output[0])
                    {
                        break;
                    }
                }

                instructions[i].name = output[2];
                instructions[i].LShift(instructions[j].bits, UInt16.Parse(output[1]));
            }
            else if (inputs[i].Contains("RSHIFT"))
            {
                string[] output = Regex.Split(inputs[i], "[^a-z0-9]+");
                
                // output[0] input1
                // output[1] value
                // output[2] output

                int j = 0;

                // loop over instruction names
                for (; j < instructions.Count; j++)
                {
                    // once a match is found
                    if (instructions[j].name == output[0])
                    {
                        break;
                    }
                }

                // if no match was found
                if (j == instructions.Count)
                {
                    Console.WriteLine("no match");
                }
                // else a match was found
                else
                {
                    instructions[i].name = output[2];
                    instructions[i].RShift(instructions[j].bits, UInt16.Parse(output[1]));
                }
            }
            else // it must be an assignment
            {
                string[] output = Regex.Split(inputs[i], "[^a-z0-9]+");

                instructions[i].name = output[1];
                instructions[i].Assign(output[0]);
            }
        }

        // loop over all saved values
        for (int i = 0; i < instructions.Count; i++)
        {
            // if we have saved values
            if (instructions[i].name != "")
            {
                // output to console
                Console.WriteLine(instructions[i].name + " " + instructions[i].bits + " " + instructions[i].value);
            }
        }
    }
}

public class SixteenBit
{
    public string name = "";
    public string bits = "";
    public int value = 0;

    public SixteenBit()
    {
        try
        {
            name = "";
            bits = Convert.ToString(0, toBase: 2);
            bits = bits.PadLeft(16, '0');
            value = CalculateIntegerValue();
        }
        catch(InvalidCastException e)
        {
            Console.WriteLine(e);
        }
    }

    private int CalculateIntegerValue()
    {
        int value = 0;

        for (int i = 0; i < this.bits.Length; i++)
        {
            if (this.bits[i] == '1')
            {
                value = value +(int)MathF.Pow(2,(float)this.bits.Length - i - 1);
            }
        }

        return value;
    }

    public void Assign(string a)
    {
        try
        {
            bits = Convert.ToString(UInt16.Parse(a), toBase: 2);
            bits = bits.PadLeft(16, '0');
            value = CalculateIntegerValue();
        }
        catch(InvalidCastException e)
        {
            Console.WriteLine(e);
        }
    }

    public void And(string a, string b)
    {
        string temp = "";

        for (int i = 0; i <= 15; i++)
        {
            if (a[i] == '1' && b[i] == '1')
            {
                temp += "1";
            }
            else
            {
                temp += "0";
            }
        }

        this.bits = temp;
        this.value = CalculateIntegerValue();
    }

    public void Or(string a, string b)
    {
        string temp = "";

        for (int i = 0; i <= 15; i++)
        {
            if (a[i] == '1' || b[i] == '1')
            {
                temp += "1";
            }
            else
            {
                temp += "0";
            }
        }

        this.bits = temp;
        this.value = CalculateIntegerValue();
    }

    public void Not(string a)
    {
        string temp = "";

        for (int i = 0; i <= 15; i++)
        {
            if (a[i] == '1')
            {
                temp += "0";
            }
            else
            {
                temp += "1";
            }
        }

        this.bits = temp;
        this.value = CalculateIntegerValue();
    }

    public void LShift(string a, int shift)
    {
        string temp = "";

        for (int i = shift; i <= 15; i++)
        {
            temp += a[i];
        }

        // fill in remainder with 0
        for (int i = 0; i < shift; i++)
        {
            temp += "0";
        }

        this.bits = temp;
        this.value = CalculateIntegerValue();
    }

    public void RShift(string a, int shift)
    {
        string temp = "";

        for (int i = 0; i <= shift; i++)
        {
            temp += a[0];
        }

        for (int i = shift; i <= 15 - shift; i++)
        {
            temp += a[i];
        }

        this.bits = temp;
        this.value = CalculateIntegerValue();
    }
}