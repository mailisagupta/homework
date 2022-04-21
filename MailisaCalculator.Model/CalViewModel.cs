using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MailisaCalculator.Model
{
    public class CalViewModel : INotifyPropertyChanged
    {
        public int Entry { get; set; }
        public int Modified { get; set; }
        private bool _beginNewEntry = false;
        private string symbol;
        public event PropertyChangedEventHandler PropertyChanged;

        public void Add()
        {
            Modified = Modified + Entry;
            _beginNewEntry = true;
            symbol = "+";
           
           
        }

        public void Sub()
        {
            Modified = Modified + Entry;
            _beginNewEntry = true;
            symbol = "-";


        }

        public void Multiply()
        {
            Modified = Modified * Entry;
            _beginNewEntry = true;
            symbol = "*";

        }

        public void Divide()
        {
            Modified = Modified / Entry;
            _beginNewEntry = true;
            symbol = "/";

        }

        public void Clear()
        {
            Entry = Modified = 0;
        }

        public void Equals()
        {
            switch (symbol)
            {
                case "+":
                    Entry = Modified + Entry;
                    Modified = 0;
                    _beginNewEntry = true;
                    break;
                case "-":
                    Entry = Modified - Entry;
                    Modified = 0;
                    _beginNewEntry = true;
                    break;
                case "*":
                    Entry = Modified * Entry;
                    Modified = 0;
                    _beginNewEntry = true;
                    break;
                case "/":
                    Entry = Modified / Entry;
                    Modified = 0;
                    _beginNewEntry = true;
                    break;
                default:
                    break;
            }
            
        }

        public void BuildEntry(int entry)
        {
            if (entry < 0 || entry > 9) return;
            if (_beginNewEntry)
            {
                Entry = entry;
                _beginNewEntry = false;
            }
            else
            {
                Entry = Entry * 10 + entry;
            }
        }

        public CalCommands<string> DigitCommand { get; set; }
        public CalCommands<string> AddCommand { get; set; }
        public CalCommands<string> EqualsCommand { get; set; }
        public CalCommands<string> ClearCommand { get; set; }
        public CalCommands<string> SubtractCommand { get; set; }

        public CalViewModel()
        {
            DigitCommand= new CalCommands<string>(
                (x) => { BuildEntry(int.Parse(x));
                    InvokePropertChange(nameof(Entry));
                },
                () => true
                );
            AddCommand = new CalCommands<string>(
                (x) => { Add(); InvokePropertChange(nameof(Entry)); },
                () => true
                );

            SubtractCommand = new CalCommands<string>(
               (x) => { Sub(); InvokePropertChange(nameof(Entry)); },
               () => true
               );

            EqualsCommand = new CalCommands<string>(
                (x) => { Equals(); InvokePropertChange(nameof(Entry)); },
                () => true);




        }

        public void InvokePropertChange([CallerMemberName] string property = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs (property));
        }
    }
}
