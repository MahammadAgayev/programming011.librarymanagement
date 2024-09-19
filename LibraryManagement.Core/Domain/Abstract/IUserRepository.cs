using LibraryManagement.Core.Domain.Entities;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByUsername(string username);
    }
}
