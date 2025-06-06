﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2;

public class Game1 : Game
{
    private GameState currentGameState = GameState.Playing;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    SpriteFont font;
    private EnemySpawnSystem _enemySpawnSystem;
    private PlayerShot _playerShot;
    private Vault _vault;

    private Texture2D _baseEnemyTexture;
    private Texture2D _baseBulletTexture;
    private Texture2D _vaultTexture;

    Player player;

    private void RestartGame(){
        player = new Player(new Vector2(10,10), _baseBulletTexture, 30, 100, 50);
        _vault = new Vault(new Vector2 (0,0), _vaultTexture, 7, 1000);
        _enemySpawnSystem = new EnemySpawnSystem();
        _playerShot = new PlayerShot();
        currentGameState = GameState.Playing;
    }
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        font = Content.Load<SpriteFont>("Font");

        _enemySpawnSystem = new EnemySpawnSystem();
        _playerShot = new PlayerShot();

        var pixel = new Texture2D(GraphicsDevice,1,1);
        pixel.SetData(new Color[]{Color.White});

        _baseEnemyTexture = pixel;
        _baseBulletTexture = pixel;
        _vaultTexture = pixel;

        player = new Player(new Vector2(10,10), pixel, 30, 100, 50);
        _vault = new Vault(new Vector2 (0,0), pixel, 7, 1000);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        if(currentGameState == GameState.GameOver){
            if(Keyboard.GetState().IsKeyDown(Keys.R)){
                RestartGame();
                return;
            }
        }

        if(currentGameState == GameState.Playing){
            player.Update();
            _enemySpawnSystem.ESpawnSystem(_baseEnemyTexture);
            _enemySpawnSystem.Update();
            _playerShot.BulletShootSystem(player.Position, _baseBulletTexture, gameTime);
            _playerShot.Update(_enemySpawnSystem);
            _vault.Update(_enemySpawnSystem);

            if(_vault.Health <= 0){
                currentGameState = GameState.GameOver;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        if(currentGameState == GameState.Playing){
            player.Draw(_spriteBatch);
            _enemySpawnSystem.Draw(_spriteBatch);
            _playerShot.Draw(_spriteBatch);
            _vault.Draw(_spriteBatch);
            _spriteBatch.DrawString(font,$"Vault Health {_vault.Health}", new Vector2(50, 20), Color.White);
        }
        else if(currentGameState == GameState.GameOver){
            _spriteBatch.DrawString(font,"Game Over, press 'R' to restart", new Vector2(240,240), Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
