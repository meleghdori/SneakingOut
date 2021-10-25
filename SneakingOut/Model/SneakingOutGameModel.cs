using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SneakingOut.Persistence;

namespace SneakingOut.Model
{
	public enum GameLevel { Level1, Level2, Level3 }

	/// <summary>
	/// Lopakodo jatektipusa
	/// </summary>
	public class SneakingOutGameModel
	{

		#region Fields

		private SneakingOutDataAccess _dataAccess; // adatelérés
		private SneakingOutTable _table; // játéktábla
		private GameLevel _gameLevel;
		private Int32 _gameStepCount; // lépések száma
		private Int32 _gameTime;

		#endregion

		#region Properties 

		/// <summary>
		/// Lépések számának lekérdezése.
		/// </summary>
		public Int32 GameStepCount { get { return _gameStepCount; } }

		/// <summary>
		/// játékidő lekérdezése.
		/// </summary>
		public Int32 GameTime { get { return _gameTime; } }

		/// <summary>
		/// Játéktábla lekérdezése.
		/// </summary>
		public SneakingOutTable Table { get { return _table; } }

		/// <summary>
		/// Játék végének lekérdezése.
		/// </summary>
		// vege ha egymashozertek public
		Boolean IsGameOver { get { return (_table._isEscaped); } }

		/// <summary>
		/// Játéknehézség lekérdezése, vagy beállítása.
		/// </summary>
		public GameLevel GameLevel { get { return _gameLevel; } set { _gameLevel = value; } }


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
			_gameLevel = GameLevel.Level1;
		}

		#endregion

		#region public game methods

		public void NewGame() 
		{
			_table = new SneakingOutTable();
			_gameStepCount = 0;
			switch (_gameLevel)
			{
				case GameLevel.Level1:
					break;
				case GameLevel.Level2:
					break;
				case GameLevel.Level3:
					break;
			}
		}

		/// <summary>
		/// Játékidő léptetése.
		/// </summary>
		public void AdvanceTime()
		{
			if (IsGameOver) // ha már vége, nem folytathatjuk
				return;

			_gameTime++;
			OnGameAdvanced();
			EverythingMoves();
		}

		public void EverythingMoves()
		{
			if (IsGameOver) // ha már vége, nem folytathatjuk
				return;

			SecurityMove(_table._securityOne, 0);
			SecurityMove(_table._securityTwo, 3);


		}


		/// <summary>
		/// Mozoghat e arra az őr
		/// </summary>
		/// <param name="sec"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		public void SecurityMove(Security sec, Int32 direction)
		{
			Random rand = new Random();
			Int32 change = rand.Next(0, 4);

			if (direction == 0)
			{
				if (sec.getPositionY() + 1 <= 30 && _table[sec.getPositionX(), sec.getPositionY() + 1] == 0)
				{ 
					sec.setPositionY(sec.getPositionY() + 1);
				}
				else if (_table[sec.getPositionX(), sec.getPositionY() + 1] == 4 || sec.getPositionY() + 1 > 30)
				{
					SecurityMove(sec, change);
				}
			}

			if (direction == 1)
			{
				if (sec.getPositionY() - 1 >= 0 && _table[sec.getPositionX(), sec.getPositionY() - 1] == 0)
				{
					sec.setPositionY(sec.getPositionY() - 1);
				}
				else if (_table[sec.getPositionX(), sec.getPositionY() - 1] == 4 || sec.getPositionY() - 1 < 0)
				{
					SecurityMove(sec, change);
				}
			}


			if (direction == 2)
			{
				if (sec.getPositionX() + 1 <= 30 && _table[sec.getPositionX() + 1, sec.getPositionY()] == 0)
				{
					sec.setPositionX(sec.getPositionX() + 1 );
				}
				else if (_table[sec.getPositionX() + 1, sec.getPositionY()] == 4 || sec.getPositionX() + 1 > 30)
				{
					SecurityMove(sec, change);
				}
			}

			if (direction == 3)
			{
				if (sec.getPositionX() - 1 >= 0 && _table[sec.getPositionX() - 1, sec.getPositionY()] == 0)
				{
					sec.setPositionY(sec.getPositionY() + 1);
				}
				else if (_table[sec.getPositionX() - 1, sec.getPositionY()] == 4 || sec.getPositionX() - 1 < 0)
				{
					SecurityMove(sec, change);
				}
			}
		}

		/// <summary>
		/// a jatekos mozoghat e az adott iranyba
		/// </summary>
		/// <param name="player"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		public void PlayerMove(Player player, Int32 direction)
		{

			//if (IsGameOver) // ha már vége a játéknak, nem játszhatunk
			//return;
			//if (_table.GetValue(x, y) == 4) // ha a mező zárolva van, nem 

			if (direction == 0)
			{
				if (player.getPositionY() + 1 <= 30 && _table[player.getPositionX(), player.getPositionY() + 1] == 0)
				{
					player.setPositionY(player.getPositionY() + 1);
				}
			}

			if (direction == 1)
			{
				if (player.getPositionY() - 1 >= 0 && _table[player.getPositionX(), player.getPositionY() - 1] == 0)
				{
					player.setPositionY(player.getPositionY() - 1);
				}
			}

			if (direction == 2)
			{
				if (player.getPositionX() + 1 <= 30 && _table[player.getPositionX() + 1, player.getPositionY()] == 0)
				{
					player.setPositionX(player.getPositionX() + 1);
				}
			}

			if (direction == 3)
			{
				if (player.getPositionX() - 1 >= 0 && _table[player.getPositionX() - 1, player.getPositionY()] == 0)
				{
					player.setPositionX(player.getPositionX() - 1);
				}
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
			_gameTime = 0;

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
		/// Játékidő változás eseményének kiváltása.
		/// </summary>
		private void OnGameAdvanced()
		{
			if (GameAdvanced != null)
				GameAdvanced(this, new SneakingOutEventArgs(false, _gameStepCount, _gameTime));
		}

		/// <summary>
		/// Játék vége eseményének kiváltása.
		/// </summary>
		/// <param name="isWon">Győztünk-e a játékban.</param>
		private void OnGameOver(Boolean isWon)
		{
			if (GameOver != null)
				GameOver(this, new SneakingOutEventArgs(isWon, _gameStepCount, _gameTime));
		}

		#endregion

	}
}
