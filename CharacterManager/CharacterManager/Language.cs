using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class Language
    {
        public String LanguageName;
        public String TypicalSpeakers;
        public String Script;
        public Boolean IsExotic = false;
    }
}
