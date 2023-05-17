namespace JHP.Api
{
    public class ReSize
    {

        private bool Above, Right, Under, Left, Right_above, Right_under, Left_under, Left_above;
        private int Thickness = 5;  //Thickness of border  u can cheang it
        private int Area = 5;     //Thickness of Angle border 


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thickness">set thickness of form border</param>
        public ReSize(int thickness)
        {
            Thickness = thickness;
            Area = thickness;
        }

        public void setThick(int thickness)
        {
            Thickness = thickness;
            Area = thickness;
        }

        /// <summary>
        /// Constructor set thickness of form border=1
        /// </summary>
        public ReSize()
        {
            Thickness = 2;
        }

   
        //Get Mouse Position
        public string GetMosuePosition(Point mouse, Form form)
        {
            if (form.WindowState == FormWindowState.Maximized) return "";
            bool above_underArea = mouse.X > Area && mouse.X < form.ClientSize.Width - Area; /* |\AngleArea(Left_Above)\(=======above_underArea========)/AngleArea(Right_Above)/| */ //Area===>(==)
            bool right_left_Area = mouse.Y > Area && mouse.Y < form.ClientSize.Height - Area;

            bool _Above = mouse.Y <= Thickness;  //Mouse in Above All Area
            bool _Right = mouse.X >= form.ClientSize.Width - Thickness;
            bool _Under = mouse.Y >= form.ClientSize.Height - Thickness;
            bool _Left = mouse.X <= Thickness;

            Above = _Above && (above_underArea); if (Above) return "a";   /*Mouse in Above All Area WithOut Angle Area */
            Right = _Right && (right_left_Area); if (Right) return "r";
            Under = _Under && (above_underArea); if (Under) return "u";
            Left = _Left && (right_left_Area); if (Left) return "l";


            Right_above =/*Right*/ (_Right && (!right_left_Area)) && /*Above*/ (_Above && (!above_underArea)); if (Right_above) return "ra";     /*if Mouse  Right_above */
            Right_under =/* Right*/((_Right) && (!right_left_Area)) && /*Under*/(_Under && (!above_underArea)); if (Right_under) return "ru";     //if Mouse  Right_under 
            Left_under = /*Left*/((_Left) && (!right_left_Area)) && /*Under*/ (_Under && (!above_underArea)); if (Left_under) return "lu";      //if Mouse  Left_under
            Left_above = /*Left*/((_Left) && (!right_left_Area)) && /*Above*/(_Above && (!above_underArea)); if (Left_above) return "la";      //if Mouse  Left_above

            return "";

        }


    }

}

