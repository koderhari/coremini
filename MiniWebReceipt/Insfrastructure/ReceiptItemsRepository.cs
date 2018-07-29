using MiniWebReceipt.Insfrastructure.Core;
using MiniWebReceipt.Insfrastructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiniWebReceipt.Insfrastructure
{
    public class ReceiptItemsRepository : IReceiptItemsRepository
    {
        private static IList<ReceiptItem> _items;

        public IQueryable<ReceiptItem> All()
        {
            PrepareCache();
            return _items.AsQueryable();
        }

        public IQueryable<ReceiptItem> FindBy(string product)
        {
            return All().Where(x => x.Product.Contains(product.ToLower()));
        }

        private void PrepareCache()
        {
            if (_items==null)
            {
                var text = File.ReadAllText("receiptitems.json");
                _items = JsonConvert.DeserializeObject<List<ReceiptItem>>(text);
            }
        }
    }
}
