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
        public bool Passable { get; set; }
        public bool Collected { get; set; }


        public Collectible()
        {
            Hitbox = new Hitbox(new Vector2(Position.X + 15, Position.Y + 15), 50, 50);
            Hitbox.Collidable = true;
            Passable = true;
            Collected = false;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(65, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(129, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(193, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(257, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(327, 0, 64, 64)));
            animation.AddFrame(new AnimationFrame(new Rectangle(390, 0, 64, 64)));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Collected)
                spriteBatch.Draw(Texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
            else spriteBatch.Draw(Texture, Position, Color.Transparent);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Collected)
                animation.Update(gameTime);

        }

    }
}
