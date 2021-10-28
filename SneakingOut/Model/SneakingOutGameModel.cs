﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using SneakingOut.Persistence;

namespace SneakingOut.Model
{

	/// <summary>
	/// Lopakodo jatektipusa
	/// </summary>
	public class SneakingOutGameModel
	{

		#region Fields

		private SneakingOutDataAccess _dataAccess; // adatelérés
		private SneakingOutTable _table; // játéktábla
		private Int32 _gameStepCount; // lépések száma
		private Int32 _gameTime;
		private Boolean _gotCaught;


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

		/// <summary>
		/// or1 mozagatasa
		/// </summary>
		public event EventHandler<Security> SecurityOneChanged;

		/// <summary>
		/// or2 mozgatasa
		/// </summary>
		public event EventHandler<Security> SecurityTwoChanged;

		public event EventHandler<Player> PlayerChanged;


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

		public void NewGame() 
		{
			_gotCaught = false;
			_table = new SneakingOutTable();
			_gameStepCount = 0;
		}

		/// <summary>
		/// Játékidő léptetése.
		/// </summary>
		public void AdvanceTime()
		{
			if (!_gotCaught && !_table._isEscaped)
			{
				if (IsGameOver) // ha már vége, nem folytathatjuk
					return;

				PlayerChanged?.Invoke(this, (_table._player));

				_gameTime++;
				isGettingCaught();
				OnGameAdvanced();
				EverythingMoves();
				Wins();
			}
			else if (_gotCaught)
			{
				OnGameOver(false);
			}
			else if (_table._isEscaped)
			{
				OnGameOver(true);
			}
			

		}
		/// <summary>
		/// ha az exitnel van akk nyer
		/// </summary>
		public void Wins()
		{
			if (_table._player.getPositionX() == _table._Exit[0] && _table._player.getPositionY() == _table._Exit[1])
			{
				_table._isEscaped = true;
			}
		}

		/// <summary>
		/// minden or mozogjon
		/// </summary>
		public void EverythingMoves()
		{
			if (IsGameOver) // ha már vége, nem folytathatjuk
				return;

			SecurityMove(_table._securityOne, _table._securityOne.getDirection() );
			SecurityOneChanged?.Invoke(this, _table._securityOne);
			SecurityMove(_table._securityTwo, _table._securityTwo.getDirection() );
			SecurityTwoChanged?.Invoke(this,_table._securityTwo);// ha nem null akk hivodik meg

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
				if (sec.getPositionX() - 1 >= 0 && _table[sec.getPositionX() - 1, sec.getPositionY()] == 0)
				{
					_table.SetValue(sec.getPositionX(), sec.getPositionY(), 0);
					sec.setDirection(direction);
					sec.setPositionX(sec.getPositionX() - 1);
				}
				else if (sec.getPositionX() - 1 < 0 || _table[sec.getPositionX() - 1, sec.getPositionY()] == 4 || _table[sec.getPositionX() - 1, sec.getPositionY()] == 5)
				{
					SecurityMove(sec, change);
				}
			}

			if (direction == 1)
			{
				if (sec.getPositionX() + 1 < 10 && _table[sec.getPositionX() + 1, sec.getPositionY()] == 0)
				{
					_table.SetValue(sec.getPositionX(), sec.getPositionY(), 0);
					sec.setDirection(direction);
					sec.setPositionX(sec.getPositionX() + 1);
				}
				else if (sec.getPositionX() + 1 >= 10 || _table[sec.getPositionX() + 1, sec.getPositionY()] == 4 || _table[sec.getPositionX() + 1, sec.getPositionY()] == 5)
				{
					SecurityMove(sec, change);
				}
			}


			if (direction == 2)
			{
				if (sec.getPositionY() + 1 < 10 && _table[sec.getPositionX(), sec.getPositionY() + 1] == 0)
				{
					_table.SetValue(sec.getPositionX(), sec.getPositionY(), 0);
					sec.setDirection(direction);
					sec.setPositionY(sec.getPositionY() + 1);
				}
				else if (sec.getPositionY() + 1 >= 10 || _table[sec.getPositionX(), sec.getPositionY() + 1] == 4 || _table[sec.getPositionX(), sec.getPositionY() + 1] == 5)
				{
					SecurityMove(sec, change);
				}
			}

			if (direction == 3)
			{
				if (sec.getPositionY() - 1 >= 0 && _table[sec.getPositionX(), sec.getPositionY() - 1] == 0)
				{
					_table.SetValue(sec.getPositionX(), sec.getPositionY(), 0);
					sec.setDirection(direction);
					sec.setPositionY(sec.getPositionY() - 1);
				}
				else if (sec.getPositionY() - 1 < 0 || _table[sec.getPositionX(), sec.getPositionY() - 1] == 4 || _table[sec.getPositionX(), sec.getPositionY() - 1] == 5)
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
			if (IsGameOver) // ha már vége a játéknak, nem játszhatunk
			return;

			if (direction == 0)
			{
				if (player.getPositionX() - 1 >= 0 && _table[player.getPositionX() - 1, player.getPositionY()] == 0 || _table[player.getPositionX() - 1, player.getPositionY()] == 5)
				{
					_table.SetValue(player.getPositionX(), player.getPositionY(), 0);
					player.setPositionX(player.getPositionX() - 1);
					player.setDirection(direction);
					_gameStepCount++;
				}
			
			}

			if (direction == 1)
			{
				if (player.getPositionX() + 1 < 10 && _table[player.getPositionX() + 1, player.getPositionY()] == 0 || _table[player.getPositionX() + 1, player.getPositionY()] == 5)
				{
					_table.SetValue(player.getPositionX(), player.getPositionY(), 0);
					player.setPositionX(player.getPositionX() + 1);
					player.setDirection(direction);
					_gameStepCount++;
				}
			}

			if (direction == 2)
			{
				if (player.getPositionY() + 1 < 10 && _table[player.getPositionX(), player.getPositionY() + 1] == 0 || _table[player.getPositionX(), player.getPositionY() + 1] == 5)
				{
					_table.SetValue(player.getPositionX(), player.getPositionY(), 0);
					player.setPositionY(player.getPositionY() + 1);
					player.setDirection(direction);
					_gameStepCount++;
				}	
			}

			if (direction == 3)
			{
				if (player.getPositionY() - 1 >= 0 && _table[player.getPositionX(), player.getPositionY() - 1] == 0 || _table[player.getPositionX(), player.getPositionY() - 1] == 5)
				{
					_table.SetValue(player.getPositionX(), player.getPositionY(), 0);
					player.setPositionY(player.getPositionY() - 1);
					player.setDirection(direction);
					_gameStepCount++;
				}
			}
		}


		/// <summary>
		/// ha elkapjak akk vege
		/// </summary>
		public void isGettingCaught()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (_table._player.getPositionX() == _table._securityOne.getPositionX() + i && _table._player.getPositionY() == _table._securityOne.getPositionY() + j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityOne.getPositionX() + i && _table._player.getPositionY() == _table._securityOne.getPositionY() - j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityOne.getPositionX() - i && _table._player.getPositionY() == _table._securityOne.getPositionY() + j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityOne.getPositionX() - i && _table._player.getPositionY() == _table._securityOne.getPositionY() - j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityTwo.getPositionX() + i && _table._player.getPositionY() == _table._securityTwo.getPositionY() + j)
					{
						_gotCaught = true;
					}
					if(_table._player.getPositionX() == _table._securityTwo.getPositionX() + i && _table._player.getPositionY() == _table._securityTwo.getPositionY() - j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityTwo.getPositionX() - i && _table._player.getPositionY() == _table._securityTwo.getPositionY() + j)
					{
						_gotCaught = true;
					}
					if (_table._player.getPositionX() == _table._securityTwo.getPositionX() - i && _table._player.getPositionY() == _table._securityTwo.getPositionY() - j)
					{
						_gotCaught = true;
					}
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
