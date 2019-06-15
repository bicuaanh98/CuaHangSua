using CuaHangSua.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuaHangSua.Models.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(ProductViewModel product,int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.SuaID == product.SuaID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductViewModel product)
        {
            lineCollection.RemoveAll(l => l.Product.SuaID == product.SuaID);
        }

        public float ComputeTotalValue()
        {
            return (float)lineCollection.Sum(e => e.Product.DonGia * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        } 

        public int TotalItem()
        {
            int totalItem = 0;
            foreach (var item in lineCollection)
            {
                totalItem += item.Quantity;
            }
            return totalItem;
        }
    }
}