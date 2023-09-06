using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager.Items
{
    [XmlRoot("PlayerItem")]
    [Serializable]
    public class ItemContainer : Items.PlayerItem
    {
        [Serializable]
   
        public class ContainerContent
        {
            public String Name;
            public String Description;
            public int Quantity = 1;

            public override string ToString()
            {
                String res = Name;
                if(Quantity > 1)
                {
                    res += "(" + Quantity.ToString() + ")";
                }
                return res;
            }
        }

        public List<ContainerContent> ContainedItems = new List<ContainerContent>();

        public List<PlayerItem> getContainedItems()
        {
            List<PlayerItem> res = new List<PlayerItem>();

            foreach(ContainerContent content in ContainedItems)
            {
                /* We try to resolve each reference. */
                PlayerItem item = CharacterFactory.getPlayerItemByName(content.Name);
                if (item != null)
                {
                    item.Quantity = content.Quantity;
                    res.Add(item);
                }
                else
                {
                    //Lets allow custom items here, some items are really too basic (such as a piece of string etc..) to have a corresponding XML variable.
                    PlayerItem custom = new PlayerItem();
                    custom.Name = content.Name;
                    custom.Quantity = content.Quantity;
                    if (content.Description == null)
                    {
                        custom.Description = "N/A";
                    }
                    else
                    {
                        custom.Description = content.Description;
                    }
                    res.Add(custom);
                }
            }

            return res;
        }

    }
}
