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
    internal abstract class Level : LevelContent
    {
        internal Player player;
        private Texture2D playerTexture;
        internal Texture2D strollerTexture;
        internal Texture2D jumperTexture;
        internal Texture2D chaserTexture;
        private Texture2D wallTexture;
        private Texture2D tileTexture;
        private Texture2D collectibleTexture;
        internal Texture2D rectangleTexture;
        internal SpriteFont spriteFont;
        protected Random rng = new Random();
        protected int[,] gameboard;
        protected Enemy[,] enemyBoard;
        protected Collectible[,] orbBoard;
        protected LevelMenu menu;
        //(28,49)
        public List<Block> Blocks { get; set; }
        public List<Collectible> Collectibles { get; set; }
        public List<Enemy> Enemies { get; set; }
        public int TilesX { get; set; }
        public int TilesY { get; set; }
        public int GameClear { get; set; }
        public int OrbTotal { get; set; }
        public Level(ContentManager content) : base(content)
        {
            wallTexture = content.Load<Texture2D>("Platform/WallVertical");
            tileTexture = content.Load<Texture2D>("Platform/TileHorizontal");
            collectibleTexture = content.Load<Texture2D>("Collectible/Orb2");
            playerTexture = content.Load<Texture2D>("Player/Walking/Robot");
            strollerTexture = content.Load<Texture2D>("Enemies/Stroller");
            jumperTexture = content.Load<Texture2D>("Enemies/Jumper");
            chaserTexture = content.Load<Texture2D>("Enemies/Chaser");
            rectangleTexture = content.Load<Texture2D>("Message/Rectangle");
            spriteFont = content.Load<SpriteFont>("Fonts/myFont");
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
            foreach (Collectible item in Collectibles)
            {
                item.Draw(spriteBatch);
            }
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            menu.Draw(spriteBatch);
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
                if (item.Collected == 1)
                {
                    player.NrCollected++;
                    item.Collected = -1;
                }
            }
            player.Update(gameTime);
            menu.Update(gameTime, player);
        }
        protected abstract void CreateGrid();
        protected abstract void FillGrid();
    }
}
