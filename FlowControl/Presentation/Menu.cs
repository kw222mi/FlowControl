using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowControl.Application;

namespace FlowControl.Presentation
{
        public class Menu
        {
            private readonly IConsoleIO _io;
            private readonly List<IMenuAction> _actions;

            public Menu(IConsoleIO io, IEnumerable<IMenuAction> actions)
            {
                _io = io;
                _actions = actions.ToList();
            }

            public void Run()
            {
                var running = true;

                while (running)
                {
                    _io.Clear();
                    _io.WriteLine("=== HUVUDMENY ===");
                    foreach (var a in _actions)
                        _io.WriteLine($"{a.Key}. {a.Label}");
                    _io.WriteLine("0. Avsluta");
                    _io.Write("\nVälj ett alternativ: ");

                    var choice = _io.ReadLine();

                    if (choice == "0")
                    {
                        _io.WriteLine("Avslutar programmet...");
                        running = false;
                    }
                    else
                    {
                        var action = _actions.FirstOrDefault(a => a.Key == choice);
                        if (action is null)
                        {
                            _io.WriteLine("Ogiltigt val, försök igen!");
                        }
                        else
                        {
                            action.Execute();
                        }

                        if (running)
                        {
                            _io.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                            _io.ReadKey();
                        }
                    }
                }
            }
        }
    }
