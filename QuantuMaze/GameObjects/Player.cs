﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using QuantuMaze.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantuMaze.Movement;
using QuantuMaze.Animate;
using QuantuMaze.Input;

namespace QuantuMaze.GameObjects
{
    internal class Player : IMovable
    {
        private Texture2D texture;
        private Animation animation;
        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Hitbox Hitbox { get; set; }

        public Player(Texture2D texture)
        {
            this.texture = texture;
            Position = new Vector2(20, 10);
            this.Speed = new Vector2(3, 0);
            Hitbox = new Hitbox(Position,20, 20,Color.Red); 
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle((int)Position.X,(int)Position.Y, 18, 18)));
            movementManager = new MovementManager();
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            Hitbox.LoadContent(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hitbox.Draw(spriteBatch,Position);
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.Yellow);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Move()
        {
            movementManager.Move(this,Position);
            
        }
    }
}
