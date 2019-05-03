using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sem_IMTA_Restaurace.Models;
using Sem_IMTA_Restaurace.Services;

namespace Sem_IMTA_Restaurace.UnitTest.Services
{
    [TestClass]
    public class RestaurantApiTest
    {
        private IRestaurantApi api;

        [TestInitialize]
        public void Initialize()
        {
            api = new RestaurantApi();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetRestaurantsByCityTest()
        {
            IEnumerable<Restaurant> restaurants = api.GetRestaurantsByCity("Pardubice");

            Assert.AreEqual(restaurants.First().Id, "16513985");
        }

        [TestMethod]
        public void GetRestaurantsByLocationTest()
        {
            IEnumerable<Restaurant> restaurants = api.GetRestaurantsByLocation("50.0500", "15.7750");

            Assert.AreEqual(restaurants.First().Id, "18213921");
        }
    }
}
