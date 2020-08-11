import {IProductInBasket} from 'domain/IProductInBasket';
import {autoinject} from 'aurelia-framework';
import {ProductInBasketService} from 'service/productInBasket-service';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {AccountService} from "../../service/account-service";
import {IAccount} from "../../domain/IAccount";
import {BasketService} from "../../service/Basket-service";
import {NavigationInstruction, RouteConfig} from "aurelia-router";
import {CampaignService} from "../../service/campaign-service";
import {ICampaign} from "../../domain/ICampaign";
import {OrderService} from "../../service/order-service";
import {IDeliveryType} from "../../domain/IDeliveryType";
import {DeliveryTypeService} from "../../service/deliveryType-service";
import {IOrderCreate} from "../../domain/IOrderCreate";
import {IOrder} from "../../domain/IOrder";
import {IndexResources} from "../../lang/IndexResources";


@autoinject
export class AdminDetails {
    private langResources = IndexResources
    private _productsInBasket?: IProductInBasket[] = [];
    private _alert: IAlertData | null = null;
    private _account?: IAccount
    private _deliveryTypes?: IDeliveryType[];
    private _order?: IOrder;


    constructor(private CampaignService: CampaignService,
                private ProductInBasketService: ProductInBasketService,
                private BasketService: BasketService,
                private AccountService: AccountService,private OrderService: OrderService,private DeliveryTypeService: DeliveryTypeService){

    }


    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        this.OrderService.getOrder(params.id).then(response => {
            if (response.data){
                this._order = response.data
            }
        });

        if (params.id && typeof (params.id) == 'string') {
            this.OrderService.getProductsForOrder(params.id).then(
                response => {
                    if (response.data) {
                        this._productsInBasket = response.data;
                    }
                }
            );
        }
    }
/*
    attached() {
        this.OrderService.getOrders().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._orders = response.data!;
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
    */


}

