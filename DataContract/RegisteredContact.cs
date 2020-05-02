
using System;

namespace Subscriber.DataContract
{
    public class RegisteredContact
    {
        public Guid UserId { get; set; }
        public string MobileNumberStoredInRequestorPhone { get; set; }
    }
}
