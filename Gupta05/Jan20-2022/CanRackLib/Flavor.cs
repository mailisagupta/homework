using System;
using System.Collections.Generic;
using System.Linq;

namespace CanRackLib
{
    public enum Flavor { CocaCola, Dew, Gingerale }
    public static class FlavorOps
    {
        public static IEnumerable<Flavor> AllFlavors => Enum.GetValues(typeof(Flavor)).Cast<Flavor>();
        
        public static Flavor ConvertStringToFlavor(string flavorName)
        {
            Flavor result;
            if (Enum.IsDefined(typeof(Flavor), flavorName) && Enum.TryParse<Flavor>(flavorName, out result))
                return result;
            else
            {
                throw new ArgumentException($"{flavorName} cannot be converted into a value of type Flavor");
            }
        }
    }

}