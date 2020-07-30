import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { ProductService } from 'service/product-service';
import { AccountService } from 'service/account-service';
import { IProduct } from 'domain/IProduct';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import { IProductInBasket } from 'domain/IProductInBasket';
import { ProductInBasketService } from 'service/productInBasket-service';

@autoinject
export class ProductDetails{
    private _Product?: IProduct;
    private _productsInBasket?: IProductInBasket;
    private _alert: IAlertData | null = null;

    constructor(private productService: ProductService, private ProductInBasketService: ProductInBasketService, private accountService: AccountService){

    }

    attached() {
        
       
    }
    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params);
        if (params.id && typeof (params.id) == 'string') {
            this.productService.getProduct(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._Product = response.data!;
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        this._Product = undefined;
                    }
                }                
            );
        }
    }

}
