using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects.Blocks;
using System.Collections.Generic;

namespace QuantuMaze.Levels
{
    internal class Level1
    {
        int[,] gameboard = new int[,]
{
    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 2,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,2 },
    { 2,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,2 },
    { 2,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,2 },
    { 1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,2 },
    { 0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,2 },
    { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,2 },
    { 2,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,2 },
    { 2,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,2 },
    { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,2 },
    { 2,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,2 },
    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,2 },
    { 2,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,2 },
    { 2,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0 },
    { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0 },
    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
};
        List<Block> Blocks { get; set; }
        public static int TilesX { get; set; } 

        public static int TilesY { get; set; } 
        public Level1()
        {
            TilesX = gameboard.GetLength(1);
            TilesY = gameboard.GetLength(0);
            Blocks = new List<Block>();
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
                    Blocks.Add(BlockFactory.CreateBlock(gameboard[l, k],k*40,l*40));
                }
            }
        }
    }
}
