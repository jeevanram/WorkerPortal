using System.Collections.Generic;
using VoterPortal.Core;
using System.Linq;

namespace VoterPortal.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetUsersByUsername(string username);
        User GetUserByUserId(int userId);
        User UpdateUser(User user);
        int Commit();
    }

    public class InMemoryUserData : IUserData
    {
        readonly List<User> users;

        public InMemoryUserData()
        {
            users = new List<User>()
            {
                new User{ UserId=1,FirstName="User1 FN", LastName="User1 LN", Email="User1@email.com", Phone ="+91-1234567890", Address1="User1 Address1",Address2 = "User1 Address2", City="Chennai", State="TamilNadu", Country="India", PostalCode="600041", Username="user1" },
                new User{ UserId=2,FirstName="User2 FN", LastName="User2 LN", Email="User2@email.com", Phone ="+91-1234567890", Address1="User2 Address1",Address2 = "User2 Address2", City="Chennai", State="TamilNadu", Country="India", PostalCode="600042", Username="user2" },
                new User{ UserId=3,FirstName="User3 FN", LastName="User3 LN", Email="User3@email.com", Phone ="+91-1234567890", Address1="User3 Address1",Address2 = "User3 Address2", City="Chennai", State="TamilNadu", Country="India", PostalCode="600043", Username="user3" },
                new User{ UserId=4,FirstName="User4 FN", LastName="User4 LN", Email="User4@email.com", Phone ="+91-1234567890", Address1="User4 Address1",Address2 = "User4 Address2", City="Chennai", State="TamilNadu", Country="India", PostalCode="600044", Username="user4" },
                new User{ UserId=5,FirstName="User5 FN", LastName="User5 LN", Email="User5@email.com", Phone ="+91-1234567890", Address1="User5 Address1",Address2 = "User5 Address2", City="Chennai", State="TamilNadu", Country="India", PostalCode="600045", Username="user5" }
            };
        }
        public IEnumerable<User> GetUsersByUsername(string username)
        {
            return from u in users
                   where string.IsNullOrEmpty(username) || u.Username.Contains(username)
                   orderby u.UserId
                   select u;
        }

        public User GetUserByUserId(int userId)
        {
            return users.Where(usr => usr.UserId == userId).FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            User userToUpdate = users.Where(usr => usr.UserId == user.UserId).FirstOrDefault();
            if(userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.Phone = user.Phone;
                userToUpdate.Address1 = user.Address1;
                userToUpdate.Address2 = user.Address2;
                userToUpdate.City = user.City;
                userToUpdate.State = user.State;
                userToUpdate.Country = user.Country;
                userToUpdate.PostalCode = user.PostalCode;
            }
            return userToUpdate;
        }

        public int Commit()
        {
            return 0;
        }

    }
}
