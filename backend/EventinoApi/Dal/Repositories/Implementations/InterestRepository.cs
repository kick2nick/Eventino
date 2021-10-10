using Dal.DbContext;
using Domain.Entities;
using System.Threading.Tasks;

namespace Dal.Repositories.Implementations
{
    internal class InterestRepository : GenericRepository<Interest>, IInterestRepository
    {
        public InterestRepository(EventinoDbContext context) : base(context)
        { }

        public Task<Interest> GetById(int id)
            => _context.Interests.FindAsync(id).AsTask();
    }
}
