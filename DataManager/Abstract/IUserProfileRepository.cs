/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Subscriber.DataPersistance
{
    using Subscriber.DataContract;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// DataAcces Abstract
    /// </summary>
    public interface IUserProfileRepository
    {
        /// <summary>
        /// Save User Profile
        /// </summary>
        /// <param name="profile"></param>
        Task<Guid> SaveProfile(UserProfile profile);

        /// <summary>
        /// Get Registered UserIds 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<PhoneContact>> GetRegisteredUsers();

        /// <summary>
        /// get Gcm Client Ids
        /// </summary>
        /// <param name="userIds">list of userId</param>
        /// <returns>dictionary of userid and clientId</returns>
        Task<Dictionary<Guid, string>> GetGCMClientIds(IEnumerable<Guid> userIds);
    }
}
