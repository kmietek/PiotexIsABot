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
            string postData = String.Format("email={0}&pass={1}", "login", "password");
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

            using (HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse()) { }
            for (int i = 0; i <= 100; i++)
            {


                    getUrl = "https://www.facebook.com/piotr.swierzy.5/friends?lst=100004001157365%3A100004001157365%3A1514929047&source_ref=pb_friends_tl";
                    getRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                    getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
                    getRequest.CookieContainer = cookies; //recover cookies First request
                    getRequest.Method = WebRequestMethods.Http.Get;
                    getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
                    getRequest.AllowWriteStreamBuffering = true;
                    getRequest.ProtocolVersion = HttpVersion.Version11;
                    getRequest.ContentType = "application/x-www-form-urlencoded";

                    HtmlDocument htmlBody = new HtmlDocument();

                    using (HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse())
                    {

                        htmlBody.Load(getResponse.GetResponseStream());
                        getResponse.Close();
                        HtmlNode node = htmlBody.GetElementbyId("friends");

                    }
                }


        }
    }
}
