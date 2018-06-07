﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgTowerDefense
{
    class Camera
    {
        /// <summary>
        /// The Camera class locks to a specified target(Gameobject) and allows us to transform the render area, using the offset.
        /// </summary>
        private Matrix transform;
        private Matrix offset;
        private int screenvalue;
        public Matrix Transform { get { return transform; } private set { transform = value; } }

        public Matrix Offset { get => offset; set => offset = value; }
        public int Screenvalue { get => screenvalue; set => screenvalue = value; }


        /// <summary>
        /// Calculate Transform using target parameters.
        /// </summary>
        /// <param name="targetPosition"></param>
        public void Follow(Vector2 targetPosition)
        {

            
            var position = Matrix.CreateTranslation(
                -targetPosition.X,
                -targetPosition.Y,
                0);

            var offset = Matrix.CreateTranslation(0, 0, 0);
            if (screenvalue == 1)
            {
                position = Matrix.CreateTranslation(0, 0, 0);
            }
            else if (screenvalue == 2)
            {
                position = Matrix.CreateTranslation(-GameWorld._Instance.ScreenWidth, 0, 0);
                
            }
            else
            {
                position = Matrix.CreateTranslation(-GameWorld._Instance.ScreenWidth * 2, 0, 0);
            }
            Transform = position * offset;

        }
       public void GetMousePosition()
        {
           //Mouse.WindowHandle = this.transform.
        }
    }
}

