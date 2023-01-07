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
        //voor Collected, als deze nog niet is verzameld heeft deze waarde 0
        //als deze wordt verzameld is de waarde 1
        //zodra geregistreerd is bij de speler dat deze is verzameld wordt de waarde -1
        //zo zal deze niet elke keer worden opgeteld vergeleken met een boolean


        public Collectible()
        {
            Hitbox = new Hitbox(new Vector2(Position.X + 15, Position.Y + 15), 50, 50);
            Hitbox.Collidable = true;
            Hitbox.Passable = true;
            CollisionManager.AddCollectible(this);
            Collected = 0;
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
