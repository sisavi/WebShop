import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { ProductService } from 'service/product-service';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import {IProductEdit} from "../../domain/IProductEdit";

@autoinject
export class ProductEdit {
    private _alert: IAlertData | null = null;

    private _product: IProductEdit = {id: "", campaignId: undefined, categoryId: "", description: "", productName: "", productPrice: 0};
    _categoryId= "";
    _campaignId?: string;
    _productName="";
    _description="";
    _productPrice=0;

    constructor(private productService: ProductService, private router: Router) {
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
                        this._product = response.data!;
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
        console.log(event);
        this._product.productName = this._productName;
        this._product.campaignId = this._campaignId;
        this._product.categoryId = this._categoryId;
        this._product.description = this._description;
        this._product.productPrice = Number(this._productPrice);


        this.productService
            .updateProduct(this._product!)
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('products-index', {});
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
