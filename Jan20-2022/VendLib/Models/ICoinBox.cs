using System;
using System.Collections.Generic;

namespace VendLib
{
    public interface ICoinBox<T> : IEnumerable<T> where T : ICoin
    {
        bool CanMakeChange { get; }
        decimal ValueOf { get; }

        event Action ExactChangeRequired;

        void Balance(ICoinBox<T> target, decimal amountToTransfer, T cd, T cn);
        void Deposit(T aCoin);
       
        bool Transfer(CoinBox<T> target, decimal amountToTransfer, bool overdrawWhenNecessary = false);
        decimal Withdraw(decimal amountToRemove, bool overdrawWhenNecessary = false);
    }
}