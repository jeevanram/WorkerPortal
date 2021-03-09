using System.Collections.Generic;
using WorkerPortal.Core;
using System.Linq;

namespace WorkerPortal.Data
{
    public interface IUserData
    {
        IEnumerable<User> GetUsersByUsername(string username);
        User GetUserByUserId(int userId);
        User UpdateUser(User user);
        User NewUser(User user);
        User Delete(int userId);
        int Commit();
    } 
}
