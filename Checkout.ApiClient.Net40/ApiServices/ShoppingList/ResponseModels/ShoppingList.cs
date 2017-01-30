using Checkout.ApiServices.ShoppingList.RequestModels;
using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingList.ResponseModels
{
    public class ShoppingList
    {
        public int Count { get; set; }
        public List<ShoppingListItem> Data { get; set; }
    }
}
