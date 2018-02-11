﻿using System.Collections.Generic;
using smallData.Facebook.Classes.AbstractClasses;

namespace Factories.Facebook.Classes.BasicClasses
{
    public class MainLiveEvents : MainAbstractClass
    {
        public override List<AncillaryAbstractClass> GetData(string document)
        {
            return new List<AncillaryAbstractClass>();
        }

        public override bool AmReady()
        {
            return true;
        }
        public override bool CanScrool() => false;
    }
}