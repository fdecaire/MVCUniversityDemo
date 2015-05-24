using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
	[Serializable]
	public class RoomReservationResult
	{
		public string Name { get; set; }
		public Int32 RoomNumber { get; set; }
		public bool Reserved { get; set; }
		public int TimeSlot { get; set; }
	}
}
