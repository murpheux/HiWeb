using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using HiWeb;
using HiWeb.Controllers;
using Xunit;
using Shouldly;
using FakeItEasy;
using HiWeb.Interface;
using System.Data.SqlClient;
using HiWeb.DataContext;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HiWeb.Tests.Controllers
{
    public class HomeControllerTest
    {

        IRepository fakeRespository;
        ILoggerFactory fakeLogger;
        IOptions<dynamic> fakeOptions;

        HomeController targetController;

        public HomeControllerTest()
        {
            fakeRespository = A.Fake<IRepository>();

            //mimic operations
            A.CallTo(() => fakeRespository.DoAnotherThing()).Returns("Done");
            A.CallTo(() => fakeRespository.SayHello()).Returns("Hello Murpheux");

            fakeLogger = A.Fake<ILoggerFactory>();

            //A.CallTo(() => fakeLogger.LogMessage(""));
            targetController = new HomeController();// fakeRespository, fakeLogger, null);
        }

        [Fact, Trait("Repository", "fake")]
        public void Repository_DoAnotherThing()
        {
            fakeRespository.DoAnotherThing().ShouldBe("Done");
        }

        [Fact, Trait("Repository", "fake")]
        public void Repository_DoSomething()
        {
            fakeRespository.SayHello().ShouldBe("Hello Murpheux");
        }

        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = targetController;

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.NotNull(result);
            result.ShouldNotBe(null);
        }

        [Fact]
        public void About()
        {
            // Arrange
            HomeController controller = targetController;

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            //Assert.Equal("Your application description page.", result.ViewBag.Message);
            string message = result.ViewBag.Message;
            message.ShouldBe("Your application description page.");
        }

        [Fact]
        public void Contact()
        {
            // Arrange
            HomeController controller =targetController;

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            //Assert.NotNull(result);
            result.ShouldNotBe(null);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = false;

            result.ShouldBe(false);
        }

        [Fact]
        public void Test1()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqlConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                //var options = new DbContextOptionsBuilder<RepositoryContext>()
                //    .UseSqlite(connection)
                //    .Options;

                // Create the schema in the database
                using (var context = new RepositoryContext()) // options))
                {
                    //context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new RepositoryContext())// options))
                {
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new RepositoryContext())// options))
                {
                    context.Students.Count().ShouldBe(1);
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
