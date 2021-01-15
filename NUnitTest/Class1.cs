using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using WebApplication1.Controllers;
using System.Web.Mvc;

namespace NUnitTest
{
    public class Class1
    {
        Mock<ICityRepo<City>> mock;
        [SetUp]
        public void Init()
        {
            mock = new Mock<ICityRepo<City>>();
        }

        List<City> getSomeCities()
        {
            return new List<City>()
            {
                new City(){ Id=1,Name="Almaty"},
                new City(){ Id=1,Name="Aktobe"},
                new City(){ Id=1,Name="Astana"},
                new City(){ Id=1,Name="Karaganda"}
            };
        }

        [Test]
        public void Test_Index()//index
        {
            mock.Setup(z => z.getAll()).Returns(getSomeCities);
            CitiesController controller = new CitiesController(mock.Object);

            ViewResult result = controller.Index() as ViewResult;

            string myMessage = result.ViewBag.Message as string;
            object ob = result.ViewData["st"];

            Assert.IsNotNull(result.Model);
            Assert.Equals("Hello STEP", myMessage);
            Assert.AreEqual(3, (result.Model as List<City>).Count);
            Assert.IsInstanceOf<string>(ob);
            Assert.IsInstanceOf(typeof(string), ob);
        }
        [Test]
        public void Test_Create_Redirect()
        {
            City city = new City() { Id = 1, Name = "Astana123" };

            mock.Setup(z => z.Create(city)).Returns(city);

            CitiesController controller = new CitiesController(mock.Object);

            //controller.ModelState.AddModelError("Name", "some error");

            //ViewResult result = controller.Create() as ViewResult;

            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(city);
            Assert.IsInstanceOf<RedirectToRouteResult>(controller.Create(city));

            //Assert.AreEqual("Astana123", (result.Model as City).Name);

            //RedirectToRouteResult redirect_create = (RedirectToRouteResult)controller.Create();

            //controller.ModelState.AddModelError("Name", "some error");

            //

            Assert.IsInstanceOf<ViewResult>(controller.Create());
        }
        [Test]
        public void Test_Edit_Redirect()
        {
            City city = new City() { Id = 1, Name = "Astana123" };

            mock.Setup(z => z.Create(city)).Returns(city);

            CitiesController controller = new CitiesController(mock.Object);

            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(city.Id);
            Assert.IsInstanceOf<RedirectToRouteResult>(controller.Create(city));
        }
        [Test]
        public void Test_Delete_getById()
        {
            mock.Setup(z => z.getById(1)).Returns(getSomeCities().FirstOrDefault(z => z.Id == 1));

            CitiesController controller = new CitiesController(mock.Object);
            var city = controller.Delete(1) as ViewResult;

            Assert.AreEqual("Almaty", (city.Model as City).Name);
            Assert.IsAssignableFrom<ViewResult>(controller.Delete(1));
            Assert.IsInstanceOf<City>(city.Model);

            mock.Verify(z => z.getById(1));
        }


        //1. TDD
        //написать тест-метод, который должен завершиться успешно
        //этот тест-метод должен проверить метод, который по начальной букве города подсчитывал бы кол-во городов
        [Test]
        public void Test01___getCitiesByFirstLetters()
        {
            mock.Setup(z => z.getCitiesByFirstLetters("A")).Returns(getFoundCities().Where(z => z.Name.StartsWith("A")).ToList());

            CitiesController controller = new CitiesController(mock.Object);

            ViewResult result = controller.getCitiesByFirstLetters("A") as ViewResult;
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<IEnumerable<City>>(result.Model);
            Assert.AreEqual(3, (result.Model as List<City>).Count);
            Assert.IsTrue((result.Model as List<City>).All(z => z.Name.StartsWith("A")));
        }

        List<City> getFoundCities()
        {
            return getSomeCities().Where(z => z.Name.StartsWith("A")).ToList();
        }


        //2. Написать метод который определяет пересекаются ли два интервала между собой
        [Test]
        public void Test_IsIntersect()
        {
            List<int> first = new List<int>();
            List<int> second = new List<int>();
            first.Add(2);
            first.Add(8);
            second.Add(6);
            second.Add(10);

            Assert.IsTrue(IsIntersect(first, second));
            Assert.Greater(first.Last(), second.First());
        }
        public bool IsIntersect(List<int> first, List<int> second)
        {
            if (first.Last() >= second.First())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //3. Написать метод по определению входит ли точка с заданными координатами в параболу.
        [Test]
        public void Test_DotInAreaOfParabola()
        {
            //y=x^2
            //-2,4
            Assert.IsTrue(4 == Math.Pow(-2,2));
            //0,0
            Assert.IsTrue(0 == Math.Pow(0, 2));
            //-1,1
            Assert.IsTrue(1 == Math.Pow(-1, 2));
            //4,16
            Assert.AreEqual(16,Math.Pow(4,2));
            //5,25
            Assert.IsTrue(25 == Math.Pow(5, 2));
        }
    }
}
