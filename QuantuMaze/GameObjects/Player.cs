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
        public bool Jumped { get; set; }

        public Player(Texture2D texture)
        {
            this.texture = texture;
            Position = new Vector2(10, 1010);
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
            if (this.Position.Y<120)
            {
                spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y +1000), animation.CurrentFrame.SourceRectangle, Color.Purple);
            }
            spriteBatch.Draw(texture,new Vector2(Position.X,Position.Y-80),animation.CurrentFrame.SourceRectangle, Color.Purple);
        }
        public void Update(GameTime gameTime)
        {
            Move();
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Update(GameTime gameTime,Player player)
        {
            Move(player);
            animation.Update(gameTime);
            Hitbox.Update(Position);
        }
        public void Move(Player player=null)
        {
            movementManager.Move(this,Position);
        }

        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.PlayerBehavior(move,nextPos, lastPos);
        }
    }
}
