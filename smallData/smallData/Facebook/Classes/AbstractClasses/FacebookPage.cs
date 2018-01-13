﻿using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Facebook.Classes.AbstractClasses
{
    public abstract class FacebookPage : IPage
    {
        //data base connection
        public abstract List<BasicClass> GetData<BasicClass>(string page);

        public abstract bool AmReady();
    }
}