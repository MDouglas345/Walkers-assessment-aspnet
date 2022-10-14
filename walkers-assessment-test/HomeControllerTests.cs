using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using NuGet.Frameworks;
using System.Runtime.InteropServices;
using walkers_assessment.Controllers;
using walkers_assessment.Models;

namespace walkers_assessment_test
{
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _logger;
        private readonly HomeController _controller;
        public HomeControllerTests()
        {
            _logger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_logger.Object);
        }

        [Fact]
        public void next_GoodDataExpectedBehavior()
        {
            var data = new ListDataModel { Entries = 40, PageOffset = 0 };

            var res = _controller.next(data);

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.PageOffset == 1);


        }

        [Fact]
        public void next_BadDataExpectedBehavior()
        {
            var data = new ListDataModel { Entries = 40, PageOffset = 1 };

            var res = _controller.next(data);

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.PageOffset == 1);


        }

        [Fact]
        public void prev_GoodDataExpectedBehavior()
        {
            var data = new ListDataModel { Entries = 40, PageOffset = 1 };

            var res = _controller.prev(data);

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.PageOffset == 0);


        }

        [Fact]
        public void prev_BadDataExpectedBehavior()
        {
            var data = new ListDataModel { Entries = 40, PageOffset = 0 };

            var res = _controller.prev(data);

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.PageOffset == 0);


        }

        [Fact]
        public void Index_ExpectedBehavior()
        {

            var res = _controller.Index();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);
        }

        [Fact]
        public void Step2_ExpectedBehavior()
        {

            var res = _controller.Step2();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);
        }

        [Fact]
        public void Index_MondayTrueExpectedBehavior()
        {
            HomeController.monday = true; 

            var res = _controller.Index();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.isMonday == true);
        }

        public void Index_MondayFalseExpectedBehavior()
        {
            HomeController.monday = false;

            var res = _controller.Index();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.isMonday == false);
        }

        [Fact]
        public void Step2_MondayTrueExpectedBehavior()
        {
            HomeController.monday = true;

            var res = _controller.Step2();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.isMonday == true);
        }

        public void Step2_MondayFalseExpectedBehavior()
        {
            HomeController.monday = false;

            var res = _controller.Step2();

            Assert.IsType<ViewResult>(res);
            Assert.IsType<ListDataModel>(((ViewResult)res).Model);

            ListDataModel newdata = (ListDataModel)((ViewResult)res).Model;

            Assert.True(newdata.isMonday == false);
        }
    }
}