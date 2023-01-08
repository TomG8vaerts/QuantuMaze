﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using QuantuMaze.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.GameObjects;

namespace QuantuMaze.Levels
{
    internal class LevelManager:LevelContent
    {
        private Level currentLevel;
        private Level nextLevel;
        public int GameClear { get; set; }=0;
        public LevelManager(ContentManager content):base(content)
        {
            currentLevel = new Level1(content);
        }
        public void Update(GameTime gameTime)
        {
            if (nextLevel != null)
            {
                currentLevel = nextLevel;
                nextLevel = null;
            }
            currentLevel.Update(gameTime);
            if (currentLevel.GameClear == 1)
                if (currentLevel is Level1)
                    ChangeLevel(new Level2(content));
                else this.GameClear = 1;
            if(currentLevel.GameClear == -1) GameClear = -1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
        }
        public void ChangeLevel(Level level)
        {
            currentLevel = level;
        }
    }
}
