using NUnit.Framework;
using DrugMicroservice.Controllers;
using DrugMicroservice.Models;
using DrugMicroservice.Repositories;
using System;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace NUnit_DrugMicroservice
{
    public class Testing_Drug
    {
        Drug obj;
        [SetUp]
        public void Setup()
        {
            obj = new Drug
            {
                DrugId = 1,
                Name = "Paracip-500",
                Manufacturer = "Mankind",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 09, 20),
                UnitCost = 5.00,
                LocQty = new Dictionary<string, int>()
                {
                    {"Pune",50 },
                    {"Bangalore",80 },
                    {"Chennai",60 }
                }
            };
        }

        [Test]
        public void DrugByID_Valid_DrugDetails()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.searchDrugsByID(1)).Returns(obj);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetails(1) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        [Test]
        public void DrugByID_InValid_DrugDetails()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.searchDrugsByID(7)).Returns(obj);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetails(17) as NotFoundResult;
            Assert.AreEqual(404, data.StatusCode);    
        }
        [Test]
        public void DrugByName_Valid_DrugDetails()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.searchDrugsByName("Paracip-500")).Returns(obj);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetailByName("Paracip-500") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }
        [Test]
        public void DrugByName_InValid_DrugDetails()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.searchDrugsByName("Acilo")).Returns(obj);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetailByName("Aciloc") as NotFoundResult;
            Assert.AreEqual(404, data.StatusCode);

        }
        [Test]
        public void DrugByNameLoc_Valid()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.getLocationQty("Paracip-500", "Pune")).Returns(50);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.getDrugStockByLoc("Paracip-500", "Pune") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]
        public void DrugByNameLoc_Invalid()
        {
            var mock = new Mock<DrugRepository>();
            mock.Setup(p => p.getLocationQty("Paracip-500", "Pune")).Returns(50);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.getDrugStockByLoc("Paracip-500", "Kolkata") as NotFoundResult;
            Assert.AreEqual(404, data.StatusCode);
        }
    }
}