using MovieShopDll.Entities;
using MovieShopDll.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll
{
    public class DllFacade
    {

        public IRepository<Genre> GetGenreRepository()
        {
            return new GenreRepository();
        }
        public IRepository<Movie> GetMovieRepository()
        {
            return new MovieRepository();
        }
        public IRepository<Customer> GetCustomerRepository()
        {
            return new CustomerRepository();
        }
        public IRepository<Order> GetOrderRepository()
        {
            return new OrderRepository();
        }
    }
}
