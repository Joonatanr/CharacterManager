using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.SpecialAttributes
{
    //This is basically a special attribute that affects gameplay.
    //In this case the attribute is too complex to describe via XML and requires method descriptions.

    public abstract class SpecialAttribute : PlayerAbility
    {
        /* TODO : This really isn't a particularly good solution. Maybe a better one can be found? */
        public void CopyValuesFromBaseClass(PlayerAbility baseObj)
        { 

            var sourceProps = typeof(PlayerAbility).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(SpecialAttribute).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    {   // check if the property can be set or no.
                        p.SetValue(this, sourceProp.GetValue(baseObj, null), null);
                    }
                }

            }
        }
    }
}
