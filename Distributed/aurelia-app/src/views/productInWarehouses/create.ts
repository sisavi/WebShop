import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { ProductService } from 'service/product-service';
import { IProduct } from 'domain/IProduct';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class ProductCreate {
    private _alert: IAlertData | null = null;

    _categoryId="";
    _campaignId="";
    _productName="";
    _description="";
    _productPrice="";


    constructor(private productService: ProductService, private router: Router) {

    }

    attached() {

    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {

    }

    onSubmit(event: Event) {
        console.log(event);
        this.productService
            .createProduct({ productName: this._productName, campaignId: this._campaignId, description: this._description,productPrice: parseInt(this._productPrice), categoryId: this._categoryId})
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('product-index', {});
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

        event.preventDefault();
    }

}
