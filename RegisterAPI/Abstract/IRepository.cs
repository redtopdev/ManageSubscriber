/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace RegisterAPI.Abstract
{
    using RegisterAPI.Models;
    using System;

    /// <summary>
    /// Abstract Repo (BL)
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Register User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>user Id</returns>
        Guid RegisterUserProfile(UserProfile profile);
    }
}
