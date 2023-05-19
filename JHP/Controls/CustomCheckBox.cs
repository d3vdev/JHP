using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHP.Controls
{
    public class CustomCheckBox: CheckBox
    {
        

        public CustomCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        Font font = new Font("Segoe MDL2 Assets", 16);
        Font tfont = new Font("맑은 고딕", 11);
        Brush color = new SolidBrush(Color.FromArgb(unchecked((int)0xFF303030)));
        Brush bg= new SolidBrush(Color.White);

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(bg, new Rectangle(0,0,Size.Width, Size.Height));
            
            if (this.Checked)
            {
                pevent.Graphics.DrawString("\uE73D", font, color, new Point(0, 2));
            }
            else
            {
                pevent.Graphics.DrawString("\uE739", font, color, new Point(0, 2));
            }
            pevent.Graphics.DrawString(Text, tfont, color, new Point(30, 2));
        }
    }
}
