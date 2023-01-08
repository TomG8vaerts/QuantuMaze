using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects.Blocks;
using Microsoft.Xna.Framework.Media;

namespace QuantuMaze.Levels
{
    internal class Level2 : Level
    {
        public Level2(ContentManager content) : base(content)
        {
            CollisionManager.ClearAll();
            OrbTotal = 10;
            menu = new LevelMenu(rectangleTexture, spriteFont, player,OrbTotal);
            enemyBoard = new Enemy[,]
            {
                {null,null,new Stroller(strollerTexture,player),null,null,null,null,null,null,null,new Stroller(strollerTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,new Stroller(strollerTexture,player) },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Jumper(jumperTexture,player),null,null },
                {new Stroller(strollerTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Stroller(strollerTexture,player),null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,new Stroller(strollerTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Jumper(jumperTexture,player),null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Jumper(jumperTexture,player),null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,new Jumper(jumperTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Stroller(strollerTexture,player),null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,new Jumper(jumperTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,new Jumper(jumperTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Jumper(jumperTexture,player),null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,new Chaser(chaserTexture,player),null,null,null,null,null,null,new Stroller(strollerTexture,player),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            };
            orbBoard = new Collectible[,]
            {
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null,null,null,null,null,null },
                {null,null,null,new Collectible(),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null },
                {null,null,null,null,null,null,null,new Collectible(),null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,new Collectible(),null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,new Collectible(),null,null,null,null,null,null,null,null,null,new Collectible(),null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
                {null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null },
            };
            FillGrid();
            CreateGrid();
            LoadContent();
        }

        protected override void CreateGrid()
        {
            int i = 0;
            int j = 0;
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    Blocks.Add(BlockFactory.CreateBlock(gameboard[l, k], k * 79, l * 80));
                    if (l < enemyBoard.GetLength(0) && k < enemyBoard.GetLength(1))
                    {
                        if (enemyBoard[l, k] is not null)
                        {
                            Enemies.Add(enemyBoard[l, k]);
                            Enemies[i].Position = new Vector2((k * 79) + 20, (l * 80) + 20);
                            Enemies[i].Hitbox.Offset = new Vector2(20, 20);
                            i++;
                        }
                        if (orbBoard[l, k] is not null)
                        {
                            Collectibles.Add(orbBoard[l, k]);
                            Collectibles[j].Position = new Vector2((k * 79) + 15, (l * 80) + 15);
                            Collectibles[j].Hitbox.Offset = new Vector2(15, 15);
                            j++;
                        }
                    }
                }
            }
        }

        protected override void FillGrid()
        {
            int l;
            int k;
            for (l = 0; l < gameboard.GetLength(0); l++)
            {
                for (k = 0; k < gameboard.GetLength(1); k++)
                {
                    gameboard[l, k] = rng.Next(0, 4);
                    if (l == 0)
                    {
                        if (k == 0)
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
            gameboard[TilesY - 2, 0] = 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (player.Health <= 0) GameClear = -1;
            else if (player.NrCollected >= OrbTotal) GameClear = 1;
        }
    }
}
