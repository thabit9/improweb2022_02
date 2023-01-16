using System;
using System.Data;
using System.Configuration;
using System.Web;
/*using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;*/

namespace improweb2022_02.Helpers
{
    public class OrderTracker
    {
        public enum TrackingResult
        {
            NoQuotation, //Quotation details for specified quotation no. not found in IE's database (probably indicates error)
            NotProcessed, //Shop owner talking to IE
            InProgress, //In progress at IE
            ShippingInProgress //Shipping in progress with one of IE's shipping companies (has been collected)
        }

        public struct TrackingDetails
        {
            public TrackingResult Result;

            public DateTime QuoteAdded;
            public DateTime QuoteModified;

            public DateTime WaybillAdded;
            public DateTime WaybillCourierAssigned;

        }
        
        /*
        private string connectionString;
        public OrderTracker(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public TrackingDetails GetOrderTrackingDetails(string quotationId)
        {
            TrackingDetails toReturn = new TrackingDetails();
            DataSet dsQuote = RetrieveDomesticQuote(quotationId);
            if (dsQuote.Tables[0].Rows.Count == 0)
            {
                toReturn.Result = TrackingResult.NoQuotation;
                return toReturn;
            }

            DataRow rQuote = dsQuote.Tables[0].Rows[0];
            toReturn.QuoteAdded = (DateTime)rQuote["DateAdded"];
            toReturn.QuoteModified = (DateTime)rQuote["DateModified"];

            DataSet dsItems = GetQuoteLineItems(quotationId);
            if (dsItems.Tables[0].Rows.Count == 0)
            {
                toReturn.Result = TrackingResult.NotProcessed;
                return toReturn;
            }

            DataSet dsWaybill = GetWaybillDetails(quotationId);
            if (dsWaybill.Tables[0].Rows.Count == 0)
            {
                toReturn.Result = TrackingResult.InProgress;
                return toReturn;
            }
            DataRow rWaybill = dsWaybill.Tables[0].Rows[0];
            toReturn.WaybillAdded = (DateTime)rWaybill["DateAdded"];
            toReturn.WaybillCourierAssigned = (DateTime)rWaybill["CourierAssignedDate"];

            toReturn.Result = TrackingResult.ShippingInProgress;
            return toReturn;
        }
        private DataSet RetrieveDomesticQuote(string quotationId)
        {
            iExpress.internetExpress ie = new esquireonline.iExpress.internetExpress();
            ie.AuthenticationHeaderValue = Shared.GetIeAuthenticationHeader();
            return ie.getDomesticQuote(quotationId);
        }
        private DataSet GetQuoteLineItems(string quotationId)
        {
            iExpress.internetExpress ie = new esquireonline.iExpress.internetExpress();
            ie.AuthenticationHeaderValue = Shared.GetIeAuthenticationHeader();
            return ie.GetDomesticQuoteLineItems(quotationId);
        }
        private DataSet GetWaybillDetails(string quotationId)
        {
            iExpress.internetExpress ie = new esquireonline.iExpress.internetExpress();
            ie.AuthenticationHeaderValue = Shared.GetIeAuthenticationHeader();
            return ie.GetWaybill(quotationId);
        }
        private DataSet GetCourierDetails(int courierId)
        {
            throw new NotImplementedException();
        }
        */
    }
}
