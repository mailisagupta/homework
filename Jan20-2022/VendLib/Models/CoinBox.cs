using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Gupta, Mailisa milisa
/// </summary>
namespace VendLib
{
    public class CoinBox<T> : IEnumerable<T>, ICoinBox<T> where T : ICoin
    {
        public event Action ExactChangeRequired = delegate { };
        private List<T> _box;
        // constructor to create an empty coin box
        public CoinBox()
        {
            _box = new List<T>();
        }


        // constructor to create a coin box with some coins in it
        public CoinBox(List<T> seedMoney)
        {
            _box = seedMoney.ToList();
        }


        // put a coin in the coin box
        public void Deposit(T aCoin)
        {
            _box.Add(aCoin);
        }

        public void Balance(ICoinBox<T> target, decimal amountToTransfer, T cd, T cn)
        {

            List<T> c = new List<T>(_box);
            List<T> m = new List<T>();

            decimal amountLeftToRemove = amountToTransfer;
            decimal amountmore;
            foreach (T coin in _box)
            {
                if (amountLeftToRemove < coin.ValueOf && amountLeftToRemove > 0.00M)
                {

                    amountmore = coin.ValueOf - amountLeftToRemove;

                    for (int i = 0; i < amountLeftToRemove / 0.10M; i++)
                    {

                        target.Deposit(cd);
                    }


                    amountLeftToRemove = 0.00M;
                    c.Remove(coin);

                    if (amountmore % 0.10M == 0)
                    {

                        for (int i = 0; i < amountmore / 0.10M; i++)
                        {
                            c.Add(cd);
                        }
                    }
                    else
                    {

                        for (int i = 0; i < amountmore / 0.05M; i++)
                        {
                            c.Add(cn);
                        }
                    }
                }
                else if (amountLeftToRemove >= coin.ValueOf && amountLeftToRemove > 0.00M)
                {
                    amountLeftToRemove = amountLeftToRemove - coin.ValueOf;
                    target.Deposit(coin);
                    c.Remove(coin);

                }


            }
            _box = c;

        }
        public bool Transfer(CoinBox<T> target, decimal amountToTransfer,
            bool overdrawWhenNecessary = false)
        {
            CoinBox<T> removedCoins = new();
            bool targetModified = false;
            decimal amountLeftToRemove = amountToTransfer;
            if (!_box.Any()) return targetModified;
            T greatestValueCoin = _box.Max();
            T leastValueCoin = _box.Min();

            if (greatestValueCoin.ValueOf <= 0M) return targetModified;

            while (leastValueCoin.ValueOf <= 0M)
            {
                leastValueCoin =
                    _box.Where(c => c.ValueOf > leastValueCoin.ValueOf).Min();
            }

            if (ValueOf < amountToTransfer)
            {
                foreach (T coin in _box) removedCoins.Deposit(coin);
                _box.Clear();
            }
            else
            {
                T current = greatestValueCoin;
                while (removedCoins.ValueOf < amountToTransfer)
                {
                    if (amountLeftToRemove >= current.ValueOf &&
                        _box.Where(c => c.ValueOf == current.ValueOf).Any())
                    {
                        amountLeftToRemove -= current.ValueOf;
                        _box.Remove(current);
                        removedCoins.Deposit(current);
                    }
                    else
                    {
                        current = _box.Where(c => c.ValueOf < current.ValueOf).Max();
                        if (current is null || current.ValueOf <= 0M) break;
                    }
                }
            }
            if (amountToTransfer > removedCoins.ValueOf && overdrawWhenNecessary)
            {
                if (_box.Where(c => c.ValueOf == leastValueCoin.ValueOf).Any())
                {
                    _box.Remove(leastValueCoin);
                    removedCoins.Deposit(leastValueCoin);
                }
            }

            foreach (T coin in removedCoins) target.Deposit(coin);
            targetModified = true;

            return targetModified;
        }

        // withdraw specified amount from coinbox
        public decimal Withdraw(decimal amountToRemove, bool overdrawWhenNecessary = false)
        {
            CoinBox<T> removedCoins = new();
            Transfer(removedCoins, amountToRemove, overdrawWhenNecessary);
            if (!CanMakeChange) ExactChangeRequired();
            return removedCoins.ValueOf;

        }



        public bool CanMakeChange
        {
            get
            {
                return (
                    ContainsExactChangeFor(0.05M) &&
                    ContainsExactChangeFor(0.20M) &&
                    ContainsExactChangeFor(0.25M) &&
                    ContainsExactChangeFor(0.35M) &&
                    ContainsExactChangeFor(0.45M) &&
                    ContainsExactChangeFor(0.50M)
                    );
            }
        }




        public decimal ValueOf
        {
            get
            {
                return _box.Sum(t => t.ValueOf);
            } /// this is equavalent to  _box.Sum(delegate (T t) { return t.ValueOf; });

        }


        private bool ContainsExactChangeFor(decimal amount)
        {
            CoinBox<T> removedCoins = new();
            Transfer(removedCoins, amount, false);
            bool result = removedCoins.ValueOf == amount;
            removedCoins.Transfer(this, removedCoins.ValueOf, false);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _box.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
