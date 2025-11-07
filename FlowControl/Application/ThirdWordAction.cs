
using FlowControl.Presentation;
using FlowControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Application
{
    public class ThirdWordAction : IMenuAction
    {

        private readonly IConsoleIO _io;
        public string Key => "4";
        public string Label => "Det tredje ordet";
        public ThirdWordAction(IConsoleIO io) => _io = io;

        public void Execute()
        {

            _io.WriteLine("=== Det tredje ordet ===");

            while (true)
            {
                _io.Write("Skriv en mening (minst tre ord): ");
                string input = _io.ReadLine();

                try
                {
                    string thirdWord = TextUtilities.GetThirdWord(input);
                    _io.WriteLine($"\nDet tredje ordet är: {thirdWord}");
                    break; // success → exit loop
                }
                catch (ArgumentException ex)
                {
                    _io.WriteLine(ex.Message);
                    _io.WriteLine("Försök igen!\n");
                }
            }
        }
    }
    }



