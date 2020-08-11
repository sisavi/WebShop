import {IProductInBasket} from "./IProductInBasket";

export interface IOrderCreate {
    appUserId: string,
    basketId: string,
    deliveryTypeId:string,
    totalCost: number,
    phoneNumber: string,
    address: string
    productsInBasket: IProductInBasket[]

}
