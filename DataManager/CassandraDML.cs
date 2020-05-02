/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace Subscriber.DataPersistance
{
    internal class CassandraDML
    {
        internal static string InsertStatement = "INSERT INTO userprofile " +
            "(UserId, GCMClientId, ProfileName, ImageUrl,"+
                    "CountryCode, MobileNumber, IsDeleted, CreatedOn) " +
            "values " +
            "(?,?,?,?,?,?,?,?);";

        internal static string SelectAllUserProfiles = "SELECT UserId, CountryCode, MobileNumber from userprofile";

        internal static string selectGcmClientIdsByUserIds = "select userid, gcmclientid from UserProfile where userid in ({0});";
    }


}