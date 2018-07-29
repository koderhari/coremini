using MiniWebReceipt.Insfrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniWebReceipt.Insfrastructure.Core
{
    public interface IReceiptItemsRepository
    {
        IQueryable<ReceiptItem> All();
        IQueryable<ReceiptItem> FindBy(string productName);
    }
}
