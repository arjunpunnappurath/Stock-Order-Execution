using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public enum StockSide { Buy, Sell };
    public enum StockState { Open, Closed };
    /// <summary>
    /// Stock class represents each item in the input and tracks quantity and state
    /// </summary>
    public class Stock
    {
        public string Id { get; private set; }
        public StockSide Side { get; private set; }
        public string Company { get; private set; }
        public int Quantity { get; private set; }
        public int RemQuantity { get; set; }
        public StockState Status { get; set; }
        public bool IsClosed { get { return Status == StockState.Closed; } }

        public Stock(string id, string company, StockSide side, int qty)
        {
            this.Id = id;
            this.Side = side;
            this.Company = company;
            this.Quantity = qty;
            this.RemQuantity = qty;
            this.Status = StockState.Open;
        }

        //Function to update the status of a transaction with respect to the remaining quantity it contains.                                                 
        public void UpdateRemainingQuantity(int qty)
        {
            this.RemQuantity = qty;
            if (RemQuantity <= 0)
                this.Status = StockState.Closed;
            else
                this.Status = StockState.Open;
        }

        public override bool Equals(object obj)
        {
            var arg = obj as Stock;
            if (Id.Equals(arg.Id) && Side.Equals(arg.Side) && Company.Equals(arg.Company) && Quantity.Equals(arg.Quantity) && Status.Equals(arg.Status))
                return true;
            return false;
        }
    }
}
