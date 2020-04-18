
namespace Register.Service
{
    using Register.DataContract;
    using System;

    public interface IProfileManager
    {
        Guid RegisterUserProfile(UserProfile profile);
    }
}
