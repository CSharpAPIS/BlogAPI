
namespace BlogAPI.Core.Security
{
    /// <summary>
    /// Defines permission of a user.
    /// </summary>
    /// <example>
    /// 
    /// making a combination
    /// check if an enumeration is part of a combination
    /// var isTodayMondayOrTuesday = ((today & (MyDays.Monday | MyDays.Tuesday)) != 0); // returns false
    /// </example>
    [Flags]
    public enum UserPermission
    {
        /// <summary>
        /// This permission is for the API requests that don't have
        /// an auth token set.
        /// </summary>
        NotRegistered           = 000,
        /// <summary>
        /// Basic permission for accessing most basic stuff.
        /// This is the default permission for every user that's created
        /// inside of the API.
        /// </summary>
        BasicPermission         = 1 << 0,
        /// <summary>
        /// Permission of an average user. This user can view more blogs and/or
        /// posts compared to other normal users with basic permission.
        /// </summary>
        AveragePermission       = 1 << 1,
        /// <summary>
        /// Permission of a VIP member of the blog, this user can view VIP
        /// blogs and pages.
        /// </summary>
        VIPPermission           = 1 << 2,
        /// <summary>
        /// Permission of a contributor, people who have contributed regularly
        /// to the blog, their permission is higher than VIP.
        /// </summary>
        ContributorPermission   = 1 << 3,
        /// <summary>
        /// Permission of a user that only can EDIT the content of a post.
        /// </summary>
        WriterPermission        = 1 << 4,
        /// <summary>
        /// Permission of a dev user.
        /// </summary>
        DevPermission           = 1 << 5,

        /// <summary>
        /// Permission of an owner.
        /// </summary>
        OwnerPermission         = 1 << 6,
    }
}
