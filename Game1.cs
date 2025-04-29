using System;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private EnemySpawnSystem _enemySpawnSystem;
    private PlayerShot _playerShot;

    private Texture2D _baseEnemyTexture;
    private Texture2D _baseBulletTexture;

    Player player;
    
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
        _enemySpawnSystem = new EnemySpawnSystem();
        _playerShot = new PlayerShot();

        var pixel = new Texture2D(GraphicsDevice,1,1);
        pixel.SetData(new Color[]{Color.White});

        _baseEnemyTexture = pixel;
        _baseBulletTexture = pixel;

        player = new Player(new Vector2(10,10), pixel, 30, 100);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        player.Update();
        _enemySpawnSystem.ESpawnSystem(_baseEnemyTexture);
        _enemySpawnSystem.Update();
        _playerShot.BulletShootSystem(player.Position, _baseBulletTexture, gameTime);
        _playerShot.Update(_enemySpawnSystem);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        _enemySpawnSystem.Draw(_spriteBatch);
        _playerShot.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
