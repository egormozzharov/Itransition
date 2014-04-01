using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class DataManager
    {
        public DataManager()
        {
            db = new DataBase();
        }

        private DataBase db;

        public IEnumerable<UserInfo> GetUsers()
        {
            return db.UserInfoes;
        }

        public String GetGender(UserInfo user)
        {
            String gender = "";
            if (true == user.Sex)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            return gender;
        }

        public UserInfo GetUserById(int id)
        {
            return db.UserInfoes.SingleOrDefault(user => user.Id == id);
        }

        public void UpdateUser(UserInfo user)
        {
            UserInfo oldUser = GetUserById(user.Id);
            oldUser.Name = user.Name;
            oldUser.SecondName = user.SecondName;
            oldUser.Sex = user.Sex;
            db.SaveChanges();
        }
    }
}