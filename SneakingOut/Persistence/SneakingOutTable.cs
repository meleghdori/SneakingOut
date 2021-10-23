﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SneakingOut.Persistence
{
	class SneakingOutTable
	{
        #region Fields

        private Int32[,] _fieldValues; // mezőértékek
        private Player Player;
        private Security SecurityOne;
        private Security SecurityTwo;

        #endregion

        #region Properties

        /// <summary>
        /// Játéktábla méretének lekérdezése.
        /// </summary>
        public Int32 Size { get { return _fieldValues.GetLength(0); } }

        /// <summary>
        /// Mező értékének lekérdezése.
        /// </summary>
        /// <param name="x">Vízszintes koordináta.</param>
        /// <param name="y">Függőleges koordináta.</param>
        /// <returns>Mező értéke.</returns>
        public Int32 this[Int32 x, Int32 y] { get { return GetValue(x, y); } }

        #endregion

        #region Constructors

        /// <summary>
        /// Sudoku játéktábla példányosítása.
        /// </summary>
        public SneakingOutTable() : this(30) { }

        /// <summary>
        /// Sudoku játéktábla példányosítása.
        /// </summary>
        /// <param name="tableSize">Játéktábla mérete.</param>
        /// <param name="regionSize">Ház mérete.</param>
        public SneakingOutTable(Int32 tableSize)
        {
            if (tableSize < 0)
                throw new ArgumentOutOfRangeException("The table size is less than 0.", "tableSize");
            _fieldValues = new Int32[tableSize, tableSize];

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Mező kitöltetlenségének lekérdezése.
        /// </summary>
        /// <param name="x">Vízszintes koordináta.</param>
        /// <param name="y">Függőleges koordináta.</param>
        /// <returns>Igaz, ha a mező ki van töltve, egyébként hamis.</returns>
        public Boolean IsEmpty(Int32 x, Int32 y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            return _fieldValues[x, y] == 0;
        }

        /// <summary>
        /// Mező értékének lekérdezése.
        /// </summary>
        /// <param name="x">Vízszintes koordináta.</param>
        /// <param name="y">Függőleges koordináta.</param>
        /// <returns>A mező értéke.</returns>
        public Int32 GetValue(Int32 x, Int32 y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            return _fieldValues[x, y];
        }

        /// <summary>
        /// Mező értékének beállítása.
        /// </summary>
        /// <param name="x">Vízszintes koordináta.</param>
        /// <param name="y">Függőleges koordináta.</param>
        /// <param name="value">Érték.</param>
        /// <param name="lockField">Zárolja-e a mezőt.</param>
        public void SetValue(Int32 x, Int32 y, Int32 value)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");
            if (value < 0 || value > 5)
                throw new ArgumentOutOfRangeException("value", "The value is out of range.");
            if (!CheckStep(x, y)) // ha a beállítás érvénytelen, akkor nem végezzük el
                return;

            _fieldValues[x, y] = value;
            //0--üres mező, 1--SecurityOne,2--SecurityTwo, 3--Player, 4--fal
            if (value == 1)
            {
                SecurityOne = new Security(x, y);
            }
            if (value == 2)
            {
                SecurityTwo = new Security(x, y);
            }
            if (value == 3)
            {
                Player = new Player(x, y);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Lépésellenőrzés.
        /// </summary>
        /// <param name="x">Vízszintes koordináta.</param>
        /// <param name="y">Függőleges koordináta.</param>
        /// <returns>Igaz, ha a lépés engedélyezett, különben hamis.</returns>
        private Boolean CheckStep(Int32 x, Int32 y)
        {
            if (_fieldValues[x, y] == 0)
                return true;
            else
            {
                if (_fieldValues[x, y] == 4)
                {
                    return false;
                }

                return true;
            }
        }

        #endregion
    }
}
