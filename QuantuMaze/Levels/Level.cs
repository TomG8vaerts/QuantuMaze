using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects.Blocks;
using System;
using System.Collections.Generic;

namespace QuantuMaze.Levels
{
    internal abstract class Level
    {
        protected Random rng = new Random();
        protected int[,] gameboard;
        private Texture2D wallTexture;
        private Texture2D tileTexture;
        //(28,49)
        protected List<Block> Blocks { get; set; }
        public int TilesX { get; set; }
        public int TilesY { get; set; }
        public Level(ContentManager content)
        {
            wallTexture = content.Load<Texture2D>("Platform/WallVertical");
            tileTexture = content.Load<Texture2D>("Platform/TileHorizontal");
            TilesX = 25;
            TilesY = 14;
            Blocks = new List<Block>();
            FillRandomGrid();
            CreateGrid();
            foreach (Block block in Blocks)
            {
                block.wallTexture = wallTexture;
                block.tileTexture = tileTexture;
            }
        }
        internal abstract void Draw(SpriteBatch spriteBatch);
        internal abstract void Update(GameTime gameTime);
        protected abstract void CreateGrid();

        protected abstract void FillRandomGrid();
    }
}
