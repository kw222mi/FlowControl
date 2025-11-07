using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Presentation

{
    public interface IConsoleIO
    {
        // Write without newline
        void Write(string text);

        // Write with newline (default: just newline)
        void WriteLine(string text = "");

        // Read full line (never returns null)
        string ReadLine();

        // Wait for a key press (no echo)
        void ReadKey();

        // Clear screen
        void Clear();
    }
}
