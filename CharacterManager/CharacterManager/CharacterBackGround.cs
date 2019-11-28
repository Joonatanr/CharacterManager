using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class CharacterBackGround
    {

        [Serializable]
        public class BackGroundFeature
        {
            public String Name;
            public String Description;
        }

        public String BackGroundName;
        public String Description;
        public List<String> SkillProficiencies = new List<String>();
        public List<String> ToolProficiencies = new List<String>();
        public int CustomLanguages = 0;
        public List<Items.ItemContainer.ContainerContent> Equipment = new List<Items.ItemContainer.ContainerContent>();
        public int Gold = 0;
        public List<BackGroundFeature> Features = new List<BackGroundFeature>();

        public CharacterBackGround()
        {
            
        }
    }
}
