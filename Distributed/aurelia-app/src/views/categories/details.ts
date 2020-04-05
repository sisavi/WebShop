import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { CategoryService } from 'service/Category-service';
import { ICategory } from 'domain/ICategory';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class CarsDetails{
    private _Category?: ICategory;    
    private _alert: IAlertData | null = null;

    constructor(private CategoryService: CategoryService){

    }

    attached() {
       
    }
    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params);
        if (params.id && typeof (params.id) == 'string') {
            this.CategoryService.getCategory(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._Category = response.data!;
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        this._Category = undefined;
                    }
                }                
            );
        }
    }

}