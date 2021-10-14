namespace Jeudelavie.Classes
{
	public class Cell
	{
		public bool _isAlive { get; private set; }
		private bool _nextState;

		public Cell(bool state)
		{
			_isAlive = state;
		}

		public void ComeAlive()
		{
			_nextState = true;
		}

		public void PassAway()
		{
			_nextState = false;
		}

		public void Update()
		{
			_isAlive = _nextState;
		}
	}
}