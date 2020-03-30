/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.Abstract
{
    using RegisterAPI.Models;
    using System;

    /// <summary>
    /// DataAcces Abstract
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Save User Profile
        /// </summary>
        /// <param name="profile"></param>
        Guid SaveProfile(UserProfile profile);
    }
}
