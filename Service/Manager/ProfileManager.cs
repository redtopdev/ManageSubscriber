
namespace Subscriber.Service
{
    using System;
    using System.Threading.Tasks;
    using Subscriber.DataContract;
    using Subscriber.DataPersistance;

    public class ProfileManager : IProfileManager
    {
        private IUserProfileRepository repo;
        public ProfileManager(IUserProfileRepository repo)
        {
            this.repo = repo;
        }
        public async Task<Guid> RegisterUserProfile(UserProfile profile)
        {
            //put some validation, can throw http exception like bad request if request is invalid
            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return await repo.SaveProfile(profile);
        }
    }
}
