using Domain.Entities;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public interface IInterestRepository : IAsyncRepository<Interest>
    {
        public Task<Interest> GetById(int id);
    }
}
