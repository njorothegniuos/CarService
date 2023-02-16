using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMemberShipNumberRepository
    {
        void Add(MemberShipNumber memberShipNumber);
        Task<MemberShipNumber?> GetMemberShipNumberByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
