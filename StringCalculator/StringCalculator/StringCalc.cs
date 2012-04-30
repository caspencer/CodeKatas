using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Add(string input)
        {
            int sum = 0;
            var delimiters = new List<string>(new[] {",", "\n"});
            var negativeNumbers = new List<int>();

            if (input == string.Empty)
                return sum;

            // override delimiter
            if (input.StartsWith("//"))
            {
                int indexOfFirstNewline = input.IndexOf('\n');
                string delimiterLine = input.Substring(2, indexOfFirstNewline - 2);

                // is multichar delimiter?
                if (delimiterLine.StartsWith("[") && delimiterLine.EndsWith("]"))
                {
                    delimiterLine = delimiterLine.Substring(1, delimiterLine.LastIndexOf(']') - 1);
                    delimiters.AddRange(delimiterLine.Split(new[] {"]["}, StringSplitOptions.None));
                }
                else
                {
                    delimiters.Add(delimiterLine);
                }

                input = input.Substring(indexOfFirstNewline + 1);
            }

            string[] numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);
            foreach (string number in numbers)
            {
                int numberVal;
                if (int.TryParse(number, out numberVal))
                {
                    if (numberVal < 0)
                        negativeNumbers.Add(numberVal);

                    if (numberVal <= 1000)
                        sum += numberVal;
                }
            }

            if (negativeNumbers.Count > 0)
            {
                string msg = string.Format("negatives not allowed: {0}", string.Join(",", negativeNumbers.ToArray()));
                throw new ArgumentOutOfRangeException("input", msg);
            }

            return sum;
        }
    }
}