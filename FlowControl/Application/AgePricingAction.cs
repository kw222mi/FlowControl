// /Application/AgePricingAction.cs

using FlowControl.Application;
using FlowControl.Domain;
using FlowControl.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Application
{
    public class AgePricingAction : IMenuAction
    {
        private readonly IConsoleIO _io;

        public AgePricingAction(IConsoleIO io) => _io = io;

        public string Key => "1";
        public string Label => "Ungdom eller pensionär";

        public void Execute()
        {
            var age = InputReader.ReadInt(_io, "Ange din ålder: ", min: 0);
            var price = TicketPriceCalculator.GetTicketPrice(age);

            if (price == 0) _io.WriteLine("Gratis!");
            else if (age < 20) _io.WriteLine($"Ungdomspris: {price} kr");
            else if (age >= 65) _io.WriteLine($"Pensionärspris: {price} kr");
            else _io.WriteLine($"Standardpris: {price} kr");
        }
    }
}

