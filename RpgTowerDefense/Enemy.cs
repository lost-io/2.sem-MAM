﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Threading;

namespace RpgTowerDefense
{
    class Enemy : Component, ILoadable, IAnimateable, IUpdate
    {
        #region Fields
        private Vector2 destination;

        private float speed;
        private Animator animator;
        private IStrategy strategy;
        private DIRECTION direction;
        bool threadStarted = false;
        #endregion
        #region Constructor
        public Enemy(GameObject gameobject) : base(gameobject)
        {
            speed = 50;
            animator = (gameobject.GetComponent("Animator")as Animator);
            destination = GameWorld._Instance.walkCoordinates[0];
        }
        #endregion
        #region Methods
        public void LoadContent(ContentManager Content)
        {
            CreateAnimation();
        }
        public void CreateAnimation()
        {
            animator.CreateAnimation("IdleFront", new Animation(1, 0, 0, 100, 100, 0, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(1, 0, 1, 100, 100, 0, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(1, 0, 2, 100, 100, 0, Vector2.Zero));
            animator.CreateAnimation("IdleBack", new Animation(1, 0, 3, 100, 100, 0, Vector2.Zero));
            animator.CreateAnimation("WalkFront", new Animation(4, 100, 0, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("WalkBack", new Animation(4, 100, 4, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("WalkLeft", new Animation(4, 200, 0, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(4, 200, 4, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("DieBack", new Animation(4, 300, 0, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("DieFront", new Animation(4, 300, 4, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("DieLeft", new Animation(4, 400, 0, 100, 100, 5, Vector2.Zero));
            animator.CreateAnimation("DieRight", new Animation(4, 400, 4, 100, 100, 5, Vector2.Zero));
            animator.PlayAnimation("IdleFront");
        }

        public void OnAnimationDone(string animationName)
        {
           
        }

        public void Update()
        {
            if (strategy is Walk)
            {

            }
            if (strategy is Idle)
            {

            }
            if (strategy is Attack)
            {

            }
            if (threadStarted == false)
            {
                Thread enemyMovementThread = new Thread(EnemyMovement);
                enemyMovementThread.Start();
                threadStarted = true;
                
            }
            
        }
        public void EnemyMovement()
        {
            while (true)
            {
                Vector2 tempVector = new Vector2(destination.X - gameObject.Transform.Position.X, destination.Y - gameObject.Transform.Position.Y);
                gameObject.Transform.Translate(Vector2.Normalize(tempVector));
            }
           
        }
        public Vector2 Destination(Vector2 location)
        {
            destination = location;
            return destination;
        }
        #endregion
    }
}