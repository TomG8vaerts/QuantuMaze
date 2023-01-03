﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using QuantuMaze.Collision;
using QuantuMaze.GameObjects;
using QuantuMaze.GameObjects.Enemies;
using QuantuMaze.Levels;
using SharpDX.Direct3D9;

namespace QuantuMaze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }
        private SpriteBatch _spriteBatch;
        private Player player;
        private Texture2D playerTexture;
        private Enemy enemy;
        private Texture2D enemyTexture;
        private Level1 Level1;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.ToggleFullScreen();
            Level1 = new Level1();
            playerTexture = new Texture2D(GraphicsDevice, 1, 1);
            playerTexture.SetData(new[] { Color.Yellow});
            enemyTexture = new Texture2D(GraphicsDevice, 1, 1);
            enemyTexture.SetData(new[] { Color.Blue });
            player = new Player(playerTexture);
            enemy = new Chaser(enemyTexture);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Level1.LoadContent(GraphicsDevice);
            player.LoadContent(GraphicsDevice);
            enemy.LoadContent(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            enemy.Update(gameTime, player);
            player.Update(gameTime,player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            Level1.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}