using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAppServices.Controllers;
using WebAppServices.DTO;
using WebAppServices.Repository;

namespace WebAppUnitTest
{
    [TestClass]
    public class RoomsControllerTest
    { 

        [TestMethod]
        public void TestGetBookingsStatusCode200()
        {
            var mockBookingServiceRepository = new Mock<IRoomBookingServiceRepository>();

            DtoRooms objDtoRooms = new DtoRooms();
            objDtoRooms.Total = 10;
            objDtoRooms.Rooms = new System.Collections.Generic.List<WebAppServices.DataModels.Rooms>();

            mockBookingServiceRepository.Setup(m => m.GetAllRooms()).Returns(objDtoRooms); 
            RoomsController objBookingController = new RoomsController(mockBookingServiceRepository.Object);

            IActionResult response = objBookingController.GetBookings();
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)response).StatusCode);
        }

        [TestMethod]
        public void TestGetBookingsStatusCode204()
        {
            var mockBookingServiceRepository = new Mock<IRoomBookingServiceRepository>();

            DtoRooms objDtoRooms = null;

            mockBookingServiceRepository.Setup(m => m.GetAllRooms()).Returns(objDtoRooms);
            RoomsController objBookingController = new RoomsController(mockBookingServiceRepository.Object);

            IActionResult response = objBookingController.GetBookings(); 
            Assert.AreEqual(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)response).StatusCode);
        }

        [TestMethod]
        public void TestGetBookingsStatusCode400()
        { 
            RoomsController objBookingController = new RoomsController(null);

            IActionResult response = objBookingController.GetBookings();
            Assert.AreEqual(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)response).StatusCode);
        }

        [TestMethod]
        public void TestGetBookings110StatusCode200()
        {
            var mockBookingServiceRepository = new Mock<IRoomBookingServiceRepository>();

            DtoRooms objDtoRooms = new DtoRooms();
            objDtoRooms.Total = 10;
            objDtoRooms.Rooms = new System.Collections.Generic.List<WebAppServices.DataModels.Rooms>();

            mockBookingServiceRepository.Setup(m => m.GetAvialableRoom(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(objDtoRooms);
            RoomsController objBookingController = new RoomsController(mockBookingServiceRepository.Object);

            IActionResult response = objBookingController.GetAvialableRoom("2019-02-08 12:00:00.000","2019-02-08 12:10:00.000");
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)response).StatusCode);
        }

        [TestMethod]
        public void TestGetBookings110StatusCode204()
        {
            var mockBookingServiceRepository = new Mock<IRoomBookingServiceRepository>();

            DtoRooms objDtoRooms = null;

            mockBookingServiceRepository.Setup(m => m.GetAvialableRoom(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(objDtoRooms);
            RoomsController objBookingController = new RoomsController(mockBookingServiceRepository.Object);
          
            IActionResult response = objBookingController.GetAvialableRoom("2019-02-08 12:00:00.000", "2019-02-08 12:10:00.000");
            Assert.AreEqual(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)response).StatusCode);
        }

        [TestMethod]
        public void TestGetBookings110StatusCode400()
        {
            RoomsController objBookingController = new RoomsController(null);

            IActionResult response = objBookingController.GetAvialableRoom("2019-02-08 12:00:00.000", "2019-02-08 12:10:00.000");
            Assert.AreEqual(400, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)response).StatusCode);
        }
    }
}
