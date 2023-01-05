using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Blocks;
using QuantuMaze.GameObjects.Enemies;
using System.Collections.Generic;

namespace QuantuMaze.Levels
{
    internal class Level1 : Level
    {
        private Player player;
        private Texture2D playerTexture;
        private List<Enemy> enemies;
        private Texture2D strollerTexture;
        private Texture2D jumperTexture;
        public Level1(ContentManager content):base(content)
        {
            playerTexture = content.Load<Texture2D>("Player/Walking/Robot");
            player = new Player(playerTexture);
            strollerTexture = content.Load<Texture2D>("Enemies/Stroller");
            jumperTexture = content.Load<Texture2D>("Enemies/Jumper");
            enemies = new List<Enemy>();
            enemies.Add(new Jumper(jumperTexture, player));
            enemies.Add(new Jumper(jumperTexture, player));
            enemies.Add(new Stroller(strollerTexture, player));
            enemies.Add(new Stroller(strollerTexture, player));
            enemies.Add(new Stroller(strollerTexture, player));
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
        internal override void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            player.Update(gameTime);
        }

        protected override void CreateGrid()
        {
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    Blocks.Add(BlockFactory.CreateBlock(gameboard[l, k], k * 79, l * 80));
                }
            }
        }

        protected override void FillRandomGrid()
        {
            int l;
            int k;
            gameboard = new int[TilesY, TilesX];
            for (l = 0; l < gameboard.GetLength(0); l++)
            {
                for (k = 0; k < gameboard.GetLength(1); k++)
                {
                    gameboard[l, k] = rng.Next(0, 4);
                    if (l == 0)
                    {
                        if (l == TilesY)
                        {
                            gameboard[l, k] = 3;
                        }
                        gameboard[l, k] = rng.Next(2, 4);
                    }
                    if (k == 0)
                    {
                        if (rng.Next(0, 2) == 0)
                        {
                            gameboard[l, k] = 1;
                        }
                        else
                        {
                            gameboard[l, k] = 3;
                        }
                    }
                    if (l == TilesY - 1)
                    {
                        gameboard[l, k] = 2;
                    }
                    if (k == TilesX - 1)
                    {
                        gameboard[l, k] = 1;
                        if (l == TilesY)
                        {
                            gameboard[l, k] = 4;
                        }
                    }
                }
            }

        }

    }
}
