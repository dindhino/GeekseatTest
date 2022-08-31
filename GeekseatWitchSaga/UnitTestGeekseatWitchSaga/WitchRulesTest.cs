using GeekseatWitchSaga.Controllers;
using GeekseatWitchSaga.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestGeekseatWitchSaga
{
    public class WitchRulesTest
    {
        public WitchRulesTest()
        {
            InitContext();
        }

        private GeekseatWitchSagaContext _geekseatWitchSagaContext;
        private void InitContext()
        {
            var options = new DbContextOptionsBuilder<GeekseatWitchSagaContext>().UseInMemoryDatabase(databaseName: "MemoryDB_Geekseat").Options;
            _geekseatWitchSagaContext = new GeekseatWitchSagaContext(options);
        }

        [Fact]
        public void WitchRules_Index_0()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(0, controller.WitchRules(0));
        }

        [Fact]
        public void WitchRules_Index_1()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(1, controller.WitchRules(1));
        }

        [Fact]
        public void WitchRules_Index_2()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(1, controller.WitchRules(2));
        }

        [Fact]
        public void WitchRules_Index_3()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(2, controller.WitchRules(3));
        }

        [Fact]
        public void WitchRules_Index_4()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(3, controller.WitchRules(4));
        }

        [Fact]
        public void WitchRules_Index_5()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(5, controller.WitchRules(5));
        }

        [Fact]
        public void WitchRules_Index_6()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(8, controller.WitchRules(6));
        }

        [Fact]
        public void WitchRules_Index_7()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(13, controller.WitchRules(7));
        }

        [Fact]
        public void WitchRules_Index_8()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(21, controller.WitchRules(8));
        }

        [Fact]
        public void WitchRules_Index_9()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(34, controller.WitchRules(9));
        }

        [Fact]
        public void WitchRules_Index_10()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(55, controller.WitchRules(10));
        }

        [Fact]
        public void WitchRules_Index_False()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(0, controller.WitchRules(-110));
        }

        [Fact]
        public void GetNumberOfKilledVillagerInYear_Year_1()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(1, controller.GetNumberOfKilledVillagerInYear(1));
        }

        [Fact]
        public void GetNumberOfKilledVillagerInYear_Year_2()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(2, controller.GetNumberOfKilledVillagerInYear(2));
        }

        [Fact]
        public void GetNumberOfKilledVillagerInYear_Year_3()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(4, controller.GetNumberOfKilledVillagerInYear(3));
        }

        [Fact]
        public void GetNumberOfKilledVillagerInYear_Year_4()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(7, controller.GetNumberOfKilledVillagerInYear(4));
        }

        [Fact]
        public void GetNumberOfKilledVillagerInYear_Year_5()
        {
            var controller = new VillagerController(_geekseatWitchSagaContext);
            Assert.Equal(12, controller.GetNumberOfKilledVillagerInYear(5));
        }
    }
}
