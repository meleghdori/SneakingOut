using System;
using System.Collections.Generic;
using System.Text;

namespace SneakingOut.Persistence
{
	class Player
	{
		private Int32 TablePositionX;
		private Int32 TablePositionY;

		public Player(Int32 tablePositionX, Int32 tablePositionY)
		{
			TablePositionX = tablePositionX;
			TablePositionY = tablePositionY;
		}
	}
}
