using PRSDbLibrary.Controllers;
using PRSDbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRSDb {
    class Program {
        static void Main(string[] args) {
            //var context = new AppDbContext();
            var UserCtrl = new UserController();
            //UserCtrl.AddUser("admin", "admin1", "Armon", "Porter", "9375130000", "email@email.com", true, true);
            //UserCtrl.AddUser("test", "test", "test", "this", "isgoing", "tobedeleted", false, false);
            //UserCtrl.DeleteUser(2);
            UserCtrl.GetUserByPk(1);
            //UserCtrl.GetAllUsers();
         

        }

    }
}
