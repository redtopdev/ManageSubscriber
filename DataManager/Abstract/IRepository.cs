/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Register.DataManager
{
    using Register.DataContract;
    using System;

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
    }
}
