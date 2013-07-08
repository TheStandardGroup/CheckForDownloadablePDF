using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pageflex.Interfaces.Storefront;
using PageflexServices;
using System.Web;
using System.Web.UI;

namespace CheckForDownloadablePDF
{
    public class CheckForDownloadablePDF: SXIExtension
    {
        public override string UniqueName
        {
            get
            {
                return "CheckForDownloadablePDF.standardgroup.com";
            }
        }
        public override string DisplayName
        {
            get
            {
                return "TSG: Check For Downloadable PDF";
            }
        }

        public override int PageLoad(string pageBaseName, string eventName) {

            if ((pageBaseName == "usercheckoutsubmit_aspx") && (eventName == "Init"))
            {
                
                string orderId = Storefront.GetValue("SystemProperty", "PendingOrder", null);
                string[] docsInOrder = Storefront.GetListValue("OrderListProperty", "DocumentsInOrder", orderId);

                string sfirstName = getAdd("OrderField","ShippingFirstName",orderId);
                string slastName = getAdd("OrderField", "ShippingLastName", orderId);
                string sCompany = getAdd("OrderField", "ShippingCompany", orderId);
                string sAdd1 = getAdd("OrderField", "ShippingAddress1", orderId);
                string sAdd2 = getAdd("OrderField", "ShippingAddress2", orderId);
                string sCity = getAdd("OrderField", "ShippingCity", orderId);
                string sState = getAdd("OrderField", "ShippingState", orderId);
                string sZip = getAdd("OrderField", "ShippingPostalCode", orderId);
                string sCountry = getAdd("OrderField", "ShippingCountry", orderId);
                string sPhone = getAdd("OrderField", "ShippingPhone", orderId);
                string sEmail = getAdd("OrderField", "ShippingEmailAddress", orderId);

                if (sCity == null) {
                    string userId = Storefront.GetValue("SystemProperty", "LoggedOnUserID", null);
                    string ufirstName = getAdd("UserField", "UserProfileFirstName", userId);
                    string ulastName = getAdd("UserField", "UserProfileLastName", userId);
                    string uCompany = getAdd("UserField", "UserProfileCompany", userId);
                    string uAdd1 = getAdd("UserField", "UserProfileAddress1", userId);
                    string uAdd2 = getAdd("UserField", "UserProfileAddress2", userId);
                    string uCity = getAdd("UserField", "UserProfileCity", userId);
                    string uState = getAdd("UserField", "UserProfileState", userId);
                    string uZip = getAdd("UserField", "UserProfilePostalCode", userId);
                    string uCountry = getAdd("UserField", "UserProfileCountry", userId);
                    string uPhone = getAdd("UserField", "UserProfilePhone", userId);
                    string uEmail = getAdd("UserField", "UserProfileEmailAddress", userId);
                    Storefront.SetValue("OrderField","ShippingFirstName",orderId,ufirstName);
                    Storefront.SetValue("OrderField","ShippingLastName",orderId,ulastName);
                    Storefront.SetValue("OrderField","ShippingCompany",orderId,uCompany);
                    Storefront.SetValue("OrderField","ShippingAddress1",orderId,uAdd1);
                    Storefront.SetValue("OrderField","ShippingAddress2",orderId,uAdd2);
                    Storefront.SetValue("OrderField","ShippingCity",orderId,uCity);
                    Storefront.SetValue("OrderField","ShippingState",orderId,uState);
                    Storefront.SetValue("OrderField","ShippingPostalCode",orderId,uZip);
                    Storefront.SetValue("OrderField","ShippingCountry",orderId,uCountry);
                    Storefront.SetValue("OrderField","ShippingPhone",orderId,uPhone);
                    Storefront.SetValue("OrderField","ShippingEmailAddress",orderId,uEmail);
                    Storefront.LogMessage(uCity, orderId, docsInOrder[0], 1, false);
                    System.Console.WriteLine("worked");
                }
                

            }

            return eSuccess;
        }

        private string getAdd(string pName, string fName, string ordId) {
            return Storefront.GetValue(pName, fName, ordId);
        }

    }
}
