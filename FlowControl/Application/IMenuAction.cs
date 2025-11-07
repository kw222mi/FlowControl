// /Application/IMenuAction.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControl.Application

{
    /// <summary>
    /// Represents a single selectable menu option in the program.
    /// Each implementation defines its own label, key, and logic when executed.
    /// </summary>
    public interface IMenuAction
    {
        /// <summary>
        /// The key the user types to select this action (e.g. "1", "2", "3"...).
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The label shown in the main menu list (e.g. "Ungdom eller pensionär").
        /// </summary>
        string Label { get; }

        /// <summary>
        /// Executes the code that runs when this menu option is selected.
        /// </summary>
        void Execute();
    }
}
