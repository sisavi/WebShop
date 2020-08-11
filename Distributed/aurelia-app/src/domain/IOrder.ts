import {IProductInBasket} from "./IProductInBasket";

export interface IOrder {
    id: string,
    appUserId: string,
    basketId: string,
    deliveryTypeId:string,
    totalCost: number,
    phoneNumber: string,
    address: string
    productsInBasket: IProductInBasket[]
}
