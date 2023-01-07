using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.Movement;
using System;

namespace QuantuMaze.GameObjects
{
    internal class Player : IMovable, IPlayerInfo
    {
        private Texture2D texture;
        private Animation animation;
        private Animation still;
        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Spawn { get; set; }
        public Vector2 Speed { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool Jumped { get; set; }
        public bool IsFacingLeft { get; set; }
        public bool IsMoving { get; set; } = true;
        public int CurrentHealth { get; set; }
        public int Health { get; set; }
        public float Invincibility { get; set; } = .5f;
        public Color PlayerColor { get; set; }
        public int NrCollected { get; set; }

        public Player(Texture2D texture)
        {
            this.texture = texture;
            Position = Spawn = new Vector2(10, 990);
            Hitbox = new Hitbox(Position, 23, 32, 6);
            Speed = new Vector2(3, 0);
            Health = 5;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 32, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 32, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 32, 32, 32)));
            still = new Animation();
            still.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            movementManager = new MovementManager();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle movement = still.CurrentFrame.SourceRectangle;
            var flipState = SpriteEffects.None;
            if (IsMoving) movement = animation.CurrentFrame.SourceRectangle;
            if (IsFacingLeft) flipState = SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, Position - Hitbox.Offset, movement, PlayerColor, 0, Vector2.Zero, 1, flipState, 0);
            if (this.Position.Y < 200)
            {
                spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y + 860) - Hitbox.Offset, movement, Color.Purple, 0, Vector2.Zero, 1, flipState, 0);
            }
            spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y - 180) - Hitbox.Offset, movement, Color.Purple, 0, Vector2.Zero, 1, flipState, 0);
        }

        public void Update(GameTime gameTime)
        {
            TakeDamage(gameTime);
            FlickerPlayer();
            Move();
            Hitbox.Update(Position);
            animation.Update(gameTime);
        }


        public void Move()
        {
            movementManager.Move(this, Position);
        }

        public void CollisionBehavior(IMovable move, Vector2 nextPos, Vector2 lastPos)
        {
            CollisionManager.PlayerBehavior(move, nextPos, lastPos);
        }

        public void TakeDamage(GameTime gameTime)
        {
            Invincibility -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Invincibility <= 0 && CurrentHealth < Health)
            {
                Health--;
                Invincibility = 3f;
                Position = Spawn;
            }
            CurrentHealth = Health;
        }
        private void FlickerPlayer()
        {
            float i= Invincibility*10;
            if (i%10<5)PlayerColor=Color.White;
            else PlayerColor=Color.Red;
        }
    }
}
