import {IProduct} from 'domain/IProduct';
import {autoinject} from 'aurelia-framework';
import {ProductService} from 'service/product-service';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {IWarehouse} from "domain/IWarehouse";
import {WarehouseService} from "../../service/warehouse-services";
import {IProductInWarehouse} from "domain/IProductInWarehouse";
import {ProductInWarehouseService} from "service/productInWarehouse-service";

@autoinject
export class ProductInWarehouseIndex {
    private _products: IProduct[] = [];
    private _productInWarehouse: IProductInWarehouse[] = [];
    private _warehouses: IWarehouse[]= [];
    private _alert: IAlertData | null = null;


    constructor(private productService: ProductService,
                private productInWarehouseService: ProductInWarehouseService,
                private warehouseService: WarehouseService ) {

    }

    attached() {
        this.productInWarehouseService.getProductInWarehouses().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._productInWarehouse = response.data!;
                    console.log(response.data)

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

        this.warehouseService.getWarehouses().then(
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
