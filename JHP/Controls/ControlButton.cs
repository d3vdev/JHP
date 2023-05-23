using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHP.Controls
{
    public class ControlButton: Button
    {
        public ControlButton() {
            SetStyle(ControlStyles.Selectable, false);
        } 
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
