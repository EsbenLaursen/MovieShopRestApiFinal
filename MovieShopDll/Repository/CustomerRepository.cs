using MovieShopDll.Entities;
using MyMovieShopAdmin.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Repository
{
    internal class CustomerRepository : AbstractRepository<Customer>
    {
        public override List<Customer> Read(MovieShopDBContext ctx)
        {
            return ctx.Customer.Include("Orders").ToList();
        }

        public override Customer Read(MovieShopDBContext ctx, int id)
        {
            return ctx.Customer.Include("Orders").FirstOrDefault(x => x.Id == id);
        }

        public override Customer Create(MovieShopDBContext ctx, Customer t)
        {
            ctx.Customer.Add(t);
            ctx.SaveChanges();
            return t;
        }

        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Customer o = ctx.Customer.FirstOrDefault(x => x.Id == id);
            ctx.Entry(o).State = EntityState.Deleted;
            ctx.SaveChanges();
            return true;
        }

        public override Customer Update(MovieShopDBContext ctx, Customer c)
        {
            ctx.Entry(c).State = EntityState.Modified;
            ctx.SaveChanges();
            return c;
        }
    }
}
