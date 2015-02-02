using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tungnt.NET.WCFRestDemo
{
    public class WCFRestDemo : IWCFRestDemo
    {
        public string GetMessage()
        {
            return "Welcome to tungnt.net from GetMessage() WCF REST Service";
        }

        public string PostMessage(string userName)
        {
            return string.Format("Welcome {0} to tungnt.net from PostMessage() WCF REST Service", userName);
        }
    }
}
