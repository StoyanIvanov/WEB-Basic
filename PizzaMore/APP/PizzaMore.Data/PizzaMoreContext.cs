
namespace PizzaMore.Data
{
    using PizzaMore.Models;
    using System.Data.Entity;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
             : base("name=PizzaMoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }

    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}