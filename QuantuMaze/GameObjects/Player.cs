using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.Movement;

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
        public int Health { get; set; }

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
            spriteBatch.Draw(texture, Position - Hitbox.Offset, movement, Color.White, 0, Vector2.Zero, 1, flipState, 0);
            if (this.Position.Y < 200)
            {
                spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y + 870) - Hitbox.Offset, movement, Color.Purple, 0, Vector2.Zero, 1, flipState, 0);
            }
            spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y - 160) - Hitbox.Offset, movement, Color.Purple, 0, Vector2.Zero, 1, flipState, 0);
        }

        public void Update(GameTime gameTime)
        {
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

        public void TakeDamage()
        {
            Health -= 1;
            Position = Spawn;
        }
    }
}
