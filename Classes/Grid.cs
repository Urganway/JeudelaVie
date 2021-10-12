using System.Collections.Generic;

namespace Jeudelavie.Classes
{
	public class Grid
	{
		private int _n { get; set; }
		private Cell[] TabCells;
		
		public Grid(int nbCells, List<Coords> aliveCellsCoords){}

		public int GetNbAliveNeighboor(int i, int j)
		{
			return 0;
		}

		public List<Coords> GetCoordsNeighboor(int i, int j)
		{
			return new List<Coords>();
		}

		public List<Coords> GetCoordsCellsAlive()
		{
			return new List<Coords>();
		}
		
		public void DisplayGrid(){}
		public void UpdateGrid(){}
	}
}