using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace UniversityApp
{
	[Table(Name = "Room")]
	public class Room
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public Int32 id { get; set; }

		[Column]
		public Int32 RoomNumber { get; set; }

		[Column]
		public string Name { get; set; }
	}
}
