// /Presentation/ConsoleIO.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Presentation
{
         public class ConsoleIO : IConsoleIO
        {
            public void Write(string text) => Console.Write(text);

            public void WriteLine(string text = "") => Console.WriteLine(text);

            public string ReadLine() => Console.ReadLine() ?? string.Empty;

            public void ReadKey() => Console.ReadKey(intercept: true);

            public void Clear() => Console.Clear();
        }
    }


