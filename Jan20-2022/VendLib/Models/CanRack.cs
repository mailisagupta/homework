using System.Collections.Generic;

namespace VendLib
{
    public class CanRack : ICanRack
    {
        private Dictionary<Flavor, Queue<Can>> _rack;
        private IEnumerable<Can> _cans;
        public CanRack(IEnumerable<Can> cans)
        {
            _cans =cans;
            _rack = new Dictionary<Flavor, Queue<Can>>();
            foreach (Flavor f in FlavorOps.AllFlavors)

            {

                _rack.Add(f, new Queue<Can>());

            }
            FillTheCanRack();
        }
        public const int EmptyBin = 0;
        public const int BinCapacity = 3;
        public int this[Flavor flavorOfBin]
            => _rack[flavorOfBin].Count;
        public void AddACanOf(Can can)
        {
            if (HasSpaceForACanOf(can.contents))
                _rack[can.contents].Enqueue(can);
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
            //foreach (Flavor flavor in FlavorOps.AllFlavors)
            //{
            //    if (!_rack.ContainsKey(flavor))
            //        _rack.Add(flavor, new Queue<Can>());
            //    while (HasSpaceForACanOf(flavor))
            //    {
            //        AddACanOf(flavor);
            //    }
            //}


            foreach (var b in _cans)
            {
                if (IsFull) break;
                AddACanOf(b);
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
