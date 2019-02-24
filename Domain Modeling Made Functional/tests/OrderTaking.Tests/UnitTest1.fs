namespace OrderTaking.Tests

open NUnit.Framework
open OrderTaking.PlaceOrder.Api
open OrderTaking.PlaceOrder
open Newtonsoft.Json

type TestClass () =

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.Test1 () =
        let customerInfo :CustomerInfoDto = {
            FirstName = "John";
            LastName = "Sand";
            EmailAddress = "john@sand.sa";
            VipStatus = "Normal"
            }
        let address :AddressDto = {
            AddressLine1 ="street";
            AddressLine2 = "";
            AddressLine3 = "";
            AddressLine4 = "";
            City = "Warsaw";
            ZipCode ="00-301";
            State = "Mazovian";
            Country = "Poland"
            }
        let lines :OrderFormLineDto list = 
            [
                {
                    OrderLineId = "13";
                    ProductCode = "W41";
                    Quantity = 139m;
                }]
        let form : OrderFormDto = {
            OrderId = "0";
            CustomerInfo = customerInfo;
            ShippingAddress = address;
            BillingAddress = address;
            Lines = lines;
            PromotionCode = "xyz"
         }

        let request = {
            Action = "";
            Uri = "";
            Body = JsonConvert.SerializeObject form
        }
        let result = OrderTaking.PlaceOrder.Api.placeOrderApi request |> Async.RunSynchronously
        request.Body.ToString() |> printf "%s"
        result.Body.ToString() |> printf "%s"
        Assert.Pass()
