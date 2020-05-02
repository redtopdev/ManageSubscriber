
namespace Subscriber.Service
{
    using System;

    using Subscriber.DataContract;
    using Subscriber.DataManager;
    
    public class ProfileManager : IProfileManager
    {
        private IRepository repo;
       public ProfileManager(IRepository repo)
        {
            this.repo = repo;
        }
        public Guid RegisterUserProfile(UserProfile profile)
        {
            //put some validation, can throw http exception like bad request if request is invalid
            //put try catch only when you want to return custom message or status code, else this will
            //be caught in ExceptionHandling middleware so no need to put try catch here

            return repo.SaveProfile(profile);
        }
    }
}
