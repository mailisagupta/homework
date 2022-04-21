using System.Collections.Generic;

namespace CanRackLib
{
    public class CanRack
    {
        private Dictionary<Flavor, Queue<Can>> _rack;

        public CanRack()
        {
            _rack = new Dictionary<Flavor, Queue<Can>>();
            FillTheCanRack();
        }
        public const int EmptyBin = 0;
        public const int BinCapacity = 3;
        public int this[Flavor flavorOfBin]
            => _rack[flavorOfBin].Count;
        public void AddACanOf(Flavor flavorOfBinToBeAdded)
        {
            if (HasSpaceForACanOf(flavorOfBinToBeAdded))
                _rack[flavorOfBinToBeAdded].Enqueue(new Can(flavorOfBinToBeAdded));
        }
        public Can RemoveACanOf(Flavor flavorOfBinToBeRemoved)
        {
            Can result = null;
            if (HasACanOf(flavorOfBinToBeRemoved))
            {
                result = _rack[flavorOfBinToBeRemoved].Dequeue();
            }
            return result;
        }
        public bool IsFull
        {
            get
            {
                bool result = true;
                foreach (Flavor f in FlavorOps.AllFlavors)
                {
                    result &= IsFullOfCansOf(f);
                }
                return result;
            }
        }
        public void FillTheCanRack()
        {
            foreach (Flavor flavor in FlavorOps.AllFlavors)
            {
                if (!_rack.ContainsKey(flavor)) 
                    _rack.Add(flavor, new Queue<Can>());
                while (HasSpaceForACanOf(flavor))
                {
                    AddACanOf(flavor);
                }
            }
        }

        // EmptyCanRackOf returns a List<Can> representing the cans
        // removed from the can rack as a result of the call
        public List<Can> EmptyCanRackOf(Flavor flavorOfBinToBeEmptied)
        {
            List<Can> result = new List<Can>();
            while (HasACanOf(flavorOfBinToBeEmptied))
            {
                result.Add(RemoveACanOf(flavorOfBinToBeEmptied));
            }
            return result;
        }
        public bool HasNoCansOf(Flavor flavorOfBinToBeChecked)
            => _rack[flavorOfBinToBeChecked].Count == EmptyBin;
        public bool HasSpaceForACanOf(Flavor flavorOfBinToBeChecked)
            => _rack[flavorOfBinToBeChecked].Count < BinCapacity;
        public bool IsFullOfCansOf(Flavor flavorOfBinToBeChecked)
            => _rack[flavorOfBinToBeChecked].Count == BinCapacity;

        public bool HasACanOf(Flavor flavorOfBinToBeChecked)
            => _rack[flavorOfBinToBeChecked].Count > EmptyBin;
    }
}
