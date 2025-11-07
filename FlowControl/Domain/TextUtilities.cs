using System;
using System.Text;

namespace FlowControl.Domain
{
    /// <summary>
    /// Provides utility methods for text manipulation within the domain layer.
    /// Contains reusable logic independent of user interface or application flow.
    /// </summary>
    public static class TextUtilities
    {
        /// <summary>
        /// Builds a repeated text string a specified number of times,
        /// numbering each repetition and separating them with commas.
        /// </summary>
        /// <param name="input">The text to repeat.</param>
        /// <param name="numberOfTimes">The number of times to repeat the text.</param>
        /// <returns>
        /// A string containing all repetitions separated by commas,
        /// or an empty string if the input is null or whitespace.
        /// </returns>
        public static string BuildRepetitions(string input, int numberOfTimes)
        {
            // Handle null or empty input early
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Use StringBuilder for efficient concatenation
            var sb = new StringBuilder();

            // Loop through and build the repeated string
            for (int i = 0; i < numberOfTimes; i++)
            {
                sb.Append($"{i + 1}. {input}");

                // Add comma and space between items, except after the last one
                if (i < numberOfTimes - 1)
                    sb.Append(", ");
            }

            // Return the completed string
            return sb.ToString();
        }

        /// <summary>
        /// Extracts the third word from a given sentence.
        /// Throws an exception if the sentence contains fewer than three words.
        /// </summary>
        /// <param name="sentence">The sentence to process.</param>
        /// <returns>The third word in the sentence.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if the input is null, empty, or has fewer than three words.
        /// </exception>
        public static string GetThirdWord(string sentence)
        {
            // Validate that input exists
            if (string.IsNullOrWhiteSpace(sentence))
                throw new ArgumentException("Input cannot be empty.");

            // Split the input string into words, removing extra spaces
            var words = sentence.Trim()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Validate that the sentence has at least three words
            if (words.Length < 3)
                throw new ArgumentException("Sentence must contain at least three words.");

            // Return the third word (index 2)
            return words[2];
        }
    }
}
