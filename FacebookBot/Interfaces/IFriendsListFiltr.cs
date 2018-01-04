using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFriendsListFiltr  // i made it simple => you can delete this interface 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>List of Friends Uri's</returns>
        List<Uri> GetUriToFriends(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>datatime of birth day</returns>
        DateTime GetBirthDateofUser(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>user sex</returns>
        int GetSexOfUse(string data);

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string of residence</returns>
        string GetUserResidence(string data);
    }
}