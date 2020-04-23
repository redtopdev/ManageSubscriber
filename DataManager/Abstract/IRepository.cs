/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Register.DataManager
{
    using Register.DataContract;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DataAcces Abstract
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Save User Profile
        /// </summary>
        /// <param name="profile"></param>
        Guid SaveProfile(UserProfile profile);

        /// <summary>
        /// Get Registered UserIds 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<PhoneContact> GetRegisteredUsers();
    }
}
