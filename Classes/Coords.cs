namespace Jeudelavie.Classes
{
	public struct Coords
	{
		private int _x { get; }
		private int _y { get; }

		public Coords(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}