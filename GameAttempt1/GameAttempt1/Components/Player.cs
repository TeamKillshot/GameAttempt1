using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace Components
{
    public sealed class Player : GameComponent
    {
        #region Properties and Variables

        public PlayerIndex index;
        public Vector2 Position;
        public Texture2D Sprite { get; set; }
        public string Name { get; set; }
        public Body Body { get; set; }
        float gravity = 9.8f;
        World world;

        public List<Player> playerList = new List<Player>();

        public bool IsConnected = false;

        private int speed = 15;
        #endregion

        public Player(Game _game)
            : base (_game)
        {
            GamePad.GetState(index);
            _game.Components.Add(this);
        }

        public void GetPlayerPosition(Player player)
        {
            player.world = new World(new Vector2(0, gravity));

            player.Position = new Vector2(200, 200);
            player.Body = BodyFactory.CreateCircle(world, 1, 1);
            player.Body.Restitution = 1f;
            player.Body.BodyType = BodyType.Dynamic;

            player.Position.X = Body.Position.X;
            player.Position.Y = Body.Position.Y;
        }

        public void GetPlayerIndex(Player player)
        {
            #region Check GameStates
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            GamePadState state2 = GamePad.GetState(PlayerIndex.Two);
            GamePadState state3 = GamePad.GetState(PlayerIndex.Three);
            GamePadState state4 = GamePad.GetState(PlayerIndex.Four);
            #endregion

            if (player.Name == "Player1" && state.IsConnected)
            {
                player.index = PlayerIndex.One;
                player.IsConnected = true;
            }
            else if(player.Name == "Player2" && state2.IsConnected)
            {
                player.index = PlayerIndex.Two;
                player.IsConnected = true;
            }
            else if(player.Name == "Players3" && !state.IsConnected)
            {
                player.index = PlayerIndex.Three;
                player.IsConnected = true;
            }
            else if (player.Name == "Player4" && !state.IsConnected)
            {
                player.index = PlayerIndex.Four;
                player.IsConnected = true;
            }
        }

        public unsafe void Update(GameTime gameTime, List<Player> playerList)
        {
            #region Player1 Controller
            foreach(Player player in playerList)
            {
                if (player != null && player.IsConnected == true)
                {
                    player.world.Step(1f);

                    player.Position.X = player.Body.Position.X;
                    player.Position.Y = player.Body.Position.Y;

                    GamePadState state = GamePad.GetState(player.index);

                    //var X = Math.Abs(state.ThumbSticks.Left.X);
                    //var Y = Math.Abs(state.ThumbSticks.Left.Y);

                    if (InputManager.IsButtonHeld(Buttons.DPadRight))
                    {
                        player.Position.X += speed;
                    }
                    if (InputManager.IsButtonHeld(Buttons.DPadLeft))
                    {
                        player.Position.X -= speed;
                    }
                    //if (InputManager.IsButtonPressed(Buttons.DPadDown))
                    //{
                    //    player.Position.Y += speed;
                    //}
                    //if (InputManager.IsButtonPressed(Buttons.DPadUp))
                    //{
                    //    player.Position.Y -= speed;
                    //}
                }
            }
            
            #endregion
        }

        public void Draw(GameTime gameTime, SpriteBatch spritebatch, List<Player> playerList)
        {
            spritebatch.Begin();
            foreach(Player player in playerList)
            {
                if (player.Sprite != null && player.IsConnected == true)
                {
                    spritebatch.Draw(player.Sprite, player.Position, Color.White);
                }
            }          
            spritebatch.End();
        }
    }
}
