using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

namespace Helpers
{
    public static class AbstractHelpers
    {
        public static List<System.Type> GetClassesFromAbstractClass<T>()
        {
            var a = Assembly.GetAssembly(typeof(T)).GetTypes();
            var b = a.Where(m => m.BaseType == typeof(T)).ToList();

            foreach (var item in b)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
//                var printer = assembly.CreateInstance(item.Name) as smallData.Factories.PageFactory.Pages.;
            }


            return b;
        }

    }

    public class Person
    {
        private string _name;

        public Person()
        { }

        public Person(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}