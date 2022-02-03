using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core.Tests
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMoq;
        private Mock<IStudyRoomRepository> _studyRoomRepositoryMoq;
        private StudyRoomBookingService _studyRoomBookingService;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingRepositoryMoq = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepositoryMoq = new Mock<IStudyRoomRepository>();
            _studyRoomBookingService = new StudyRoomBookingService(_studyRoomBookingRepositoryMoq.Object, _studyRoomRepositoryMoq.Object);
        }

        [Test]

        public void GetAllBooking_InvokedMethod_CheckIfRepoIsCalled()
        {
            _studyRoomBookingService.GetAllBooking();
            _studyRoomBookingRepositoryMoq.Verify(u => u.GetAll(null), Times.Once);
        }

        [Test]
        public void BookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>_studyRoomBookingService.BookStudyRoom(null));
            Assert.AreEqual("request", exception.ParamName);
        }
    }
}
