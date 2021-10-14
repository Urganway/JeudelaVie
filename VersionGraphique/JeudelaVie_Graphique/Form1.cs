using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Jeudelavie.Classes;

namespace JeudelaVie_Graphique
{
	public partial class Form1 : Form
	{
		private Game _game;
		private int _cellPixelSize;
		public Form1(Game game, int cellPixelSize, int refreshTime)
		{
			_cellPixelSize = cellPixelSize;
			_game = game;
			InitializeComponent(_game._gridSize, _cellPixelSize);

			Timer refreshTimer = new Timer();
			refreshTimer.Interval = refreshTime;
			refreshTimer.Tick += new EventHandler(refreshTimer_Timer);
			refreshTimer.Start();

			pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
		}

		private void refreshTimer_Timer(object sender, EventArgs e)
		{
			_game.grid.UpdateGrid();
			Refresh();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			_game.Paint(e.Graphics, _cellPixelSize);
		}
	}
}