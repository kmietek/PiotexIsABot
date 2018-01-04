using System.Collections.Generic;
using System.Windows.Forms;
using DBCommunication;
using InterfacesBP;

namespace FacebookToolsBP.FacebookInfoFactory
{
    public abstract class FacebookInfo : IInfoFacebook
    {
//        protected bool canIAdd = false;
//        protected int numberToMove = 0;
//        protected int iCopy = 0;
//        protected string dataToAdd = "";
//        protected List<string> dataList = new List<string>();

        public abstract bool GetDataList(WebBrowser page);

        protected PostgreComands PostgreComands = new PostgreComands("postgres", "start12345", "localhost", "5432", "smalDATA");

        private static readonly object m_oPadlock = new object();


        public PostgreComands TaskId
        {
            get
            {
                PostgreComands sRetString = null;
                lock (m_oPadlock)
                {
                    sRetString = PostgreComands;
                }
                return sRetString;
            }
            private set
            {
                lock (m_oPadlock)
                {
                    PostgreComands = value;
                }
            }
        }
    }
}