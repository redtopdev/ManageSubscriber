/// <summary>
/// Developer: ShyamSk
/// </summary>

namespace RegisterAPI.DataAccess
{
    internal class CassandraDML
    {
        internal static string InsertStatement = "INSERT INTO userprofile " +
            "(UserId, GCMClientId, ProfileName, ImageUrl,"+
                    "CountryCode, MobileNumber, IsDeleted, CreatedOn) " +
            "values " +
            "(?,?,?,?,?,?,?,?);";
    }
}