
namespace Subscriber.Service
{
    using Subscriber.DataContract;
    using System;

    public interface IProfileManager
    {
        Guid RegisterUserProfile(UserProfile profile);
    }
}
