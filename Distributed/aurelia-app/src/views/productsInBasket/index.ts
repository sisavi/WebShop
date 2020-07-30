import { IProductInBasket } from 'domain/IProductInBasket';
import { autoinject } from 'aurelia-framework';
import { ProductInBasketService } from 'service/productInBasket-service';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class ProductInBasketIndex{
    private _productsInBasket: IProductInBasket[] = [];
    private _alert: IAlertData | null = null;


    constructor(private ProductInBasketService: ProductInBasketService){

    }

    attached() {
        this.ProductInBasketService.getProductsInBasket().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._productsInBasket = response.data!;
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
