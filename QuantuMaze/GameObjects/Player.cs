using Microsoft.Xna.Framework;
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

namespace QuantuMaze.GameObjects
{
    internal class Player:IGameObject,IMovable
    {
        private Hitbox hitbox;
        private Hitbox boundBox;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed;
        private bool isEnemy = false;
        private Animation animation;

        public Vector2 Position { get => position; set => value = position; }
        public Vector2 Speed { get => speed; set => value = speed; }
        public bool IsEnemy { get => isEnemy; set => value=isEnemy; }

        public Player(Texture2D texture)
        {
            this.texture = texture;
            this.position = new Vector2(10, 10);
            this.speed = new Vector2(2, 2);
            this.hitbox = new Hitbox(20, 20,Color.Red,Position,Speed); 
            this.boundBox = new Hitbox(30, 30,Color.White,Position,Speed);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(13, 206, 41, 50)));
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            this.boundBox.LoadContent(graphics);
            this.hitbox.LoadContent(graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boundBox.Draw(spriteBatch,position);
            hitbox.Draw(spriteBatch,position);
            spriteBatch.Draw(texture, position,animation.CurrentFrame.SourceRectangle ,Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);

        }
        public void Move()
        {
            this.position+=this.speed;
        }
    }
}
