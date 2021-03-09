using KursiIm.Domain.Users;
using KursiIm.Domain.SeedWork;
using KursiIm.Infrastructure.SeedWork;
using KursiIm.SharedModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using KursiIm.Domain.KursiIm;

namespace KursiIm.Infrastructure.Users
{
    public class UserRepoService : IUserRepoService
    {
        private readonly IRepository<User> _userRepository;

        public UserRepoService(IRepository<User> userRepository)                         
        {
            _userRepository = userRepository;
        
        }

        public void Save(User _)
        {
            _userRepository.Add(_);
        }

        public User GetUserByUsername(string username) => _userRepository.ListByCriteria(t => t.Account == username && !t.IsDeleted).FirstOrDefault();

        public bool CheckUserAccount(string username, int? IdUser)
        {
            if (IdUser == null)
                return _userRepository.Any(t => t.Account == username);
            else
                return _userRepository.Any(t => t.Account == username && t.ID != IdUser);
        }
        public bool CheckUserEmail(string email, int? IdUser)
        {
            if (IdUser == null)
                return _userRepository.Any(t => t.EmailAddress == email);
            else
                return _userRepository.Any(t => t.EmailAddress == email && t.ID != IdUser);
        }
        public User GetUserById(int id) => _userRepository.GetSingleByCriteria(t => t.ID == id && !t.IsDeleted);
        public User GetUserByEmail(string email) => _userRepository.GetSingleByCriteria(t => t.EmailAddress == email && !t.IsDeleted);

        public User GetUserByUsernamePortal(string username) => _userRepository.ListByCriteria(t => t.Account == username && !t.IsDeleted, "IdroleNavigation").FirstOrDefault();
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.ListAll();
        }

        public IEnumerable<User> GetUsersWithInactive()
        {
           return _userRepository.ListByCriteria(t=>!t.IsDeleted);
        }

        public void UpdateUser(User _)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersWithCriteria(Expression<Func<User, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.ListByCriteria(x=>x.IsActive);
        }
    }
}
