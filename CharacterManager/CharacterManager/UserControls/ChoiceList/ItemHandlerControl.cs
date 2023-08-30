using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public class ItemHandleControl<ItemControlType> where ItemControlType : PlayerBaseItem
    {
        public ItemControlType Item;
        public CustomButton InfoBtn;

        private CheckBox _chkBox;

        public delegate void ItemCheckedChangedListener(ItemControlType item, bool isChecked);
        public event ItemCheckedChangedListener ItemCheckedChanged;

        public object[] ItemDescriptionArgs = null;

        public Boolean isChecked 
        { 
            get 
            { 
                if (_chkBox != null) 
                { 
                    return _chkBox.Checked; 
                } 
                else 
                { 
                    return false; 
                } 
            } 
            set 
            {
                if (_chkBox != null)
                {
                    _chkBox.Checked = value;
                }
            } 
        }
        public Boolean isEnabled { get { return _chkBox.Enabled; } set { if (!IsLocked) { _chkBox.Enabled = value; } } }
        public Boolean IsLocked { get { return _isLocked; } set { _isLocked = value; if (_isLocked) { _chkBox.Checked = true; _chkBox.Enabled = false; } } }

        private Boolean _isLocked = false; //If this is true, then this Spell is always chosen as it derives from race or subrace etc...

        private void _chkBox_CheckedChanged(object sender, EventArgs e)
        {
            ItemCheckedChanged?.Invoke(Item, _chkBox.Checked);
        }

        public void setCheckBox(CheckBox box)
        {
            _chkBox = box;
            if (IsLocked)
            {
                _chkBox.Checked = true;
                _chkBox.Enabled = false;
            }
            else
            {
                _chkBox.CheckedChanged += new EventHandler(_chkBox_CheckedChanged);
            }
        }

        public ItemHandleControl(ItemControlType s, CustomButton btn)
        {
            this.Item = s;
            this.InfoBtn = btn;
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.Item.ShowDescription(ItemDescriptionArgs);
        }
    }
}
