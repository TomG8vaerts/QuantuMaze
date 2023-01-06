using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.GameObjects.Enemies
{
    internal abstract class Enemy : IMovable
    {
        private Texture2D texture;
        protected Animation animation;
        private MovementManager movementManager;

        public Enemy(Texture2D texture,Player player)
        {
            this.texture = texture;
            Speed = new Vector2(1, 0);
            Hitbox = new Hitbox(Position, 28, 40);
            CollisionManager.AddEnemyHitbox(Hitbox);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 38, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 39, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(44, 39, 14, 20)));
            animation.AddFrame(new AnimationFrame(new Rectangle(23, 39, 14, 20)));


            movementManager = new MovementManager();
            Player=player;
        }

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool Jumped { get; set; }
        public IPlayerInfo Player { get; set; }
        public bool IsFacingLeft { get; set; }
        public bool IsMoving { get; set; } = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsFacingLeft)
            {
                if(IsMoving) spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, 28, 40), animation.CurrentFrame.SourceRectangle, Color.White,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
                else spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, 28, 40), animation.FindFrame(1).SourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                if (IsMoving) spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, 28, 40), animation.CurrentFrame.SourceRectangle, Color.White);
                else spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, 28, 40), animation.FindFrame(1).SourceRectangle, Color.White);
            }
            
        }
        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Move()
        {
            movementManager.Move(this, Position);
        }

        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.EnemyBehavior(move, nextPos, lastPos,Player);

        }
    }
}
