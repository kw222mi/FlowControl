using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Domain
{
    internal class TicketPriceCalculator
    {


        // --- Helper: Central ticket price rules (single source of truth) ---
        public static int GetTicketPrice(int age)
        {
            // Optional bonus rule: free for <5 or >100
            if (age < 5 || age > 100) return 0;

            // Base rules
            if (age < 20) return 80;
            if (age >= 65) return 90;

            // Default price
            return 120;
        }
    }
}
