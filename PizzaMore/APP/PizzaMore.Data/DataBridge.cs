using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Models;

namespace PizzaMore.Data
{
    public static class DataBridge
    {
        private static PizzaMoreContext context=new PizzaMoreContext();

        public static Session GetSessionById(string sessionId)
        {
            int value;
            if (int.TryParse(sessionId, out value))
            {
                return context.Sessions.FirstOrDefault(session => session.User.Id == value);
            }

            return null;

        }

        public static bool IsUserExist(string username, string password)
        {
            try
            {
                if (context.Users.Count(user => user.Email == username && user.Password == password) > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
          
            return false;
        }

        public static void CreateUser(string username, string password)
        {

            using (context)
            {
                User user = new User();
                user.Email = username;
                user.Password = password;
                context.Users.Add(user);
                context.SaveChanges();
            }
            
        }

        public static User LogInUser(string username, string password)
        {
            if (context.Users.Count(user=>user.Email==username && user.Password==password)>0)
            {
                return context.Users.FirstOrDefault(user => user.Email == username && user.Password == password);
            }

            return null;
        }

        public static void AddSession(Session session)
        {
            context.Sessions.Add(session);
        }

        public static void SaveChanges()
        {
            using (context)
            {
                context.SaveChanges();
            }
        }

        public static Pizza GetPizzaById(int id)
        {
            return context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }

        public static List<Pizza> GetAllPizzas()
        {
            return context.Pizzas.ToList();
        }


        public static void DeletePizzaById(int id)
        {
            var pizzaEntity = context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
            context.Pizzas.Remove(pizzaEntity);
            context.SaveChanges();
        }

        public static List<Pizza> GetPizzasByOwnerId(int id)
        {
            return context.Pizzas.Where(pizza => pizza.OwnerId == id).ToList();
        }
    }
}
