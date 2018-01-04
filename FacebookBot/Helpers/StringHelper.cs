using System;
using System.Collections.Generic;
using Interfaces;

namespace Helpers
{
    public static class StringHelper
    {
        private static string _parser(string bodyCode,string prevCode, int i)
        {
            bool theSame = true;
            string data = "";
            int iCopy = prevCode.Length + i;

            for (int j = 0; j < prevCode.Length; j++)   //test that prevCode is next
            {
                if (bodyCode[i + j] != prevCode[j])
                {
                    theSame = false;
                    break;
                }
            }
            while (theSame && bodyCode[iCopy] != '/')       //take corect data
            {
                data += bodyCode[iCopy];
                iCopy++;
            }
            return data;
        }

        public static List<Uri> GetUriToFriends(this string bodyCode)
        {
            List<Uri> urisliList = new List<Uri>();
            string prevCode = "href:";

            for (int i = 0; i < bodyCode.Length; i++)
            {
                if (bodyCode[i] == prevCode[0])
                {
                    string value = _parser(bodyCode, prevCode, i);
                    if ( value != "")
                    {
                        urisliList.Add(new Uri("http://"+value+"/"));
                    }
                }
            }
            return urisliList;
        }

        public static DateTime GetBirthDateofUser(this string bodyCode)
        {
            string prevCode = "href:";

            for (int i = 0; i < bodyCode.Length; i++)
            {
                if (bodyCode[i] == prevCode[0])
                {
                    string value = _parser(bodyCode, prevCode, i);
                    if (value != "")
                    {
                        List<int> time = dataTimeParser(value);
                        return new DateTime(time[2],time[1],time[0]);
                    }
                }
            }
            return new DateTime(1,1,1);
        }

        private static List<int> dataTimeParser(string time)
        {
            //add data parser code
            return new List<int>{11,2,1999};
        }

        public static int GetSexOfUse(this string bodyCode)
        {
            string prevCode = "href:";

            for (int i = 0; i < bodyCode.Length; i++)
            {
                if (bodyCode[i] == prevCode[0])
                {
                    string value = "add code";
                    if (value != "")
                    {
                        return 3;
                    }
                }
            }
            return 99;
        }

        public static string GetUserResidence(this string bodyCode)
        {
            string prevCode = "href:";

            for (int i = 0; i < bodyCode.Length; i++)
            {
                if (bodyCode[i] == prevCode[0])
                {
                    string value = _parser(bodyCode, prevCode, i);
                    if (value != "")
                    {
                        return value;
                    }
                }
            }
            return "error";
        }
    }
}