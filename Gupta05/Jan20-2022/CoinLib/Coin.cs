using System;
/// <summary>
/// Gupta, Mailisa milisa
/// </summary>
namespace CoinLib
{
    public record Coin : IComparable, ICoin
    {
        private Denomination _coinObject;
        public enum Denomination { Slug = 0, Nickel = 5, Dime = 10, Quarter = 25, HalfDollar = 50 }

        // parameterless constructor – coin will be a slug
        public Coin()
        {
            _coinObject = Denomination.Slug;
        }

        // parametered constructor – coin will be of appropriate value
        // if value passed is outside normal set (e.g. 5 cents = Nickel)
        // coin is a slug     
        public Coin(Denomination coinEnumeral)
        {
            _coinObject = coinEnumeral;
        }

        // This constructor will take a string and return the appropriate enumeral
        public Coin(string coinName)
        {
            Denomination coinEnumeral;
            if (Enum.IsDefined(typeof(Denomination), coinName) &&
                Enum.TryParse<Denomination>(coinName, out coinEnumeral))
            {

                _coinObject = coinEnumeral;
            }
            else
            {
                _coinObject = Denomination.Slug;
            }
        }

        // parametered constructor – coin will be of appropriate value
        public Coin(decimal coinValue)
        {
            Denomination castFromValue = (Denomination)(coinValue * 100);
            switch (castFromValue)
            {
                case Denomination.Nickel:
                case Denomination.Dime:
                case Denomination.Quarter:
                case Denomination.HalfDollar:
                    _coinObject = castFromValue;
                    break;
                default:
                    _coinObject = Denomination.Slug;
                    break;
            }
        }

        //  This property will get the monetary value of the coin.
        public decimal ValueOf
        {
            get
            {
                return (decimal)_coinObject / 100M;
            }
 
        }

        public static decimal DenominationValue(Denomination d)
        {
            return (int)d / 100M;
        }

        //  This property will get the coin name as an enumeral
        public Denomination CoinEnumeral
        {
            get
            {
                return _coinObject;
            }
        }

        public virtual bool Equals(ICoin other)
        {
            return ValueOf == other.ValueOf;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // use Enum.GetName() with a private Denomination instance variable
        // to produce a string
        public override string ToString()
        {
            return Enum.GetName(typeof(Denomination), _coinObject);
        }

        public int CompareTo(object obj)
        {
            if (Equals(this, obj as Coin)) return 0;
            else if (ValueOf < (obj as Coin).ValueOf) return -1;
            else return 1;
        }

    }
}
