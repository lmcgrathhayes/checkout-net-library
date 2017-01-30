using Checkout.ApiServices.ShoppingList.RequestModels;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;

namespace Tests.ShoppingListService
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListServiceTests : BaseServiceTests
    {
        [Test]
        public void AddItemToShoppingList()
        {
            var item = new ShoppingListItem() { Name = "Pepsi", Quantity = 5 };
            var response = CheckoutClient.ShoppingListService.AddShoppingListItem(item);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.ShouldBeEquivalentTo(item);

            CheckoutClient.ShoppingListService.DeleteShoppingListItem(item.Name);
        }

        [Test]
        public void GetShoppingListItemByName()
        {
            var item = new ShoppingListItem { Name = "Pepsi", Quantity = 5 };
            CheckoutClient.ShoppingListService.AddShoppingListItem(item);

            var response = CheckoutClient.ShoppingListService.GetShoppingListItemByName(item.Name);
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.Name.Should().Be(item.Name);

            CheckoutClient.ShoppingListService.DeleteShoppingListItem(item.Name);
        }

        [Test]
        public void GetShoppingList()
        {
            var item = new ShoppingListItem { Name = "Pepsi", Quantity = 5 };
            CheckoutClient.ShoppingListService.AddShoppingListItem(item);

            var response = CheckoutClient.ShoppingListService.GetShoppingList(new ShoppingListGetList());
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Count.Should().BeGreaterOrEqualTo(1);

            CheckoutClient.ShoppingListService.DeleteShoppingListItem(item.Name);
        }

        [Test]
        public void DeleteShoppingListItem()
        {
            var item = new ShoppingListItem { Name = "Pepsi", Quantity = 5 };
            CheckoutClient.ShoppingListService.AddShoppingListItem(item);

            var deleteResponse = CheckoutClient.ShoppingListService.DeleteShoppingListItem(item.Name);
            deleteResponse.Should().NotBeNull();
            deleteResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void UpdateShoppingListItem()
        {
            var item = new ShoppingListItem { Name = "Pepsi", Quantity = 5 };

            var addResponse = CheckoutClient.ShoppingListService.AddShoppingListItem(item);
            addResponse.Should().NotBeNull();
            addResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            item.Quantity = 10;

            var updateResponse = CheckoutClient.ShoppingListService.UpdateShoppingListItem(item);
            updateResponse.Should().NotBeNull();
            updateResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = CheckoutClient.ShoppingListService.GetShoppingListItemByName(item.Name);
            getResponse.Should().NotBeNull();
            getResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Model.Should().NotBeNull();
            getResponse.Model.Name.Should().Be(item.Name);
            getResponse.Model.Quantity.Should().Be(10);

            CheckoutClient.ShoppingListService.DeleteShoppingListItem(item.Name);
        }
    }
}
