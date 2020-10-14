using _1.Core.Domain;
using _2.Data.Repository;
using _2.Data.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3.Service.BusinessService
{
    internal interface IUserService
    {
        void Add(User user);
        void Delete(User user);
        void Delete(int userID);
        void Update(User user);
        User GetById(int userID);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllPaging(int page, int pageSize, out int totalRow);
        void SaveChanges();

    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public void Delete(int userID)
        {
            _userRepository.Delete(userID);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _userRepository.GetMultiPaging(x => x.IsActive, out totalRow, page, pageSize);
        }

        public User GetById(int userID)
        {
            return _userRepository.GetSingleById(userID);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            
        }
    }
}
