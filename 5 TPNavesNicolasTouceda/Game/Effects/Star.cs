﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Engine;

using Engine.Extensions;
using System.IO.Compression;

namespace Game
{
    public class Star : GameObject
    {
        private Image img;
        float speed;
        int size;
        public Star(Image img, float speed)
        {
            size = (0.16 * speed).FloorToInt().Max(1);
            this.img = new Bitmap(img, new Size(size, size));
            this.speed = speed;

            Extent = this.img.Size;
            Visible = false;
        }

        public override void UpdateStar(float deltaTime)
        {
            if (Position.X <= 0 || Position.Y <= 0)//Si mi posicion esta fuera del mundo (0)
            {
                saliDeEscena = true;
                return;
            }
            X -= speed * deltaTime;
            Visible = true;
        }



        public override void DrawOn(Graphics graphics)
        {
            graphics.DrawImage(img, Position);
        }
    }
}
