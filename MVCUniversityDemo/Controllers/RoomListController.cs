using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityApp;

namespace MVCUniversityDemo.Controllers
{
    public class RoomListController : Controller
    {
		private void PopulateViewBagData(string lstRoomSelector)
		{
			ClassAPIRoomRequest classAPIRoomRequest = new ClassAPIRoomRequest();

			switch (lstRoomSelector)
			{
				case "Show Only Reserved Rooms":
					classAPIRoomRequest.AllReserved = true;
					break;
				case "Show Only Available Rooms":
					classAPIRoomRequest.AllAvailable = true;
					break;
			}

			var classRoomReservationList = new ClassRoomReservationList(classAPIRoomRequest);
			ViewBag.ClassRoomReservationList = classRoomReservationList;

			var listItems = new List<string> { 
				"Show All Rooms",
				"Show Only Reserved Rooms",
				"Show Only Available Rooms"
			};

			ViewBag.RoomList = new SelectList(listItems);
		}

        //
        // GET: /RoomList/
		public ActionResult Index()
		{
			PopulateViewBagData("");
			return View();
		}

		[HttpPost]
		public ActionResult ChangeSelection(string lstRoomSelector)
		{
			PopulateViewBagData(lstRoomSelector);
			return View("Index");
		}
    }
}
