using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.GameObjects;
using QuantuMaze.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace QuantuMaze.States
{
    internal class GameState : State
    {
        private Player player;
        private Texture2D playerTexture;
        private Enemy enemy;
        private Texture2D enemyTexture;
        private Level1 Level1;
        private Texture2D backgroundTexture;
        public GameState(Game1 game, GraphicsDevice graphics, ContentManager content) : base(game, graphics, content)
        {
            Level1 = new Level1();
            playerTexture = content.Load<Texture2D>("Player/Walking/Robot");
            enemyTexture = new Texture2D(graphics, 1, 1);
            enemyTexture.SetData(new[] { Color.Blue });
            player = new Player(playerTexture);
            enemy = new Jumper(enemyTexture,player);
            backgroundTexture = content.Load<Texture2D>("Background/Game");
            
            //onnodig
            Level1.LoadContent(graphics);
            enemy.LoadContent(graphics);
        }
        public override void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            Level1.Draw(spriteBatch);
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            enemy.Update(gameTime);
            player.Update(gameTime);
        }
    }
}
