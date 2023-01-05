using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects.Blocks;
using System;
using System.Collections.Generic;

namespace QuantuMaze.Levels
{
    internal class Level1
    {
        Random rng = new Random();
        int[,] gameboard; 
        //(28,49)
        List<Block> Blocks { get; set; }
        public int TilesX { get; set; } 

        public int TilesY { get; set; } 
        public Level1()
        {
            TilesX = 25;
            TilesY = 14;
            Blocks = new List<Block>();
            FillRandomGrid();
            CreateGrid();
        }
        public void LoadContent(GraphicsDevice graphics)
        {
            foreach (Block item in Blocks)
            {
                item.LoadContent(graphics);
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.Draw(spriteBatch);
            }
        }

        private void CreateGrid()
        {
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    Blocks.Add(BlockFactory.CreateBlock(gameboard[l, k],k*79,l*80));
                }
            }
        }
        private void FillRandomGrid()
        {
            int l;
            int k;
            gameboard = new int[TilesY,TilesX];
            for ( l = 0; l < gameboard.GetLength(0); l++)
            {
                for ( k = 0; k < gameboard.GetLength(1); k++)
                {
                    gameboard[l, k] = rng.Next(0, 4);
                    if (l==0)
                    {
                        gameboard[l, k] = rng.Next(2, 4);
                    }
                    if (k==0)
                    {
                        if (rng.Next(0, 2)==0)
                        {
                            gameboard[l, k] = 1;
                        }
                        else
                        {
                            gameboard[l, k] = 3;
                        }
                    }
                    if (l == TilesY-1)
                    {
                        gameboard[l, k] = 2;
                    }
                    if (k == TilesX-1)
                    {
                        gameboard[l, k] = 1;
                        if (l==TilesY)
                        {
                            gameboard[l, k] = 4;
                        }
                    }
                }
            }

        }
    }
}
