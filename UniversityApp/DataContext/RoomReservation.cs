using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace UniversityApp
{
	[Table(Name = "RoomReservation")]
	public class RoomReservation
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public Int32 id { get; set; }

		[Column]
		public Int32 room { get; set; }

		[Column]
		public Int32 TimeSlot { get; set; }

		[Column]
		public bool Reserved { get; set; }
	}
}
