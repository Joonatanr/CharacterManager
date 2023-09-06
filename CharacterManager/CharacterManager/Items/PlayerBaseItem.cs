using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CharacterManager.Items
{
    
    /* Idea is that this should be the topmost class of any spell, maneuver, even weapon, armor, and other item. 
     Basically it just contains  a displayed name and a Description */

    public abstract class PlayerBaseItem : ICloneable
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }

        [XmlIgnore]
        public virtual string DisplayedName
        {
            get
            {
                return Name;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void ShowDescription(object [] args)
        {
            MessageBox.Show(Name + Environment.NewLine + Environment.NewLine + Description);
        }
    }
}
