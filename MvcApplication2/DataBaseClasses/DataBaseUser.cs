using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using MvcApplication2.Models;

namespace MvcApplication2.DataBaseClasses
{
    public class DataBaseUser
    {
        private DataBase dataBase = new DataBase();

        public User GetUserById(int id)
        {
           return dataBase.Users.SingleOrDefault(m => m.UserId == id);
        }

        //void UpdateOnId(int id)
        //{
        //    dataBase.Users.
        //}

        public void AddUser(User user)
        {
            dataBase.Users.Add(user);
            try
            {
                dataBase.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void EditUser(User user)
        {
            User oldUser = GetUserById(user.UserId);
            oldUser.Login = user.Login;
            oldUser.Email = user.Email;
            oldUser.Password = user.Password;
        }

        public User GetUserOnLogin(String login)
        {
            return dataBase.Users.SingleOrDefault(m => m.Login == login);
        }

        public User GetUserOnEmail(String email)
        {
            return dataBase.Users.SingleOrDefault(user => user.Email == email);
        }

        public bool IsExistsLogin(String login)
        {
            bool result;
            if (GetUserOnLogin(login) == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public bool IsExistsEmail(String email)
        {
            bool result;
            if (GetUserOnEmail(email) == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public bool PasswordIsCorrect(String login, String password)
        {
            bool result;
            User user = GetUserOnLogin(login);
            if (user != null)
            {
                if (user.Password == password)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public void SaveChanges()
        {
            dataBase.SaveChanges();
        }


        // GetUserOnActivateKey

        // SetActivateKeyOnId

        // RemoveActivateKeyOnId


    }
}