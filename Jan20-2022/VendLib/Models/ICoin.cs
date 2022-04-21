namespace VendLib
{
    /// <summary>
/// Gupta, Mailisa milisa
/// </summary>
    public interface ICoin
    {
        Coin.Denomination CoinEnumeral { get; }
        decimal ValueOf { get; }

        int CompareTo(object obj);
        bool Equals(ICoin other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}