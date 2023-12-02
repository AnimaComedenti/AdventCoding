using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class CubeConundrum
    {
        const int RED_CUBE_RULE = 12;
        const int GREEN_CUBE_RULE = 13;
        const int BLUE_CUBE_RULE = 14;

        const string GREEN = "green";
        const string BLUE = "blue";
        const string RED = "red";

        static string textFilePath = @"..\..\..\input.txt";

        int greenLow = 1;
        int redLow = 1;
        int blueLow = 1;

        public int calculateResult(out int minimumResult)
        {
            minimumResult = 0;

            int resultOfPossible = 0;
            string[] inputData = InputData();
            bool isPossible;
     

            for (int i = 0; i < inputData.Length; i++)
            {
                isPossible = true;
                string[] words = inputData[i].Split(':', ';', ',');

                greenLow = 1;
                redLow = 1;
                blueLow = 1;

                bool isPoss = true;

                for (int y = 1; y < words.Length; y++)
                {
                    string[] values = words[y].Split(' ');

                    isPossible = checkIfPosible(values[1], values[2]);
                    if (!isPossible)
                    {
                        isPoss = false;
                    }
                }

                int multiplLows = greenLow * redLow * blueLow;

                minimumResult += multiplLows;
                if (isPoss) resultOfPossible += i + 1;
            }

            return resultOfPossible;
        }

        private bool checkIfPosible(string amount, string color)
        {
            int parsedAmount = int.Parse(amount);

            switch (color)
            {
                case RED:
                    if(parsedAmount > redLow) redLow = parsedAmount;
                    if (parsedAmount > RED_CUBE_RULE) return false;
                    break;
                case GREEN:
                    if (parsedAmount > greenLow) greenLow = parsedAmount;
                    if (parsedAmount > GREEN_CUBE_RULE) return false;
                    break;
                case BLUE:
                    if (parsedAmount > blueLow) blueLow = parsedAmount;
                    if (parsedAmount > BLUE_CUBE_RULE) return false;
                    break;
            }
            return true;
        }

        private string[] InputData()
        {
            string[] lines = File.ReadAllLines(textFilePath);

            return lines;
        }
        
    }
}
