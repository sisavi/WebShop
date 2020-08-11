import {IProduct} from "./IProduct";

export interface IProductInBasket {
    appUserId: string
    productId: string
    quantity: number
    totalCost: number
    basketId: string
    id:string
    product: IProduct;
}
