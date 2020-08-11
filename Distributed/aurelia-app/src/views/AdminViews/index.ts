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
import {IOrder} from "../../domain/IOrder";


@autoinject
export class AdminIndex {
    private _productsInBasket?: IProductInBasket[] = [];
    private _alert: IAlertData | null = null;
    private _account?: IAccount
    private _basket?: IBasket;
    private _total?: number ;
    private _products: IProduct[] = [];
    private _campaign?: ICampaign;
    private _deliveryTypes?: IDeliveryType[];
    private _address?: string;
    private _phone?: string;
    private _deliveryType?: IDeliveryType;
    private _deliveryTypeId?: string;
    private _orders?: IOrder[];


    constructor(private CampaignService: CampaignService,
                private ProductInBasketService: ProductInBasketService,
                private BasketService: BasketService,
                private AccountService: AccountService,private OrderService: OrderService,private DeliveryTypeService: DeliveryTypeService){

    }

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


}

