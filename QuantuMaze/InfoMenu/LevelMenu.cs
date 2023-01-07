using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Levels
{
    internal class LevelMenu:IPlayerInfo
    {
        private Rectangle menu;
        private Rectangle healthBar;
        private Rectangle collectionBar;
        private Texture2D texture;
        private Animation health;
        private Animation collection;
        public int GameClear { get; set; }
        public Vector2 Position { get; set; }
        public Hitbox Hitbox { get; set; }
        public int CurrentHealth { get; set; }
        public int NrCollected { get; set; }

        public LevelMenu(Texture2D texture, IPlayerInfo player)
        {
            this.texture = texture;
            CurrentHealth = player.CurrentHealth;
            Position = player.Position;
            Hitbox = player.Hitbox;
            NrCollected = player.NrCollected;
            menu = new Rectangle(0, 1040, 1920, 50);
            healthBar = new Rectangle(30, 1050, 400, 20);
            collectionBar = new Rectangle(600,1050,400,20);
            health = new Animation();
            collection = new Animation();
            health.AddFrame(new AnimationFrame(new Rectangle(2,2,2,2)));
            collection.AddFrame(new AnimationFrame(new Rectangle(2,2,2,2)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, menu, Color.Black);
            spriteBatch.Draw(texture, healthBar, Color.Red);
            spriteBatch.Draw(texture, collectionBar, Color.Blue);
            spriteBatch.Draw(texture, new Rectangle(30, 1052, CurrentHealth * 80, 16), health.CurrentFrame.SourceRectangle, Color.Red);
            spriteBatch.Draw(texture, new Rectangle(600, 1052, NrCollected * 50, 16), collection.CurrentFrame.SourceRectangle, Color.Blue);
        }

        public void Update(GameTime gameTime,IPlayerInfo player)
        {
            CurrentHealth=player.CurrentHealth;
            NrCollected = player.NrCollected;
            health.Update(gameTime);
            collection.Update(gameTime);
            
        }

    }
}
