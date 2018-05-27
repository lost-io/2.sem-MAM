﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RpgTowerDefense
{
    class GateBuilder: IBuilder
    {

        private GameObject buildObject;

        public void BuildGameObject(Vector2 position)
        {
            GameObject mainGate = new GameObject();
            mainGate.AddComponent(new Transform(mainGate, position));
            mainGate.AddComponent(new SpriteRenderer(mainGate, "Enemy", 1, 0.5f));
            mainGate.AddComponent(new Animator(mainGate));
            mainGate.AddComponent(new MainGate(mainGate));
            //mainGate.AddComponent(new Collider(mainGate, false, 0.5f));
            buildObject = mainGate;
        }

        public void BuildGameObject(Vector2 position, int id)
        {
            throw new NotImplementedException();
        }

        public GameObject GetResult()
        {
            return buildObject;
        }
    }
}