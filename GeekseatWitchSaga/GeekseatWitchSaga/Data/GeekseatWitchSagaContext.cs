using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeekseatWitchSaga.Models;

namespace GeekseatWitchSaga.Data
{
    public class GeekseatWitchSagaContext : DbContext
    {
        public GeekseatWitchSagaContext (DbContextOptions<GeekseatWitchSagaContext> options)
            : base(options)
        {
        }

        public DbSet<GeekseatWitchSaga.Models.VillagerData> VillagerData { get; set; }
    }
}
