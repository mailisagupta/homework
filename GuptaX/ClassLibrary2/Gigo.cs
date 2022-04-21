using System;

namespace ClassLibrary2
{
    public class Gigo 
    {
        private int _a;
        public event Action DecimalDetected = delegate { };
        public Gigo(int a)
        {
            _a = a;
        }

        public object Consume( object a)
        {
            if (a is int)
            {
                if ((int)a == 0) return 0;
                else if ((int)a > 0 && (int)a <= 100)
                {
                    if ((int)a % 2 == 0) return 0;
                    else return (int)a;
                }
                return (int)a;
            }

            else if (a is double)
            {
                throw new ArgumentException();
            }
            else if (a is string)
            {
                string t = (string)a;
                t = t.ToLower();
                if (t == "a"|| t == "e" || t == "i"|| t == "o"|| t == "u")
                {
                    return t.ToUpper();
                }
                else if (t== "answer")
                {
                    return 42;
                }
                return a;
            }
            else if (a is decimal )
            {
                DecimalDetected();
            }
            return a;
        }
    }
}
