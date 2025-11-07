using System;

namespace FlowControl.Domain
{
    /// <summary>
    /// Provides the business logic for calculating ticket prices based on age.
    /// This class serves as the single source of truth for all ticket price rules.
    /// </summary>
    public static class TicketPriceCalculator
    {
        /// <summary>
        /// Returns the ticket price for a given age according to predefined pricing rules.
        /// </summary>
        /// <param name="age">The customer's age.</param>
        /// <returns>
        /// The ticket price in SEK.
        /// Returns 0 for very young (&lt;5) or very old (&gt;100) customers.
        /// </returns>
        public static int GetTicketPrice(int age)
        {
            // --- Special rules ---
            // Free admission for children under 5 or seniors over 100
            if (age < 5 || age > 100)
                return 0;

            // --- Standard pricing tiers ---
            // Youth price for ages 5–19
            if (age < 20)
                return 80;

            // Senior discount for ages 65–100
            if (age >= 65)
                return 90;

            // --- Default price ---
            // Applies to all adults aged 20–64
            return 120;
        }
    }
}
