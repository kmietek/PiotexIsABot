using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace FacebookBot.Class
{
    class BotConnection
    {






        public BotConnection()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public void BotHttpConnection()
        {


            // GET COOKIES FROM FACEBOOK TO VALIDATE <<<<-------------------------------------------
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.facebook.com/login.php?login_attempt=1");
            CookieContainer cookies = new CookieContainer();
            request.CookieContainer = new CookieContainer();
            request.CookieContainer = cookies; //recover cookies First request
            request.Method = WebRequestMethods.Http.Post;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            request.AllowWriteStreamBuffering = true;
            request.ProtocolVersion = HttpVersion.Version11;
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();



            // LOGIN TO FACEBOOK ACCOUNT <<<<-----------------------------------------------------
            string getUrl = "https://www.facebook.com/login.php?login_attempt=1";
            string postData = String.Format("email={0}&pass={1}", "politechopol2017@gmail.com", "politechopol2017@gmail.com");
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            getRequest.CookieContainer = new CookieContainer();
            getRequest.CookieContainer = cookies; //recover cookies First request
            getRequest.Method = WebRequestMethods.Http.Post;
            getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            getRequest.AllowWriteStreamBuffering = true;
            getRequest.ProtocolVersion = HttpVersion.Version11;
            getRequest.AllowAutoRedirect = true;
            getRequest.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            getRequest.ContentLength = byteArray.Length;
            Stream newStream = getRequest.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.

            HtmlDocument htmlBodyTest = new HtmlDocument();

            using (HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse())
            {

                htmlBodyTest.Load(getResponse.GetResponseStream());
                getResponse.Close();


            }




            getUrl = "https://www.facebook.com/profile.php?id=100004726745558&lst=100023878293399%3A100004726745558%3A1515106536&sk=friends&source_ref=pb_friends_tl";
            getRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            getRequest.CookieContainer = cookies; //recover cookies First request
            getRequest.Method = WebRequestMethods.Http.Get;
            getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            getRequest.AllowWriteStreamBuffering = true;
            getRequest.ProtocolVersion = HttpVersion.Version11;
            getRequest.AllowAutoRedirect = true;
            getRequest.ContentType = "application/x-www-form-urlencoded";

            HtmlDocument htmlBody = new HtmlDocument();

            using (HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse())
            {

                htmlBody.Load(getResponse.GetResponseStream());
                getResponse.Close();


            }



        }
    }
}