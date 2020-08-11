import {IProductInBasket} from 'domain/IProductInBasket';
import {autoinject} from 'aurelia-framework';
import {ProductInBasketService} from 'service/productInBasket-service';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {AccountService} from "../../service/account-service";
import {IAccount} from "../../domain/IAccount";
import {BasketService} from "../../service/Basket-service";
import {IBasket} from "../../domain/IBasket";
import {IProduct} from "../../domain/IProduct";
import {ProductService} from "../../service/product-service";
import {CampaignService} from "../../service/campaign-service";
import {ICampaign} from "../../domain/ICampaign";
import {OrderService} from "../../service/order-service";
import {IDeliveryType} from "../../domain/IDeliveryType";
import {DeliveryTypeService} from "../../service/deliveryType-service";
import {IOrderCreate} from "../../domain/IOrderCreate";


@autoinject
export class OrderIndex {
    private _productsInBasket?: IProductInBasket[] = [];
    private _alert: IAlertData | null = null;
    private _account?: IAccount
    private _basket?: IBasket;
    private _total = 0 ;
    private _products: IProduct[] = [];
    private _campaign?: ICampaign;
    private _deliveryTypes?: IDeliveryType[];
    private _address?: string;
    private _phone?: string;
    private _deliveryType?: IDeliveryType;
    private _deliveryTypeId?: string;
    private _Order?: IOrderCreate;


    constructor(private CampaignService: CampaignService,
                private ProductInBasketService: ProductInBasketService,
                private BasketService: BasketService,
                private AccountService: AccountService,private OrderService: OrderService,private DeliveryTypeService: DeliveryTypeService){

    }

    attached() {
        this.AccountService.getUser().then(response => {
            if (response.statusCode >= 200 && response.statusCode < 300) {
                this._alert = null;
                this._account = response.data!
                if (this._account != null) {
                    console.log("ere")
                    console.log(this._account.id)
                    this.BasketService.getBasketByAppUser(this._account.id).then(response => {
                        if (response.statusCode >= 200 && response.statusCode < 300) {
                            this._alert = null;
                            this._basket = response.data!
                            console.log(response.data!);
                            if (this._account != null && this._basket != null) {
                                console.log("I Am Here")
                                console.log(this._basket.id)
                                this.ProductInBasketService.getUserProductsInBasket(this._basket.id).then(
                                    response => {
                                        if (response.statusCode >= 200 && response.statusCode < 300) {
                                            this._alert = null;
                                            this._productsInBasket = response.data
                                            console.log(response.data)
                                            console.log("successful!")
                                            if (this._basket != null){
                                                this.ProductInBasketService.getTotal(this._basket?.id).then(response => {
                                                    console.log(response.statusCode)
                                                    if (response.statusCode >= 200 && response.statusCode < 300) {
                                                        this._alert = null;
                                                        console.log(response.data)
                                                        if (response.data != null){
                                                            if (this._productsInBasket != null) {
                                                                for (let prod of this._productsInBasket) {
                                                                    this._total += Number(this.getPrice(prod.product.productPrice, prod.quantity));
                                                                }
                                                            }
                                                        }
                                                    } else {
                                                        // show error message
                                                        console.log("jajah")
                                                        this._alert = {
                                                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                                            type: AlertType.Danger,
                                                            dismissable: true,
                                                        }
                                                    }
                                                });
                                            }
                                        } else {
                                            // show error message
                                            console.log("johhaidii")
                                            this._alert = {
                                                message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                                type: AlertType.Danger,
                                                dismissable: true,

                                            }
                                        }
                                    });
                            }

                        } else {
                            // show error message
                            this._alert = {
                                message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                type: AlertType.Danger,
                                dismissable: true,
                            }
                        }
                    });
                }
            } else {
                // show error message
                this._alert = {
                    message: response.statusCode.toString() + ' - ' + response.errorMessage,
                    type: AlertType.Danger,
                    dismissable: true,
                }
            }
        });

        this.DeliveryTypeService.getDeliveryTypes().then(response => {
            if (response.statusCode >= 200 && response.statusCode < 300) {
                this._alert = null;
                if (response.data != null){
                    this._deliveryTypes = response.data
                    console.log(response.data)
                    console.log("successful!")

                }

            } else {
                // show error message
                console.log("munnid on kõik")
                this._alert = {
                    message: response.statusCode.toString() + ' - ' + response.errorMessage,
                    type: AlertType.Danger,
                    dismissable: true,

                }
            }
        });

    }

    onSubmit(event: Event) {
        console.log(event);
        console.log(this._account);
        console.log(this._address);
        console.log(this._basket);
        console.log(this._deliveryTypeId);
        console.log(this._phone);
        console.log(this._total);
        if (this._account != null && this._address != null && this._basket != null && this._deliveryTypeId != null && this._phone != null && this._total != null && this._productsInBasket != null) {
            this._Order = {
                appUserId: this._account.id,
                address: this._address,
                basketId: this._basket?.id,
                deliveryTypeId: this._deliveryTypeId,
                phoneNumber: this._phone,
                totalCost: Number(this._total),
                productsInBasket: this._productsInBasket
            }
        }
        console.log(this._Order)
        if (this._Order != null) {
            this.OrderService.createOrder(this._Order)
                .then(
                    response => {
                        if (response.statusCode >= 200 && response.statusCode < 300) {
                            this._alert = null;
                            console.log(response.data)
                        } else {
                            // show error message
                            this._alert = {
                                message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                type: AlertType.Danger,
                                dismissable: true,
                            }
                        }
                    }
                );
        }



        event.preventDefault();

    }

    getDecimals(dec:number){
        return dec.toFixed(2)
    }
    getPrice(price:number, quantity:number){
        return (price*quantity).toFixed(2)}

}

