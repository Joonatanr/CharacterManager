using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    public class PlayerCharacter
    {
        /* This is just for very initial testing. */
        private String _name;
        private int _strength;

        public String CharacterName
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int CharacterStrength
        {
            get
            {
                return _strength;
            }

            set
            {
                _strength = value;
            }
        }

        public PlayerCharacter()
        {
            this._name = "UNKNOWN";
            this._strength = 10;
        }

        public PlayerCharacter(String name)
        {
            this._name = name;
            this._strength = 10;
        }
    }
}
