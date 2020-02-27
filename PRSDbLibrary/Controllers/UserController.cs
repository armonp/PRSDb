using PRSDbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PRSDbLibrary.Controllers {
    public class UserController {
        private AppDbContext context { get; set; } = new AppDbContext();
        
        //GetAllUsers
        public IEnumerable<User> GetAllUsers() { 
            var users = context.Users.ToList();
            foreach (var u in users) {
                Console.WriteLine($"{u.Firstname} | {u.Lastname} | {u.Username} | {u.Phone} | {u.Email} | {u.IsAdmin} | {u.IsReviewer} ");
            }
            return users;    
        }
        //GetOneUser
        public User GetUserByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            var user = context.Users.Find(id);
            if (user == null) throw new Exception("User Not Found");
            else Console.WriteLine($"{user.Firstname} | {user.Lastname} | {user.Username} | {user.Phone} | {user.Email} | {user.IsAdmin} | {user.IsReviewer}");
            return user;
        }

        //Add User 
        public User AddUser(User user) { //will need to define new user in program class to be added
            if (user == null) throw new Exception("User cannot be null"); //classes can be null so need to check that null User isn't being passed
            context.Users.Add(user);
            try {
                context.SaveChanges();
            } catch(DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            Console.WriteLine($"{user.Firstname} added successfully !");
            return user;
        }
        //Update user
        public bool UpdateUser(int id, User user) {
            if (user == null) throw new Exception("User cannot be null");
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            context.Entry(user).State = EntityState.Modified; //alternate to finding user by id then changing each individual property
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        //Delete User
        public bool DeleteUser(int id) {
            if (id <= 0) throw new Exception("ID must be greater than zero");
            var user = context.Users.Find(id);
            if (user == null) throw new Exception("User not found");
            return Delete(user);
        }
        public bool Delete(User user) {
            context.Users.Remove(user);
            var recs = context.SaveChanges();
            if (recs != 1) throw new Exception("Delete failed");
            else Console.WriteLine("Delete successful");
            return true;
        }
        //Login
        public string Login(string username, string password) {
            var success = context.Users.Single(c => c.Username == username && c.Password == password);
            if (success == null)
                return ("Login Failed");
            else
                return ($"Welcome {success.Firstname}!");
        }

    }
}
