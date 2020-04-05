import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { WarehouseService } from 'service/warehouse-services';
import { IWarehouse } from 'domain/IWarehouse';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class WarehouseDetails{
    private _Warehouse?: IWarehouse;    
    private _alert: IAlertData | null = null;

    constructor(private WarehouseService: WarehouseService){

    }

    attached() {
       
    }
    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params);
        if (params.id && typeof (params.id) == 'string') {
            this.WarehouseService.getWarehouse(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._Warehouse = response.data!;
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        this._Warehouse = undefined;
                    }
                }                
            );
        }
    }

}