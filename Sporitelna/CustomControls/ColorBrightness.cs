﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlsTest1.CustomControls
{
    public class ColorBrightness
    {
        public static Color ChangeColorBrightness(Color color, float correctionFactor) //set darkMode to -1 to darker
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;


            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }
}
