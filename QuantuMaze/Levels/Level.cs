using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Blocks;
using QuantuMaze.GameObjects.Enemies;
using System;
using System.Collections.Generic;

namespace QuantuMaze.Levels
{
    internal abstract class Level
    {
        internal Player player;
        private Texture2D playerTexture;
        internal Texture2D strollerTexture;
        internal Texture2D jumperTexture;
        internal Texture2D chaserTexture;
        private Texture2D wallTexture;
        private Texture2D tileTexture;
        private Texture2D collectibleTexture;
        protected Random rng = new Random();
        protected int[,] gameboard;
        protected Enemy[,] enemyBoard;
        protected Collectible[,] orbBoard;
        //(28,49)
        public List<Block> Blocks { get; set; }
        public List<Collectible> Collectibles { get; set; }
        public List<Enemy> Enemies { get; set; }
        public int TilesX { get; set; }
        public int TilesY { get; set; }
        public Level(ContentManager content)
        {
            wallTexture = content.Load<Texture2D>("Platform/WallVertical");
            tileTexture = content.Load<Texture2D>("Platform/TileHorizontal");
            collectibleTexture = content.Load<Texture2D>("Collectible/Orb2");
            playerTexture = content.Load<Texture2D>("Player/Walking/Robot");
            strollerTexture = content.Load<Texture2D>("Enemies/Stroller");
            jumperTexture = content.Load<Texture2D>("Enemies/Jumper");
            chaserTexture = content.Load<Texture2D>("Enemies/Chaser");
            player = new Player(playerTexture);
            TilesX = 25;
            TilesY = 14;
            Blocks = new List<Block>();
            Collectibles = new List<Collectible>();
            Enemies = new List<Enemy>();
            gameboard = new int[TilesY, TilesX];
        }

        public void LoadContent()
        {
            foreach (Block block in Blocks)
            {
                block.wallTexture = wallTexture;
                block.tileTexture = tileTexture;
            }
            foreach (Collectible item in Collectibles)
            {
                item.Texture = collectibleTexture;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block item in Blocks)
            {
                item.Draw(spriteBatch);
            }
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (Collectible item in Collectibles)
            {
                item.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (Collectible item in Collectibles)
            {
                item.Update(gameTime);
            }
            player.Update(gameTime);
        }
        protected abstract void CreateGrid();
        protected abstract void FillGrid();
    }
}
