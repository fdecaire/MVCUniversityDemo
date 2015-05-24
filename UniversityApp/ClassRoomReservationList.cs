using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
	[Serializable]
	public class ClassRoomReservationList
	{
		public List<RoomReservationResult> ReservedRoomList;

		public ClassRoomReservationList()
		{
		}

		public ClassRoomReservationList(ClassAPIRoomRequest request)
		{
			using (var db = new ClassDatabase())
			{
				if (request.AllReserved)
				{
					// return only reserved class rooms
					ReservedRoomList = (from rr in db.RoomReservations
										join r in db.Rooms on rr.room equals r.id
										where rr.Reserved == true
										select new RoomReservationResult() 
										{ 
											Name = r.Name, 
											RoomNumber = r.RoomNumber, 
											Reserved = rr.Reserved, 
											TimeSlot = rr.TimeSlot 
										}).ToList();

				}
				else if (request.AllAvailable)
				{
					// return only avaialable class rooms
					ReservedRoomList = (from rr in db.RoomReservations
								join r in db.Rooms on rr.room equals r.id
								where rr.Reserved == false
								select new RoomReservationResult()
								{
									Name = r.Name,
									RoomNumber = r.RoomNumber,
									Reserved = rr.Reserved,
									TimeSlot = rr.TimeSlot
								}).ToList();
				}
				else
				{
					// return all class rooms
					ReservedRoomList = (from rr in db.RoomReservations
								join r in db.Rooms on rr.room equals r.id
								select new RoomReservationResult()
								{
									Name = r.Name,
									RoomNumber = r.RoomNumber,
									Reserved = rr.Reserved,
									TimeSlot = rr.TimeSlot
								}).ToList();
				}
			}
		}
	}
}
