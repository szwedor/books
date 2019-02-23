namespace OrderTaking

open DomainApi
open Common

module PlaceOrderWorkflow =
    type ValidatedOrderLine = Undefined


    type OrderId = Undefined
    type CustomerInfo = Undefined
    type Address = Undefined

    type ValidatedOrder = {
        OrderId : OrderId;
        CustomerInfo : CustomerInfo;
        ShippingAddress : Address;
        BillingAddress: Address;
        OrderLines : ValidatedOrderLine list
    }

    type PricedOrderLine = Undefined
    type PricedOrder = Undefined

    type Order = 
     | Unvalidated of UnvalidatedOrder
     | Validated of ValidatedOrder
     | Priced of PricedOrder

    type ProductCode = Undefined

    type CheckproductCodeExists = 
        ProductCode -> bool
        
    type AddressValidationError = Undefined
    type CheckedAddress = Undefined
    type CheckAddressExists = 
        UnvalidatedAddress ->
            AsyncResult<CheckedAddress, AddressValidationError>

    type ValidationError = Undefined

    type ValidateOrder = 
        CheckproductCodeExists
            -> CheckAddressExists
            -> UnvalidatedOrder
            -> AsyncResult<ValidatedOrder, ValidationError list>

    type Price = Undefined

    type GetProductPrice =
        ProductCode -> Price

    type PricingError = Undefined

    type PriceOrder = 
        GetProductPrice
            -> ValidatedOrder
            -> Result<PricedOrder, PricingError>