using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Add(string input)
        {
            int sum = 0;
            List<string> delimiters = new List<string>(new string[] { ",", "\n" });
            List<int> negativeNumbers = new List<int>();

            if (input == string.Empty)
                return sum;

            // override delimiter
            if (input.StartsWith("//"))
            {
                int indexOfFirstNewline = input.IndexOf('\n');
                string delimiterLine = input.Substring(2, indexOfFirstNewline-2);

                // is multichar delimiter?
                if (delimiterLine.StartsWith("[") && delimiterLine.EndsWith("]"))
                {
                    delimiterLine = delimiterLine.Substring(1, delimiterLine.LastIndexOf(']') - 1);
                    delimiters.AddRange(delimiterLine.Split(new[] { "][" }, StringSplitOptions.None));
                }
                else
                {
                    delimiters.Add(delimiterLine);
                }

                input = input.Substring(indexOfFirstNewline + 1);
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);
            foreach (var number in numbers)
            {
                int numberVal = Convert.ToInt32(number);
                if (numberVal < 0)
                    negativeNumbers.Add(numberVal);

                if (numberVal <= 1000)
                    sum += numberVal;
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
