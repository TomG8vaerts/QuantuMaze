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
using QuantuMaze.Input;
using Microsoft.Xna.Framework.Content;

namespace QuantuMaze.GameObjects
{
    internal class Player : IMovable,IPlayerInfo
    {
        private Texture2D texture;
        private Animation animation;
        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool Jumped { get; set; }
        public int Health { get; set; }

        public Player(Texture2D texture)
        {
            this.texture = texture;
            Hitbox = new Hitbox(Position,23, 32,6);
            Position = new Vector2(10, 990);
            Speed = new Vector2(3, 0);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0,0,32,32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 32, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 32, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 32, 32, 32)));
            movementManager = new MovementManager();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position-Hitbox.Offset, animation.CurrentFrame.SourceRectangle, Color.Yellow);
            if (this.Position.Y<200)
            {
                spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y +870) - Hitbox.Offset, animation.CurrentFrame.SourceRectangle, Color.Purple);
            }
            spriteBatch.Draw(texture,new Vector2(Position.X,Position.Y-160) - Hitbox.Offset, animation.CurrentFrame.SourceRectangle, Color.Purple);
        }
        public void Update(GameTime gameTime)
        {
            Hitbox.Update(Position);
            animation.Update(gameTime);
            Move();
        }
        public void Move()
        {
            movementManager.Move(this,Position);
        }

        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.PlayerBehavior(move,nextPos, lastPos);
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
