import {autoinject} from 'aurelia-framework';
import {RouteConfig, NavigationInstruction, Router} from 'aurelia-router';
import {ProductService} from 'service/product-service';
import {AccountService} from 'service/account-service';
import {IProduct} from 'domain/IProduct';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {IProductInBasketCreate} from 'domain/IProductInBasketCreate';
import {ProductInBasketService} from 'service/productInBasket-service';
import {BasketService} from 'service/Basket-service';
import {CategoryService} from "../../service/category-service";
import {ICategory} from "../../domain/ICategory";
import {IAccount} from "../../domain/IAccount";
import {IBasket} from "../../domain/IBasket";
import {IndexResources} from "../../lang/IndexResources";

@autoinject
export class ProductDetails {
    private _Product?: IProduct;
    private _account?: IAccount;
    private _productsInBasket?: IProductInBasketCreate;
    private _alert: IAlertData | null = null;
    private _categories: ICategory[] = []
    private _quantity: number = 0
    private _basket?: IBasket
    private langResources = IndexResources;

    constructor(private productService: ProductService,
                private categoryService: CategoryService,
                private ProductInBasketService: ProductInBasketService,
                private BasketService: BasketService,
                private accountService: AccountService) {


    }

    attached() {


    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params.id);
        if (params.id && typeof (params.id) == 'string') {
            this.productService.getProduct(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._Product = response.data!;
                        console.log(response.data)
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        // @ts-ignore
                        this._Product = undefined;
                    }
                }
            );
            this.categoryService.getCategories().then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._categories = response.data!;
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
    delete(){
        if (this._Product != null){
            this.productService.deleteProduct(this._Product?.id).then(response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
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

    onSubmit(event: Event) {
        console.log("submitin")
        this.accountService.getUser().then(response => {
            if (response.statusCode >= 200 && response.statusCode < 300) {
                this._alert = null;
                this._account = response.data!
                if (this._account != null) {
                    console.log("ere");
                    console.log("acc ID: " +this._account.id);
                    this.BasketService.getBasketByAppUser(this._account.id).then(response => {
                        if (response.statusCode >= 200 && response.statusCode < 300) {
                            this._alert = null;
                            this._basket = response.data!
                            console.log("acc ID: " +this._account!.id + "basket ID:" + this._basket.id );
                            if (this._account != null && this._Product != null && this._basket != null) {
                                console.log("I Am Here")
                                this.ProductInBasketService.addProductToShoppingCart({
                                    appUserId: this._account.id,
                                    productId: this._Product.id,
                                    quantity: 1,
                                    totalCost: Number(this._Product.productPrice * this._quantity),
                                    basketId: this._basket.id
                                }
                                ).then(
                                    response => {
                                        if (response.statusCode >= 200 && response.statusCode < 300) {
                                            this._alert = null;
                                            console.log("successful!")

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
        });


    }
}

