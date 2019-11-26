using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    [Serializable]
    public class ItemContainer : Items.PlayerItem
    {
        [Serializable]
        public class ContainerContent
        {
            public String Name;
            public int Quantity = 1;
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
                    custom.ItemName = content.Name;
                    custom.Quantity = content.Quantity;
                    custom.Description = "N/A";
                    res.Add(custom);
                }
            }

            return res;
        }

    }
}
