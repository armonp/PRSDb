using PRSDbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PRSDbLibrary.Controllers {
    public class UserController {
        private AppDbContext context { get; set; } = new AppDbContext();
        
           
        //GetAllUsers
        public List<User> GetAllUsers() {
            //var context = new AppDbContext();
            var users = context.Users.ToList();
            foreach (var u in users) {
                Console.WriteLine($"{u.Firstname} | {u.Lastname} | {u.Username} | {u.Phone} | {u.Email} | {u.IsAdmin} | {u.IsReviewer} ");
            }
            return users;    
        }
        //GetOneUser
        public User GetUserByPk(int id) {
            var user = context.Users.Find(id);
            if (user == null) throw new Exception("User Not Found");
            else return user;
            //Console.WriteLine($"{user.Firstname} | {user.Lastname} | {user.Username} | {user.Phone} | {user.Email} | {user.IsAdmin} | {user.IsReviewer}");
        }

        //Add User 
        public void AddUser(string username, string password, string firstname, string lastname, string phone, string email, bool reviewer, bool admin) {
            var user = new User {
                Id = 0, Username = username,
                Password = password, Firstname = firstname,
                Lastname = lastname, Phone = phone,
                Email = email, IsAdmin = false, IsReviewer = false
            };
            context.Users.Add(user);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Add failed"); else Console.WriteLine($"{user.Firstname} added successfully !");
        }
        //Update user
        public void UpdateUser(int id, string username, string password, string firstname, string lastname, string phone, string email, bool reviewer, bool admin) {
            var user = GetUserByPk(id);
            user.Firstname = firstname; user.Username = username;
            user.Lastname = lastname; user.Password = password;
            user.Phone = phone; user.Email = email;
            user.IsReviewer = reviewer; user.IsAdmin = admin;
        }
        //Delete User
        public void DeleteUser(int id) {
            var user = context.Users.Find(id);
            if (user == null) throw new Exception("User not found");
            context.Users.Remove(user);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
        }

    }
}
