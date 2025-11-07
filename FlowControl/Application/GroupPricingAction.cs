using FlowControl.Application;
using FlowControl.Domain;
using FlowControl.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// --- Menu option 2: Group pricing (sum across several ages) ---

namespace FlowControl.Application
{
    public class GroupPricingAction : IMenuAction
    {
        private readonly IConsoleIO _io;
        public string Key => "2";
        public string Label => "Grupppris";
        public GroupPricingAction(IConsoleIO io) => _io = io;

        public void Execute()
        {
            
                _io.WriteLine("=== Grupppris ===");

                // Ask how many people; must be at least 1
                int count = InputReader.ReadInt(_io, "Hur många personer? ", min: 1);

                int total = 0; // accumulator for total price

                // Loop over each person and collect their age
                for (int i = 1; i <= count; i++)
                {
                    int age = InputReader.ReadInt(_io, $"Ange ålder för person {i}: ", min: 0);
                    int price = TicketPriceCalculator.GetTicketPrice(age);
                    total += price;

                    _io.WriteLine($"Person {i}: {price} kr");
                }

                // Summary output
                 _io.WriteLine($"\nAntal personer: {count}");
                 _io.WriteLine($"Totalt: {total} kr");
            

        }
    }
}


