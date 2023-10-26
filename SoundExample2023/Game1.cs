using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SoundExample2023
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Song _backing;
        SoundEffect _sound;
        SoundEffectInstance _soundPlayer;
        KeyboardState previousKS, currentKS;
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
            _backing = Content.Load<Song>(@"Audio Example\Puccini  Nessun Dorma");
            MediaPlayer.Play(_backing);
            _sound = Content.Load<SoundEffect>(@"Audio Example\29");
            _sound.Play();
            _soundPlayer = _sound.CreateInstance();
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            currentKS = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(currentKS.IsKeyDown(Keys.P) 
                && _soundPlayer.State == SoundState.Stopped
                )
            {
                _soundPlayer.Play();
                //_sound.Play();
            }
            // TODO: Add your update logic here
            previousKS = currentKS;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
