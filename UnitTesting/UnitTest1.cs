using NUnit.Framework;
using EnterpriseProgrammingAssignment.Controllers;
using EnterpriseProgrammingAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using System.Collections.Generic;

namespace UnitTesting
{
    public class CarControllerTests
    {

        [Test]
        public void CarController_Index()
        {
            var sites = new List<Site>
            {
                new Site{ID=1,Address="stuff",PostCode="12",ContactNum="0123",Email="email@em.cm",ManagerName="Admin"}
            };
            var cars = new List<Car>
            {
                new Car{ID=1,Make="Ford",Model="Transit",Category=Category.N,PurchaseDate=DateTime.Today,InsuranceExpDate=DateTime.Today,MOTExpDate=DateTime.Today,TaxExpDate=DateTime.Today,SiteID=1}
            };
            var controller = new CarsController(cars);
            var result = controller.Index(SortOrder:"",SearchParam:"");
            
        }
    }
}