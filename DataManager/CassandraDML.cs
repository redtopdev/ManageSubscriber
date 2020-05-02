/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Subscriber.DataManager
{
    internal class CassandraDML
    {
        internal static string InsertStatement = "INSERT INTO userprofile " +
            "(UserId, GCMClientId, ProfileName, ImageUrl,"+
                    "CountryCode, MobileNumber, IsDeleted, CreatedOn) " +
            "values " +
            "(?,?,?,?,?,?,?,?);";

        internal static string SelectAllUserProfiles = "SELECT UserId, CountryCode, MobileNumber from userprofile";
    }


}