using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkerPortal.Core;

namespace WorkerPortal.Data
{
    public class SQLUserData : IUserData
    {
        private readonly WorkerDbContext db;
        public SQLUserData(WorkerDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public User Delete(int userId)
        {
            User deleteUser = GetUserByUserId(userId);
            if(deleteUser != null)
            {
                db.Remove(deleteUser);
            }
            return deleteUser;
        }

        public User GetUserByUserId(int userId)
        {
            return db.Users.Find(userId);
        }

        public IEnumerable<User> GetUsersByUsername(string username)
        {
            var query = from u in db.Users where u.Username.StartsWith(username) || String.IsNullOrEmpty(username) orderby u.UserId
                        select u;
            return query;
        }

        public User NewUser(User user)
        {
            db.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            var entity = db.Users.Attach(user);
            entity.State = EntityState.Modified;
            return user;
        }
    }
}
