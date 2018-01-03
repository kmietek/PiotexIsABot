using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInterface
{
    interface IFriendsListFiltr
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlBody"></param>
        /// <returns>List of Uri's to friends</returns>
        List<Uri> GetUriToFriends(string htmlBody);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriToProfile"></param>
        /// <returns></returns>
        DateTime GetBirthDateofUser(Uri uriToProfile);

        int GetSexOfUse(Uri uriToProfile);

        /// <summary>
        ///Gets the place of residence of the user
        /// </summary>
        /// <param name="uriToProfile"></param>
        /// <returns></returns>
        string GetAbodeofUser(Uri uriToProfile);

    }
}
