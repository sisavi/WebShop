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

@autoinject
export class ProductInBasketIndex {
    private _productsInBasket?: IProductInBasket[] = [];
    private _alert: IAlertData | null = null;
    private _account?: IAccount
    private _basket?: IBasket;
    private _total: number = 0 ;
    private _products: IProduct[] = [];
    private _campaign?: ICampaign;
    private _productId?: string;


    constructor(private CampaignService: CampaignService, private ProductInBasketService: ProductInBasketService, private BasketService: BasketService, private AccountService: AccountService, private ProductService: ProductService) {

    }

    attached() {
        this.getProducts()
    }

    getProducts(){this.AccountService.getUser().then(response => {
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
                                            this.ProductInBasketService.getTotal(this._basket?.id) .then(response => {
                                                if (response.statusCode >= 200 && response.statusCode < 300) {
                                                    this._alert = null;
                                                    if (response.data != null){
                                                        if (this._productsInBasket != null) {
                                                            for (let prod of this._productsInBasket){
                                                                this._total += Number(this.getPrice(prod.product.productPrice, prod.quantity));



                                                                }
                                                        }

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
    });}

    getProductPrice(productPrice: number, campaignId:string){
        if (campaignId != null){this.CampaignService.getCampaign(campaignId) .then(response => {
            if (response.statusCode >= 200 && response.statusCode < 300) {
                this._alert = null;
                if (response.data != null){
                    this._campaign = response.data
                    console.log(response.data)
                    console.log("kampaania käes! " + Number(productPrice) * (Number(this._campaign.discount)/100))

                    return String(Number(productPrice) * (Number(this._campaign.discount)/100))

                }

            } else {
                // show error message
                console.log("munnid on kõik")
                return productPrice
            }
        });}
        else{return productPrice}
    }
    onSubmit(event: Event) {

        console.log(this._productId)
        console.log(event)
        /*
        this.productInWarehouseService
            .updateProductInWarehouse(this._productInWarehouse)
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('productInWarehouses-details', {id: this._productInWarehouse.id});
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                    }
                }
            );*/

        event.preventDefault();
    }
    clearData(): void {
        this._productsInBasket = [];
        this._total = 0;
    }
    getDecimals(dec:number){
        return dec.toFixed(2)
    }

    reloadShoppingCart(): void {
        this.getProducts();
    }

    removeFromShoppingCart(connectionId: string): void {
        console.log(connectionId)
        let removed = this.ProductInBasketService.removeFromShoppingCart(connectionId)
        this.clearData();
        this.reloadShoppingCart();
        location.reload();
    }

    getPrice(price:number, quantity:number){
        return (price*quantity).toFixed(2)

    }

    }

