using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
	public class TLayer
	{
		List<TRef> refs;
		List<Tile> impassible = new List<Tile>();
		List<Tile> passable = new List<Tile>();
		Tile[,] tiles;
		string layerName;
		public int TileWidth;
		public int TileHeight;
		public Tile[,] Tiles
		{
			get { return tiles; }
			set { tiles = value; }
		}
		public string LayerName
		{
			get { return layerName; }
			set { layerName = value; }
		}
		public int MapWidth
		{
			get { return Tiles.GetLength(1); }
		}
		public int MapHeight
		{
			get { return Tiles.GetLength(0); }
		}
		public List<TRef> TRefs
		{
			get { return refs; }
			set { refs = value; }
		}
	}
}
