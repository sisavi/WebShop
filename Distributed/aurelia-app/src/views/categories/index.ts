import { ICategory } from 'domain/ICategory';
import { autoinject } from 'aurelia-framework';
import { CategoryService } from 'service/category-service';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class CategoriesIndex{
    private _categories: ICategory[] = [];
   private _alert: IAlertData | null = null;


    constructor(private CategoryService: CategoryService){

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


}