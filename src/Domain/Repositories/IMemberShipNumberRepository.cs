using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMemberShipNumberRepository
    {
        void Add(MemberShipNumber memberShipNumber);
        Task<Vehicle?> GetMemberShipNumberByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
