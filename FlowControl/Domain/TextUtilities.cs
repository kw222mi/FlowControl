using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Domain
{
    internal class TextUtilities
    {

        public static string BuildRepetitions(string input, int numberOfTimes)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Use a StringBuilder for efficiency
            var sb = new StringBuilder();

            for (int i = 0; i < numberOfTimes; i++)
            {
                sb.Append($"{i + 1}. {input}");

                // Add comma and space between items, except after the last one
                if (i < numberOfTimes - 1)
                {
                    sb.Append(", ");
                }
            }

            // Return the full string
            return sb.ToString();
        }


            public static string GetThirdWord(string sentence)
            {
                if (string.IsNullOrWhiteSpace(sentence))
                    throw new ArgumentException("Input cannot be empty.");

                // Trim and split the input into words, ignoring extra spaces
                var words = sentence.Trim()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length < 3)
                    throw new ArgumentException("Sentence must contain at least three words.");

                return words[2]; // index 2 = third word
            }
        }
    }





