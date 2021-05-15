using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Commercial_Adverts_Web_API.Model;

namespace Commercial_Adverts_Web_API.Models
{
    public class Commercial_Adverts_DataContext : DbContext
    {
        public Commercial_Adverts_DataContext (DbContextOptions<Commercial_Adverts_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Commercial_Adverts_Web_API.Model.CommercialDeal> CommercialDeal { get; set; }
    }
}
