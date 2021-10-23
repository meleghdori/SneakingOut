using System;
using System.Collections.Generic;
using System.Text;

namespace SneakingOut.Persistence
{
	class Security
	{
		private Int32 TablePositionX;
		private Int32 TablePositionY;
		private Boolean Up;
		private Boolean Down;
		private Boolean Right;
		private Boolean Left;

		public Security(Int32 tablePositionX, Int32 tablePositionY)
		{
			TablePositionX = tablePositionX;
			TablePositionY = tablePositionY;
			Up = false;
			Down = false;
			Right = false;
			Left = false;
		}

	}
}
