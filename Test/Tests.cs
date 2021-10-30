using NUnit.Framework;
using Model;
using System.Collections.Generic;
using DataAccess;
using Moq;
namespace Test
{
    public class I_Made_Only_One_Class_Because_MS_Test_Needs_2_Minutes_Flat_Per_File_Because_Why_Bother_Making_Things_Performant_Amirite
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void dateFromString_Test_Fail()
        {
            Date date=Date.fromString("32.-1.0");
            Assert.IsFalse(date.valid);
        }
        [Test]

        public void dateFromString_Test_Pass()
        {
            Date date = Date.fromString("10.12.1994");
            Assert.AreEqual(10,date.day);
            Assert.AreEqual(12,date.month);
            Assert.AreEqual(1994,date.year);
        }
        [Test]
        public void dateToString_Test_Fail()
        {
            Date date = new Date(10,-1,1994);
            Assert.AreEqual("", date.ToString());
        }
        [Test]

        public void dateToString_Test_Pass()
        {
            Date date = new Date(10, 12, 1994);
            Assert.AreEqual("10.12.1994", date.ToString());
        }
        [Test]
        public void LogStrings_Test_Fail()
        {
            Model.Log log = new Model.Log("Title",1f,null,null,"Report",-1,-1,-1,-1);
            Assert.AreEqual(null, log.averageSpeedString);
            Assert.AreEqual(null, log.caloriesString);
            Assert.AreEqual(null, log.dateString);
            Assert.AreEqual(null, log.ratingString);
            Assert.AreEqual(null, log.topSpeedString);
        }
        [Test]
        public void LogStrings_Test_Pass()
        {
            Model.Log log = new Model.Log("Title", 1f, null, null, "Report", 2, 3f, 4f, 4);
            Assert.NotNull(log.averageSpeedString);
            Assert.NotNull(log.caloriesString);
            Assert.AreEqual("2/5", log.ratingString);
            Assert.NotNull(log.topSpeedString);
        }
        [Test]
        public void TourConversionDA2Model_Test()
        {
            var converter = new DataAccessModelConverter();
            DataAccess.Tour tourDA = new DataAccess.Tour("TourName", 1, "Staring Location", 2, 3, "Ending Location", 4, 5, 6, "Route Description", "Route Information");
            
            Model.Tour tourModel=converter.tourModel(tourDA);

            Assert.AreEqual("TourName", tourModel.name);
            Assert.AreEqual(1, tourModel.distance);
            Assert.AreEqual("Staring Location", tourModel.startLocation);
            Assert.AreEqual("Ending Location", tourModel.endLocation);
            Assert.AreEqual("Route Description", tourModel.routeDescription);
            Assert.AreEqual("Route Information", tourModel.routeInformation);
        }
        [Test]
        public void findTourModel_Test()
        {
            var converter = new DataAccessModelConverter();
            List<Model.ITour> tourListModel = new List<Model.ITour>();
            tourListModel.Add(new Model.Tour("Tour Name1",null,null,0,null,null));
            tourListModel.Add(new Model.Tour("Tour Name2",null,null,0,null,null));
            tourListModel.Add(new Model.Tour("Tour Name3",null,null,0,null,null));
            List<DataAccess.ITour> tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Tour Name1",0,null,0,0,null,0,0,3,null,null));
            tourListDA.Add(new DataAccess.Tour("Tour Name2",0,null,0,0,null,0,0,6,null,null));
            tourListDA.Add(new DataAccess.Tour("Tour Name3",0,null,0,0,null,0,0,9,null,null));



            Model.ITour tour = converter.findTourModel(6,tourListDA,tourListModel);

            Assert.AreEqual(tourListModel[1], tour);
        }
        [Test]
        public void convertLogList2Model_Test()
        {
            //-R Mock findtourmodel
            var converter = new DataAccessModelConverter();
            List<Model.ITour> tourListModel = new List<Model.ITour>();
            tourListModel.Add(new Model.Tour("Tour Name1", null, null, 0, null, null));
            tourListModel.Add(new Model.Tour("Tour Name2", null, null, 0, null, null));
            tourListModel.Add(new Model.Tour("Tour Name3", null, null, 0, null, null));
            List<DataAccess.ITour> tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Tour Name1", 0, null, 0, 0, null, 0, 0, 3, null, null));
            tourListDA.Add(new DataAccess.Tour("Tour Name2", 0, null, 0, 0, null, 0, 0, 6, null, null));
            tourListDA.Add(new DataAccess.Tour("Tour Name3", 0, null, 0, 0, null, 0, 0, 10, null, null));
            List<DataAccess.ILog> logListDA = new List<DataAccess.ILog>();
            logListDA.Add(new DataAccess.Log(1,"Title",6,null,0,0,0,0,0,null));
            logListDA.Add(new DataAccess.Log(2,"Title",10,null,0,0,0,0,0,null));
            logListDA.Add(new DataAccess.Log(3,"Title",10,null,0,0,0,0,0,null));
            logListDA.Add(new DataAccess.Log(3,"Title",12,null,0,0,0,0,0,null));
            var logListModel=converter.logListModel(logListDA, tourListDA, tourListModel);
            
            Assert.AreEqual(3,logListModel.Count);
            Assert.AreEqual(tourListModel[1], logListModel[0].tour);
        }
        [Test]
        public void tourNameFromID_Test_Pass()
        {
            Repository repository = Repository.address;
            var tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1", 0, null, 0, 0, null, 0, 0, 7));
            tourListDA.Add(new DataAccess.Tour("Name2", 0, null, 0, 0, null, 0, 0, 8));
            tourListDA.Add(new DataAccess.Tour("Name3", 0, null, 0, 0, null, 0, 0, 3));

            string name = repository.tourNameFromID(tourListDA, 3);

            Assert.AreEqual("Name3", name);
        }
        [Test]
        public void tourNameFromID_Test_NullValues()
        {
            Repository repository = Repository.address;
            var tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1", 0, null, 0, 0, null, 0, 0, 7));
            tourListDA.Add(null);
            tourListDA.Add(new DataAccess.Tour("Name3", 0, null, 0, 0, null, 0, 0, 3));

            string name = repository.tourNameFromID(tourListDA, 3);

            Assert.AreEqual("Name3", name);
        }

        [Test]
        public void tourIDFromName_Test_Pass() {
            Repository repository = Repository.address;
            var tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1", 0, null, 0, 0, null, 0, 0, 7));
            tourListDA.Add(new DataAccess.Tour("Name2", 0, null, 0, 0, null, 0, 0, 8));
            tourListDA.Add(new DataAccess.Tour("Name3", 0, null, 0, 0, null, 0, 0, 3));

            int id = repository.tourIDFromName(tourListDA, "Name2");

            Assert.AreEqual(8, id);
        }
        [Test]
        public void tourIDFromName_Test_NullValues() {
            Repository repository = Repository.address;
            var tourListDA = new List<DataAccess.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1", 0, null, 0, 0, null, 0, 0, 7));
            tourListDA.Add(null);
            tourListDA.Add(new DataAccess.Tour("Name3", 0, null, 0, 0, null, 0, 0, 3));

            int id = repository.tourIDFromName(tourListDA, "Name3");

            Assert.AreEqual(3,id);
        }
        [Test]
        public void logFromName_Test_Pass() {
            Repository repository = Repository.address;
            var logListDA = new List<DataAccess.ILog>();
            logListDA.Add(new DataAccess.Log(1,"Name1",0, null,0,0,0,0,0,null));
            logListDA.Add(new DataAccess.Log(2,"Name2",0, null,0,0,0,0,0,null));
            logListDA.Add(new DataAccess.Log(3,"Name3",0, null,0,0,0,0,0,null));

            DataAccess.ILog log = repository.logFromName(logListDA, "Name3");

            Assert.AreEqual(3, log.id);
        }
        [Test]
        public void logIDFromName_Test_NullValues() {
            Repository repository = Repository.address;
            var logListDA = new List<DataAccess.ILog>();
            logListDA.Add(new DataAccess.Log(1, "Name1", 0, null, 0, 0, 0, 0, 0, null));
            logListDA.Add(null);
            logListDA.Add(new DataAccess.Log(3, "Name3", 0, null, 0, 0, 0, 0, 0, null));

            DataAccess.ILog log = repository.logFromName(logListDA, "Name3");

            Assert.AreEqual(3, log.id);
        }

        [Test]
        public void logNameFromID_Test_Pass() {
            Repository repository = Repository.address;
            var logListDA = new List<DataAccess.ILog>();
            logListDA.Add(new DataAccess.Log(1, "Name1", 0, null, 0, 0, 0, 0, 0, null));
            logListDA.Add(new DataAccess.Log(2, "Name2", 0, null, 0, 0, 0, 0, 0, null));
            logListDA.Add(new DataAccess.Log(3, "Name3", 0, null, 0, 0, 0, 0, 0, null));

            int id = repository.logIdFromName(logListDA, "Name3");

            Assert.AreEqual(3, id);
        }
        [Test]
        public void logNameFromID_Test_NullValues() {

            Repository repository = Repository.address;
            var logListDA = new List<DataAccess.ILog>();
            logListDA.Add(new DataAccess.Log(1, "Name1", 0, null, 0, 0, 0, 0, 0, null));
            logListDA.Add(null);
            logListDA.Add(new DataAccess.Log(3, "Name3", 0, null, 0, 0, 0, 0, 0, null));
            
            int id = repository.logIdFromName(logListDA, "Name3");

            Assert.AreEqual(3, id);
        }
        [Test]
        public void repositoryInsertTour_Pass()
        {
            Repository repository = Repository.address;
            var mapquest = new Mock<IMapquest>();
            var imageLoader = new Mock<IImageLoader>();
            var dataManager = new Mock<IDataManager>();
            float[] coords = { 3.14f, 4.14f, 2, 3 }; 
            mapquest.Setup(x => x.namesToCoord(It.IsAny<string[]>())).ReturnsAsync(coords);
            repository.dataManager = dataManager.Object;
            repository.imageLoader = imageLoader.Object;
            repository.mapquest = mapquest.Object;
            
            repository.addTour("Tour Name","Tour Description", "Tour Information", "Start Location", "End Location");

            Assert.AreEqual(3.14f, repository.tourListDB[0].sl_x);
            Assert.AreEqual(4.14f, repository.tourListDB[0].sl_y);
            Assert.AreEqual(2, repository.tourListDB[0].el_x);
            Assert.AreEqual(3, repository.tourListDB[0].el_y);
            Assert.AreEqual("Tour Name",repository.tourList[0].name);
        }
        [Test]
        public void repositoryInsertTour_Fail()
        {
            Repository repository = Repository.address;
            var mapquest = new Mock<IMapquest>();
            var imageLoader = new Mock<IImageLoader>();
            var dataManager = new Mock<IDataManager>();
            float[] coords = { 0, 1, 2, 3 };
            mapquest.Setup(x => x.namesToCoord(It.IsAny<string[]>())).ReturnsAsync((float[])null);
            repository.dataManager = dataManager.Object;
            repository.imageLoader = imageLoader.Object;
            repository.mapquest = mapquest.Object;

            repository.addTour("Tour Name", "Tour Description", "Tour Information", "Start Location", "End Location");

            Assert.AreEqual(0, repository.tourListDB.Count);
            Assert.AreEqual(0, repository.tourList.Count);
        }
        [Test]
        public void repositoryDeleteTour_Pass()
        {
            Repository repository = Repository.address;
            var mapquest = new Mock<IMapquest>();
            var imageLoader = new Mock<IImageLoader>();
            var dataManager = new Mock<IDataManager>();
            float[] coords = { 0, 1, 2, 3 };
            repository.dataManager = dataManager.Object;
            repository.imageLoader = imageLoader.Object;
            repository.mapquest = mapquest.Object;
            var tourListDA = new List<DataAccess.ITour>();
            var tourListModel = new List<Model.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1",0,null,0,0,null,0,0));
            tourListModel.Add(new Model.Tour("Name1",null,null,0,null,null));
            repository.GetType().GetProperty("tourList").SetValue(repository, tourListModel);
            repository.GetType().GetProperty("tourListDB").SetValue(repository, tourListDA);

            repository.removeTour(0);

            Assert.AreEqual(0, repository.tourListDB.Count);
            Assert.AreEqual(0, repository.tourList.Count);
        }
        [Test]
        public void repositoryDeleteTour_Fail()
        {
            Repository repository = Repository.address;
            var mapquest = new Mock<IMapquest>();
            var imageLoader = new Mock<IImageLoader>();
            var dataManager = new Mock<IDataManager>();
            float[] coords = { 0, 1, 2, 3 };
            repository.dataManager = dataManager.Object;
            repository.imageLoader = imageLoader.Object;
            repository.mapquest = mapquest.Object;
            var tourListDA = new List<DataAccess.ITour>();
            var tourListModel = new List<Model.ITour>();
            tourListDA.Add(new DataAccess.Tour("Name1", 0, null, 0, 0, null, 0, 0));
            tourListModel.Add(new Model.Tour("Name1", null, null, 0, null, null));
            repository.GetType().GetProperty("tourList").SetValue(repository, tourListModel);
            repository.GetType().GetProperty("tourListDB").SetValue(repository, tourListDA);

            repository.removeTour(1);

            Assert.AreEqual(1, repository.tourListDB.Count);
            Assert.AreEqual(1, repository.tourList.Count);
        }
        [Test] //-R 
        public void repositoryAddLog_Pass()
        {

        }
        [Test]//-R 
        public void repositoryAddLog_Fail()
        {

        }
        [Test]//-R 
        public void repositoryDeleteLog_Pass()
        {

        }
        [Test]//-R 
        public void repositoryDeleteLog_Fail()
        {

        }

    }
}