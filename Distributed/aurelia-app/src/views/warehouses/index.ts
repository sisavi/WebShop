import { IWarehouse } from 'domain/IWarehouse';
import { autoinject } from 'aurelia-framework';
import { WarehouseService } from 'service/warehouse-services';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class WarehousesIndex{
    private _warehouses: IWarehouse[] = [];
   private _alert: IAlertData | null = null;


    constructor(private WarehouseService: WarehouseService){

    }

    attached() {
        this.WarehouseService.getWarehouses().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._warehouses = response.data!;
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