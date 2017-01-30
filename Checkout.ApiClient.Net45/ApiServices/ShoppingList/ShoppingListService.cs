using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        public HttpResponse<ShoppingListItem> AddShoppingListItem(ShoppingListItem requestModel)
        {
            return new ApiHttpClient().PostRequest<ShoppingListItem>(ApiUrls.ShoppingList, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdateShoppingListItem(ShoppingListItem requestModel)
        {
            return new ApiHttpClient().PutRequest<OkResponse>(ApiUrls.ShoppingList, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<ShoppingListItem> GetShoppingListItemByName(string name)
        {
            var getShoppingListItemByNameUri = string.Format(ApiUrls.ShoppingListItemByName, name);
            return new ApiHttpClient().GetRequest<ShoppingListItem>(getShoppingListItemByNameUri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> DeleteShoppingListItem(string name)
        {
            var deleteShoppingListItemUri = string.Format(ApiUrls.ShoppingListItemByName, name);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteShoppingListItemUri, AppSettings.SecretKey);
        }

        public HttpResponse<ResponseModels.ShoppingList> GetShoppingList(ShoppingListGetList request)
        {
            var getShoppingListUri = ApiUrls.ShoppingList;

            if (request.Count.HasValue)
            {
                getShoppingListUri = UrlHelper.AddParameterToUrl(getShoppingListUri, "count", request.Count.ToString());
            }

            if (request.Offset.HasValue)
            {
                getShoppingListUri = UrlHelper.AddParameterToUrl(getShoppingListUri, "offset", request.Offset.ToString());
            }

            return new ApiHttpClient().GetRequest<ResponseModels.ShoppingList>(getShoppingListUri, AppSettings.SecretKey);
        }
    }
}
