﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Engine.Utils
{
    public class Spritesheet
    {
        public static Image[] Load(string fileName, Size size)//Devuelve un array de imagenes con sus nombres
        {
            return new Spritesheet(fileName).CutPieces(size);
        }

        public static Image[] Load(Image original, Size size)
        {
            return new Spritesheet(original).CutPieces(size);
        }

        private Image original;
        
        public Spritesheet(string fileName) : this(Image.FromFile(fileName)) {}

        public Spritesheet(Image original)
        {
            this.original = original;
        }




        private bool LasPiesasYaFueronRecortadas = false;
        private List<Image> pieces = new List<Image>();

        public Image[] CutPieces(Size size)//crea bitmaps con las imagenes y las devuelve
        {
            if (LasPiesasYaFueronRecortadas == true) 
            {
                return pieces.ToArray();
            }

            int rows = original.Width / size.Width;
            int cols = original.Height / size.Height;
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    Image temp = new Bitmap(size.Width, size.Height);
                    Graphics graphics = Graphics.FromImage(temp);
                    graphics.DrawImage(original,
                        new Rectangle(0, 0, size.Width, size.Height),
                        new Rectangle(i * size.Width, j * size.Height, size.Width, size.Height),
                        GraphicsUnit.Pixel);
                    //graphics.Dispose();
                    pieces.Add(temp);
                }
            }
            LasPiesasYaFueronRecortadas = true;
            return pieces.ToArray();
        }
    }
}
