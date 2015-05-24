using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityApp;
using Helpers;
using System.Data.Linq;

namespace UniversityAppTests
{
	[TestClass]
	public class ClassRoomReservations
	{
		[TestCleanup]
		public void Cleanup()
		{
			UnitTestHelpers.TruncateData();
		}

		[TestMethod]
		public void TestAllAvailable()
		{
			// insert test data
			using (var db = new ClassDatabase())
			{
				var room = new Room { Name = "Gym", RoomNumber = 1 };
				db.Rooms.InsertOnSubmit(room);
				room = new Room { Name = "Math Room", RoomNumber = 2 };
				db.Rooms.InsertOnSubmit(room);
				room = new Room { Name = "Chemistry Lab", RoomNumber = 3 };
				db.Rooms.InsertOnSubmit(room);
				db.SubmitChanges();

				var reservation = new RoomReservation { room = 1, TimeSlot = 1, Reserved = true };
				db.RoomReservations.InsertOnSubmit(reservation);
				reservation = new RoomReservation { room = 1, TimeSlot = 2, Reserved = false };
				db.RoomReservations.InsertOnSubmit(reservation);
				db.SubmitChanges();
			}

			// call method under test
			var request = new ClassAPIRoomRequest
			{
				AllAvailable = true
			};
			var classRoomReservationList = new ClassRoomReservationList(request);

			// assert
			Assert.AreEqual(1, classRoomReservationList.ReservedRoomList.Count);
		}

		[TestMethod]
		public void TestAllReserved()
		{
			// insert test data
			using (var db = new ClassDatabase())
			{
				var room = new Room { Name = "Gym", RoomNumber = 1 };
				db.Rooms.InsertOnSubmit(room);
				room = new Room { Name = "Math Room", RoomNumber = 2 };
				db.Rooms.InsertOnSubmit(room);
				room = new Room { Name = "Chemistry Lab", RoomNumber = 3 };
				db.Rooms.InsertOnSubmit(room);
				db.SubmitChanges();

				var reservation = new RoomReservation { room = 1, TimeSlot = 1, Reserved = true };
				db.RoomReservations.InsertOnSubmit(reservation);
				reservation = new RoomReservation { room = 1, TimeSlot = 2, Reserved = false };
				db.RoomReservations.InsertOnSubmit(reservation);
				reservation = new RoomReservation { room = 2, TimeSlot = 1, Reserved = true };
				db.RoomReservations.InsertOnSubmit(reservation);
				db.SubmitChanges();
			}

			// call method under test
			var request = new ClassAPIRoomRequest
			{
				AllReserved = true
			};
			var classRoomReservationList = new ClassRoomReservationList(request);

			// assert
			Assert.AreEqual(2, classRoomReservationList.ReservedRoomList.Count);
		}
	}
}
