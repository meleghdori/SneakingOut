﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SneakingOut.Model
{
	class SneakingOutEventArgs : EventArgs
	{
        private Int32 _gameTime;
        private Int32 _steps;
        private Boolean _isWon;

        /// <summary>
        /// Játékidő lekérdezése.
        /// </summary>
        public Int32 GameTime { get { return _gameTime; } }

        /// <summary>
        /// Játéklépések számának lekérdezése.
        /// </summary>
        public Int32 GameStepCount { get { return _steps; } }

        /// <summary>
        /// Győzelem lekérdezése.
        /// </summary>
        public Boolean IsWon { get { return _isWon; } }

        /// <summary>
        /// Sudoku eseményargumentum példányosítása.
        /// </summary>
        /// <param name="isWon">Győzelem lekérdezése.</param>
        /// <param name="gameStepCount">Lépésszám.</param>
        /// <param name="gameTime">Játékidő.</param>
        public SneakingOutEventArgs(Boolean isWon, Int32 gameStepCount, Int32 gameTime)
        {
            _isWon = isWon;
            _steps = gameStepCount;
            _gameTime = gameTime;
        }
    }
}
