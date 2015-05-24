using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using Helpers;

namespace UniversityApp
{
	[Database]
	public class ClassDatabase : DataContext, IDisposable
	{
		public ClassDatabase()
			: base(EFContextHelper.ConnectionString("{YOUR SQL SERVER NAME}", "APIUniversity"))
		{
		}

		public Table<Room> Rooms;
		public Table<RoomReservation> RoomReservations;
	}
}
