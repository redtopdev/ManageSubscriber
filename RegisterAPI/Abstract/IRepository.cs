/// <summary>
/// Developer: ShyamSk
/// </summary>
namespace RegisterAPI.Abstract
{
    using RegisterAPI.Models;

    /// <summary>
    /// Abstract Repo (BL)
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Register User Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        RegisterResponse RegisterUserProfile(UserProfile profile);
    }
}
