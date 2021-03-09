using KursiIm.Domain.KursiIm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KursiIm.Domain.Users
{
    public interface IUserRepoService
    {
        void Save(User _);
        void UpdateUser(User _);
        User GetUserByUsername(string username);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        IEnumerable<User> GetUsersWithCriteria(Expression<Func<User, bool>> criteria);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUsersWithInactive();
        User GetUserByUsernamePortal(string username);
    }
}
