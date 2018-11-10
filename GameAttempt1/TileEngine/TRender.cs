using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
	
	public class TRender : DrawableGameComponent
	{
		TManager tileManager;
		Texture2D tSheet;
		int scale = 1;
		int tsWidth = 64;                    // gets the width of tSheet
		int tsHeight = 64;                   // gets teh height of tSheet

		List<TRef> tRefs = new List<TRef>();
		int[,] tileMap = new int[,]
		{
			
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  },
			{   1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  0,  0,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  0,  0,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  1,  1,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },
			{   2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  },

		};




		public TRender(Game game) : base(game)
		{
			game.Components.Add(this);
			tileManager = new TManager();
			
			// create a new tile from the TileSheet in list (locX, locY, IndexNum)
			tRefs.Add(new TRef(6, 4, 0));
			tRefs.Add(new TRef(9, 4, 1));
			tRefs.Add(new TRef(4, 3, 2));
			

			string[] tNames = { "Empty", "Ground1", "Ground2"};
			

			tileManager.addLayer("Background", tNames, 
								 tileMap, tRefs, tsWidth, tsHeight);

			tileManager.ActiveLayer = tileManager.GetLayer("Background");

			tileManager.CurrentTile = tileManager.ActiveLayer.Tiles[0, 0];

		}

		protected override void LoadContent()
		{
			tSheet = Game.Content.Load<Texture2D>
									  ("tank tiles 64 x 64");    // get TileSheet


			

			Game.Services.AddService(tSheet);
			base.LoadContent();
		}
		public override void Draw(GameTime gameTime)
		{
			SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();
			spriteBatch.Begin();

			foreach (Tile t in tileManager.ActiveLayer.Tiles)
			{
				Vector2 position = new Vector2(t.X * t.TileWidth * scale, 
											   t.Y * t.TileHeight * scale);

				spriteBatch.Draw(tSheet, new Rectangle(position.ToPoint(),
													   new Point(t.TileWidth * scale,
													   t.TileHeight * scale)),

										 new Rectangle(t.TRefs.TLocX * t.TileWidth,
													   t.TRefs.TLocY * t.TileHeight,
													   t.TileWidth * scale,
													   t.TileHeight * scale),
										 Color.White);
				
			}

			spriteBatch.End();

		}
	
	}
}
