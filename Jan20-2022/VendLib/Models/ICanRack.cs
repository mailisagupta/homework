using System.Collections.Generic;

namespace VendLib
{
    public interface ICanRack
    {
        int this[Flavor flavorOfBin] { get; }

        bool IsFull { get; }

        void AddACanOf(Can can);
        List<Can> EmptyCanRackOf(Flavor flavorOfBinToBeEmptied);
        void FillTheCanRack();
        bool HasACanOf(Flavor flavorOfBinToBeChecked);
        bool HasNoCansOf(Flavor flavorOfBinToBeChecked);
        bool HasSpaceForACanOf(Flavor flavorOfBinToBeChecked);
        bool IsFullOfCansOf(Flavor flavorOfBinToBeChecked);
        Can RemoveACanOf(Flavor flavorOfBinToBeRemoved);
    }
}