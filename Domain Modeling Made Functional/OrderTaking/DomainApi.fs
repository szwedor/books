namespace OrderTaking

open Common

module DomainApi =
    type UnvalidatedAddress =
        { Street : string }

    type UnvalidatedCustomer =
        { Name : string
          Email : string }

    type UnvalidatedOrder =
        { OrderId : string
          CustomerInfo : UnvalidatedCustomer
          ShippingAddress : UnvalidatedAddress }

    type PlacedOrderCommand = Command<UnvalidatedOrder>

    type OrderPlaced = Undefined

    type BillableOrderPlaced = Undefined

    type OrderAcknowledgmentSent = Undefined

    type PlaceOrderEvent =
        | OrderPlaced of OrderPlaced
        | BillableOrderPlaced of BillableOrderPlaced
        | OrderAcknowledgmentSent of OrderAcknowledgmentSent

    type PlaceOrderError = Undefined

    type PlaceOrderWorkflow =
        PlacedOrderCommand 
            -> AsyncResult<PlaceOrderEvent list, PlaceOrderError>
