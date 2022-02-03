using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Web.Tests
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _roomBookingController;

        [SetUp]

        public void Setup()
        {
            _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            _roomBookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyGetAllInvoked()
        {
            _roomBookingController.Index();
            _studyRoomBookingService.Verify(u => u.GetAllBooking(), Times.Once);
        }
    }
}
