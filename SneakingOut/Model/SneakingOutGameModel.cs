using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SneakingOut.Persistence;

namespace SneakingOut.Model
{
	/// <summary>
	/// Jatekszint tipusa
	/// </summary>
	public enum GameLevel { Level1, Level2, Level3 }

	/// <summary>
	/// Lopakodo jatektipusa
	/// </summary>
	class SneakingOutGameModel
	{
		#region Fields

		private SneakingOutDataAccess _dataAccess; // adatelérés
		private SneakingOutTable _table; // játéktábla
		private Int32 _gameStepCount; // lépések száma

		#endregion

		#region Properties 

		/// <summary>
		/// Lépések számának lekérdezése.
		/// </summary>
		public Int32 GameStepCount { get { return _gameStepCount; } }

		/// <summary>
		/// Játéktábla lekérdezése.
		/// </summary>
		public SneakingOutTable Table { get { return _table; } }

		/// <summary>
		/// Játék végének lekérdezése.
		/// </summary>
		// vege ha egymashozertek public
		Boolean IsGameOver { get { return (_table.isEscaped()); } }

		#endregion

		#region Events

		/// <summary>
		/// Játék előrehaladásának eseménye.
		/// </summary>
		public event EventHandler<SneakingOutEventArgs> GameAdvanced;

		/// <summary>
		/// Játék végének eseménye.
		/// </summary>
		public event EventHandler<SneakingOutEventArgs> GameOver;

		#endregion

		#region Constructor 

		/// <summary>
		/// Sudoku játék példányosítása.
		/// </summary>
		/// <param name="dataAccess">Az adatelérés.</param>
		public SneakingOutGameModel(SneakingOutDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
			_table = new SneakingOutTable();
			
		}

		#endregion

		#region public game methods

		public void newGame() 
		{
			_table = new SneakingOutTable();
			_gameStepCount = 0;

		}


		/// <summary>
		/// Táblabeli lépés végrehajtása.
		/// </summary>
		/// <param name="x">Vízszintes koordináta.</param>
		/// <param name="y">Függőleges koordináta.</param>
		public void Step(Int32 x, Int32 y)
		{
			if (IsGameOver) // ha már vége a játéknak, nem játszhatunk
				return;
			if (_table.GetValue(x, y) == 4) // ha a mező zárolva van, nem léthatünk
				return;

			_table.StepValue(x, y);

			_gameStepCount++; // lépésszám növelés

			if (_table.isEscaped()) // ha vége a játéknak, jelezzük, hogy győztünk
			{
				OnGameOver(true);
			}
		}

		/// Játék betöltése.
		/// </summary>
		/// <param name="path">Elérési útvonal.</param>
		public async Task LoadGameAsync(String path)
		{
			if (_dataAccess == null)
				throw new InvalidOperationException("No data access is provided.");

			_table = await _dataAccess.LoadAsync(path);
			_gameStepCount = 0;

		}

		/// <summary>
		/// Játék mentése.
		/// </summary>
		/// <param name="path">Elérési útvonal.</param>
		public async Task SaveGameAsync(String path)
		{
			if (_dataAccess == null)
				throw new InvalidOperationException("No data access is provided.");

			await _dataAccess.SaveAsync(path, _table);
		}

		#endregion

		#region Private event methods


		/// <summary>
		/// Játék vége eseményének kiváltása.
		/// </summary>
		/// <param name="isWon">Győztünk-e a játékban.</param>
		private void OnGameOver(Boolean isWon)
		{
			if (GameOver != null)
				GameOver(this, new SneakingOutEventArgs(isWon, _gameStepCount));
		}

		#endregion

	}
}
