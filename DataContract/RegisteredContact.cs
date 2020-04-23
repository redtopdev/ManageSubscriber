
using System;

namespace Register.DataContract
{
    public class RegisteredContact
    {
        public Guid UserId { get; set; }
        public string MobileNumberStoredInRequestorPhone { get; set; }
    }
}
