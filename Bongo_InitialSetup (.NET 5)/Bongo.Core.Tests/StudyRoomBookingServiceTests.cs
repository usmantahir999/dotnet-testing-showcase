﻿using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
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
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRooms;
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMoq;
        private Mock<IStudyRoomRepository> _studyRoomRepositoryMoq;
        private StudyRoomBookingService _studyRoomBookingService;

        [SetUp]
        public void Setup()
        {
            _request = new StudyRoomBooking
            {
                FirstName="Ben",
                LastName="Spark",
                Email="ben.spark@gmail.com",
                Date=new DateTime(2022,3,1)
            };
            _availableStudyRooms = new List<StudyRoom>
            {
                new StudyRoom
                {
                    Id=11,
                    RoomName="Rohtas",
                    RoomNumber="A202"
                }
            };
            _studyRoomBookingRepositoryMoq = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepositoryMoq = new Mock<IStudyRoomRepository>();
            _studyRoomRepositoryMoq.Setup(x => x.GetAll()).Returns(_availableStudyRooms);
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

        [Test]
        public void StudyRoomBooking_SaveBookingWithAvailableRoom_RetursResultWithAllValues()
        {
            StudyRoomBooking studyRoomBooking = null;
            _studyRoomBookingRepositoryMoq.Setup(u => u.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking => { studyRoomBooking = booking; });

            //act
            _studyRoomBookingService.BookStudyRoom(_request);

            //assert

            _studyRoomBookingRepositoryMoq.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(studyRoomBooking);
            Assert.AreEqual(_request.FirstName, studyRoomBooking.FirstName);
            Assert.AreEqual(_request.LastName, studyRoomBooking.LastName);
            Assert.AreEqual(_request.Email, studyRoomBooking.Email);
            Assert.AreEqual(_request.Date, studyRoomBooking.Date);
            Assert.AreEqual(_availableStudyRooms.First().Id, studyRoomBooking.StudyRoomId);

        }

        [Test]
        public void StudyRoomBookingResultCheck_InputRequest_ValuesMatchInResult()
        {
            var result=_studyRoomBookingService.BookStudyRoom(_request);
            Assert.NotNull(result);
            Assert.AreEqual(_request.FirstName, result.FirstName);
            Assert.AreEqual(_request.LastName, result.LastName);
            Assert.AreEqual(_request.Email, result.Email);
            Assert.AreEqual(_request.Date, result.Date);
        }

        [TestCase(true, ExpectedResult =StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult =StudyRoomBookingCode.NoRoomAvailable)]

        public StudyRoomBookingCode RoomBookingCode_RoomAvailablity_ReurnsSuccessResultCode(bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRooms.Clear();
            }
            return _studyRoomBookingService.BookStudyRoom(_request).Code;
        }

        [TestCase(0, false)]
        [TestCase(55, true)]
        public void StudyRoomBooking_BookRoomWithAvailalbility_ReturnsBookingId
            (int expectedBookingId, bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRooms.Clear();
            }


            _studyRoomBookingRepositoryMoq.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    booking.BookingId = 55;
                });

            var result = _studyRoomBookingService.BookStudyRoom(_request);
            Assert.AreEqual(expectedBookingId, result.BookingId);
        }

        [Test]
        public void BookNotInvoked_SaveBookingWithoutAvailableRoom_BookMethodNotInvoked()
        {
            _availableStudyRooms.Clear();
            var result = _studyRoomBookingService.BookStudyRoom(_request);
            _studyRoomBookingRepositoryMoq.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);

        }
    }
}
