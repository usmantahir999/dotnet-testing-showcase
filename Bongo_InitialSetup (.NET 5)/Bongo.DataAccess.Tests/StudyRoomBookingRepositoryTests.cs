using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess.Tests
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking _studyRoomBookingOne;
        private StudyRoomBooking _studyRoomBookingTwo;

        public StudyRoomBookingRepositoryTests()
        {
            _studyRoomBookingOne = new StudyRoomBooking
            {
                BookingId = 11,
                Email = "utahir604@gmail.com",
                FirstName = "usman",
                LastName = "tahir",
                Date = new DateTime(2022, 3, 1),
                StudyRoomId = 1

            };

            _studyRoomBookingTwo = new StudyRoomBooking
            {
                BookingId = 12,
                Email = "utahir604@gmail.com",
                FirstName = "awais",
                LastName = "raja",
                Date = new DateTime(2022, 4, 1),
                StudyRoomId = 2

            };
        }

        [Test]
        [Order(1)]
        public void SaveBooking_Booking_One_CheckTheValuesFromDatabase()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

            //act

            using(var context=new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(_studyRoomBookingOne);
            }

            //assert


            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb=context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 11);
                Assert.AreEqual(_studyRoomBookingOne.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(_studyRoomBookingOne.Email, bookingFromDb.Email);
                Assert.AreEqual(_studyRoomBookingOne.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(_studyRoomBookingOne.LastName, bookingFromDb.LastName);
                Assert.AreEqual(_studyRoomBookingOne.Date, bookingFromDb.Date);
                Assert.AreEqual(_studyRoomBookingOne.StudyRoomId, bookingFromDb.StudyRoomId);
            }
        }

        [Test]
        [Order(2)]

        public void GetAllBooking_BookingOneAndTwo_CheckBothFromDatabase()
        {
            //arrange
            var expectedResult = new List<StudyRoomBooking> { _studyRoomBookingOne, _studyRoomBookingTwo };
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(_studyRoomBookingOne);
                repository.Book(_studyRoomBookingTwo);
            }

            //act
            List<StudyRoomBooking> actualResult;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualResult=repository.GetAll(null).ToList();
            }

            //assert

            CollectionAssert.AreEqual(expectedResult, actualResult, new BookingComparer());
        }
    }

    public class BookingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var bookingObj1 = (StudyRoomBooking)x;
            var bookingObj2 = (StudyRoomBooking)y;

            if (bookingObj1.BookingId != bookingObj2.BookingId)
            {
                return 1;
            }
            return 0;
        }
    }
}
