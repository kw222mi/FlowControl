// /Application/InputReader.cs
using FlowControl.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Application
{
    public static class InputReader
    {
        public static int ReadInt(IConsoleIO io, string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                io.Write(prompt);
                var input = io.ReadLine();

                if (!int.TryParse(input, out var value))
                {
                    io.WriteLine("Ogiltig inmatning. Skriv ett heltal.");
                    continue;
                }

                if (min.HasValue && value < min.Value)
                {
                    io.WriteLine($"Talet måste vara minst {min.Value}.");
                    continue;
                }

                if (max.HasValue && value > max.Value)
                {
                    io.WriteLine($"Talet får vara högst {max.Value}.");
                    continue;
                }

                return value;
            }
        }
    }
}

