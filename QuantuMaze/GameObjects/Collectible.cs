using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;

namespace QuantuMaze.GameObjects
{
    internal class Collectible : Component, IGameObject
    {
        private Animation animation;
        public Texture2D Texture { get; set; }
        public Hitbox Hitbox { get; set; }
        public Vector2 Position { get; set; }
        public int Collected { get; set; }


        public Collectible()
        {
            Hitbox = new Hitbox(new Vector2(Position.X + 15, Position.Y + 15), 50, 50);
            Hitbox.Collidable = true;
            Hitbox.Passable = true;
            CollisionManager.AddCollectible(this);
            Collected = 0;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(65, 0, 65, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(132, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(196, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(260, 0, 65, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(329, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(393, 0, 63, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(456, 0, 64, 64)));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Collected==0)
                spriteBatch.Draw(Texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
            else spriteBatch.Draw(Texture, Position, Color.Transparent);
        }

        public override void Update(GameTime gameTime)
        {
            if (Collected==0)
            {
                animation.Update(gameTime);
                Hitbox.Update(Position);
            }
        }

    }
}
