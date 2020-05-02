
namespace Subscriber.Service
{
    using Subscriber.DataContract;
    using System;
    using System.Threading.Tasks;

    public interface IProfileManager
    {
        Task<Guid> RegisterUserProfile(UserProfile profile);
    }
}
