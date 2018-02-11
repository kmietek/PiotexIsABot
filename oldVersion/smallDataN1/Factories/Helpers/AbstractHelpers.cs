using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Factories.PageFactory;
using smallData.Factories.PageFactory.Interfaces;
using smallData.Factories.PageFactory.Pages;

namespace smallData.Helpers
{
    public static class AbstractHelpers
    {
        static AbstractHelpers()
        {
            var a = Assembly.GetAssembly(typeof(FacebookPage)).GetTypes();
            var b = a.Where(m => m.BaseType == typeof(FacebookPage)).ToList();

            foreach (var item in b)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var res = assembly.CreateInstance(item.FullName) as FacebookPage;
                FacebookPageClassesInstance.Add(item.Name.ToLower(), res);
            }
        }

        private static Dictionary<string, FacebookPage> FacebookPageClassesInstance = new Dictionary<string, FacebookPage>();

        public static FacebookPage GetFacebookPageClassesInstance(EFacebookEnum enuma)
        {
            return FacebookPageClassesInstance[enuma.ToString().ToLower()];
        }











        public static Dictionary<string,object> GetClassesFromAbstractClass<T>() where T:class 
        {
            Dictionary<string,object> q = new Dictionary<string, object>();

            var a = Assembly.GetAssembly(typeof(T)).GetTypes();
            var b = a.Where(m => m.BaseType == typeof(T)).ToList();

            foreach (var item in b)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var res = assembly.CreateInstance(item.FullName) as T;
                q.Add(item.Name.ToLower(), res);
            }

            return q;
        }

    }
}