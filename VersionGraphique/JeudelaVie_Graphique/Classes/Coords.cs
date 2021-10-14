namespace Jeudelavie.Classes
{
	public struct Coords
	{
		public int _x { get; }
		public int _y { get; }

		public Coords(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public override string ToString()
		{
			return $"({_x};{_y})";
		}
	}
}