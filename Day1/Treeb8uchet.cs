using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Treeb8uchet
    {
        static string textFilePath = @"..\..\..\input.txt";
        public int calculateCalibrationValue()
        {
            int result = 0;
            string[] textToSearchIn = getInput();

            foreach (string line in textToSearchIn)
            {
                Console.WriteLine(line);
                result += calculateValue(line);
                Console.WriteLine(result);
            }

            return result;
        }

        private int calculateValue(string line)
        {
            char firstValue = ' ';
            char lastValue = ' ';
            char[] characters = line.ToCharArray();

            string word = "";

            foreach (char c in characters)
            {
                if (setValues(c, ref firstValue, ref lastValue))
                { 
                    word = "";
                    continue;
                }

                word += c.ToString();
                char MappingResult = mapStringToValue(word);

                if (setValues(MappingResult, ref firstValue, ref lastValue))
                {
                    word = word[word.Length - 1].ToString();
                }
            }

            string result = firstValue.ToString() + lastValue.ToString();
            return int.Parse(result);
        }
        private bool setValues(char c, ref char firstValue, ref char lastValue)
        {
            if (Char.IsNumber(c))
            {
                if (firstValue == ' ')
                {
                    firstValue = c;
                }
                lastValue = c;
                return true;
            }
            return false;
        }

        public string[] getInput()
        {
            string[] lines = File.ReadAllLines(textFilePath);
            return lines;
        }

        private Dictionary<string, char> stringValues = new Dictionary<string, char>
        {
            {"one", '1'}, {"two", '2'}, {"three",'3'}, {"four", '4'}, {"five",'5'}, {"six",'6'},  {"seven",'7'}, {"eight",'8'}, {"nine", '9'}
        };

        private string[] stingValues2 = new string[] {"one","two","three","four","five","six","seven","eight","nine"};

        public char mapStringToValue(string inputString)
        {
            char result = ' ';
            foreach (string str in stingValues2)
            {
                if (inputString.Contains(str))
                {
                    stringValues.TryGetValue(str, out result);
                    break;
                }
            }

            return result;
        }
    }
}
