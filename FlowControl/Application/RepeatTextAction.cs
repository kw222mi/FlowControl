using FlowControl.Domain;
using FlowControl.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Application
{
    public class RepeatTextAction: IMenuAction
    {
        private readonly IConsoleIO _io;
        public string Key => "3";
        public string Label => "Upprepa tio gånger";
        public RepeatTextAction(IConsoleIO io) => _io = io;

        public void Execute()
        {
            int numberOfTimes = 10;
            _io.Write("Ange ett ord eller en text att upprepa: ");
            string input = _io.ReadLine();

            // Domain-lager: make the string to write
            string result = TextUtilities.BuildRepetitions(input, numberOfTimes);

            // Application-lager: visa resultatet
            _io.WriteLine("\nResultat:");
            _io.WriteLine(result);
        }
    }
}
