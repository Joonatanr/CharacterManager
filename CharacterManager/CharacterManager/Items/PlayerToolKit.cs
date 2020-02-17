using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    [Serializable]
    public class PlayerToolKit : PlayerItem
    {
        public enum PlayerToolType
        {
            TYPE_GENERIC,
            TYPE_ARTISAN,
            TYPE_GAMING,
            TYPE_MUSICAL,
        }

        public PlayerToolType ToolType = PlayerToolType.TYPE_GENERIC;
    }
}
