import {IProduct} from 'domain/IProduct';
import {autoinject} from 'aurelia-framework';
import {ProductService} from 'service/product-service';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {ICategory} from "../../domain/ICategory";
import {CategoryService} from "../../service/category-service";

@autoinject
export class ProductIndex {
    private _products: IProduct[] = [];
    private _categories: ICategory[] = [];
    private _alert: IAlertData | null = null;


    constructor(private productService: ProductService, private categoryService: CategoryService) {

    }

    attached() {
        this.productService.getProducts().then(
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
