using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTool.Classes
{
    public class clsOrder
    {

        #region Public Properties

        int OrderId { get; set; }
        string OrderMailBody { get; set; }
        string OrderMailSubject { get; set; }
        string OrderItemBase64Image { get; set; }
        string OrderItemName { get; set; }
        DateTime? OrderDeliveryDate { get; set; }
        bool? PremiumDelivery { get; set; }
        string OrderNumber { get; set; }
        DateTime OrderMailImport { get; set; }
        bool OrderCompleted { get; set; }
        DateTime? OrderCompletedDate { get; set; }

        #endregion

        #region Constructor
        public clsOrder(int pOrderId, string pOrderMailBody, string pOrderMailSubject, string pOrderItemName,
            DateTime pOrderDeliveryDate, bool pPremiumDelivery, string pOrderNumber)
        {
            this.OrderId = pOrderId;
            this.OrderMailBody = pOrderMailBody;
            this.OrderMailSubject = pOrderMailSubject;
            this.OrderItemName = pOrderItemName;
            this.OrderDeliveryDate = pOrderDeliveryDate;
            this.PremiumDelivery = pPremiumDelivery;
            this.OrderNumber = pOrderNumber;
            this.OrderMailImport = DateTime.Now;
            this.OrderCompleted = false;
        }

        public clsOrder() { }
        #endregion

    }
}
