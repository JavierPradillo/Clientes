using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clientes.Models
{
    public class ClientesEntities : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}