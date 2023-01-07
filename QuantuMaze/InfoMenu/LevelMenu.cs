using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Animate;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects;
using QuantuMaze.InfoMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantuMaze.Levels
{
    internal class LevelMenu:BottomMenu,IPlayerInfo
    {
        private Rectangle healthBar;
        private Rectangle collectionBar;
        private Animation health;
        private Animation collection;
        public int GameClear { get; set; }
        public Vector2 Position { get; set; }
        public Hitbox Hitbox { get; set; }
        public int CurrentHealth { get; set; }
        public int NrCollected { get; set; }
        public int OrbTotal { get; set; }

        public LevelMenu(Texture2D texture, SpriteFont font, IPlayerInfo player, int orbs):base(texture,font)
        {
            CurrentHealth = player.CurrentHealth;
            Hitbox = player.Hitbox;
            NrCollected = player.NrCollected;
            OrbTotal=orbs;
            healthBar = new Rectangle(50, 1050, 400, 20);
            collectionBar = new Rectangle(600,1050,400,20);
            health = new Animation();
            collection = new Animation();
            health.AddFrame(new AnimationFrame(new Rectangle(2,2,2,2)));
            collection.AddFrame(new AnimationFrame(new Rectangle(2,2,2,2)));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, menu, Color.Black);
            spriteBatch.Draw(texture, healthBar, Color.Red);
            spriteBatch.Draw(texture, collectionBar, Color.Blue);
            spriteBatch.DrawString(font, "HP:", new Vector2(15, 1050),Color.Red);
            spriteBatch.DrawString(font, "Orbs:", new Vector2(560, 1050), Color.Blue);
            spriteBatch.Draw(texture, new Rectangle(50, 1052, CurrentHealth * 80, 16), health.CurrentFrame.SourceRectangle, Color.Red);
            spriteBatch.Draw(texture, new Rectangle(600, 1052, NrCollected * 400/OrbTotal, 16), collection.CurrentFrame.SourceRectangle, Color.Blue);
            spriteBatch.DrawString(font,"Use left and right arrow keys to move. Press space to teleport. Collect orbs to advance.",new Vector2(1100,1050),Color.Purple);
        }

        public void Update(GameTime gameTime,IPlayerInfo player)
        {
            CurrentHealth=player.CurrentHealth;
            NrCollected = player.NrCollected;
        }

    }
}
