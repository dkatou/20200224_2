using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.ApiModel.Models;

namespace Api.ApiModel.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Api.ApiModel.Models.TestModel> TestModel { get; set; }
    }
}
