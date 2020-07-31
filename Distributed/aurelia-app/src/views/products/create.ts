import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { ProductService } from 'service/product-service';
import { IProductCreate } from 'domain/IProductCreate';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import {ICategory} from "../../domain/ICategory";
import {ICampaign} from "../../domain/ICampaign";
import {CategoryService} from "../../service/category-service";
import {CampaignService} from "../../service/campaign-service";

@autoinject
export class ProductCreate {
    private _alert: IAlertData | null = null;
    private _campaigns: ICampaign[] = []
    private _categories: ICategory[] = [];

    _categoryId="";
    _campaignId="";
    _productName="";
    _description="";
    _productPrice="";


    constructor(private productService: ProductService,private categoryService: CategoryService,private campaignService: CampaignService, private router: Router) {

    }

    attached() {

    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        this.campaignService.getCampaigns().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._campaigns = response.data!;

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


    onSubmit(event: Event) {
        console.log(event);
        var product: IProductCreate = {productName: this._productName, campaignId: this._campaignId, description: this._description,productPrice: parseInt(this._productPrice), categoryId: this._categoryId}
        this.productService
            .createProduct(product)
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
