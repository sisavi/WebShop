import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { CategoryService } from 'service/category-service';
import { ICategory } from 'domain/ICategory';
import { ProductService } from 'service/product-service';
import { IProduct } from 'domain/IProduct';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import {shutdownAppServer} from "../../../aurelia_project/tasks/run";

@autoinject
export class CategoriesDetails{
    private _category?: ICategory;
    private categoryId = "";
    private _products?: IProduct[] = [];
    private _categories?: ICategory[] = [];
    private _alert: IAlertData | null = null;

    constructor(private CategoryService: CategoryService, private productService: ProductService, params: any){
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        if (params.id) {
            this.CategoryService.getCategory(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._category = response.data!;
                        this.getCategoryProducts( this._category!.id)
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

    attached() {
        this.CategoryService.getCategories().then(
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

    getCategoryProducts(id: string){
        this.productService.getProductsByCategory(id).then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._products = response.data!;

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
