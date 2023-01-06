﻿using Microsoft.Xna.Framework;
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
    internal class GameState:State
    {
        private LevelManager levelManager;
        private Texture2D backgroundTexture;
        public Game1 Game1 { get; set; }
        public GraphicsDevice Graphics { get; set; }
        public ContentManager Content { get; set; }
        public bool GameOver { get; set; }
        public GameState(Game1 game, GraphicsDevice graphics, ContentManager content)
        {
            backgroundTexture = content.Load<Texture2D>("BackGround/Game");
            levelManager = new LevelManager(content);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            levelManager.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void QuitGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void StartGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            levelManager.Update(gameTime);
        }

    }
}
