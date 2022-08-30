using GeekseatWitchSaga.Controllers;
using GeekseatWitchSaga.Data;
using GeekseatWitchSaga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestGeekseatWitchSaga
{
    public class MVCTest
    {
        public MVCTest()
        {
            InitContext();
        }

        private GeekseatWitchSagaContext _geekseatWitchSagaContext;
        private void InitContext()
        {
            var options = new DbContextOptionsBuilder<GeekseatWitchSagaContext>().UseInMemoryDatabase(databaseName: "MemoryDB_Geekseat").Options;
            var context = new GeekseatWitchSagaContext(options);

            var villagerList = Enumerable.Range(1, 2)
                                .Select(i => new VillagerData
                                {
                                    iAge = 10,
                                    iYear = 10 + (2 * i)
                                });
            context.VillagerData.AddRange(villagerList);
            int changed = context.SaveChanges();

            _geekseatWitchSagaContext = context;
        }

        [Fact]
        public async Task Index_ReturnsAViewResult()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);

            var result = await controller.Index();
            Assert.NotNull(result);

            var model = (List<VillagerData>)((ViewResult)result).Model;
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsAViewResult()
        {
            int id = 2;
            var controller = new VillagerController(_geekseatWitchSagaContext);

            var result = await controller.Details(id);
            Assert.NotNull(result);

            var model = (VillagerData)((ViewResult)result).Model;
            Assert.Equal(10, model.iAge);
            Assert.Equal(14, model.iYear);
        }
    }
}
