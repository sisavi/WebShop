import {autoinject} from 'aurelia-framework';
import {ProductService} from 'service/product-service';
import {RouteConfig, NavigationInstruction, Router} from 'aurelia-router';
import {IAlertData} from 'types/IAlertData';
import {AlertType} from 'types/AlertType';
import {IWarehouse} from "domain/IWarehouse";
import {IProduct} from "domain/IProduct";
import {WarehouseService} from "../../service/warehouse-services";
import {IProductInWarehouse} from "domain/IProductInWarehouse";
import {ProductInWarehouseService} from "service/productInWarehouse-service";
import {IWarehouseIndex} from "../../domain/IWarehouseIndex";

@autoinject
export class ProductInWarehouseDetails {
    private _warehouse?: IWarehouse;
    private _product?: IProduct;
    private _productsInWarehouse: IProductInWarehouse[] = [];
    private _warehouseIndex: IWarehouseIndex[] = [];
    private _alert: IAlertData | null = null;

    constructor(private productService: ProductService,
                private productInWarehouseService: ProductInWarehouseService,
                private warehouseService: WarehouseService) {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        if (params.id) {
            this.warehouseService.getWarehouse(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._warehouse = response.data!;
                        this.getProductsInWarehouse(response.data!.id)


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
        this.getIndexView()
    }

    attached() {

        //console.log(this._warehouseIndex)

        //console.log(this._warehouseIndex)


    }

    getIndexView() {
        console.log(this._productsInWarehouse)
        for (let item of this._productsInWarehouse) {
            console.log("------------------------------------------------------")
            console.log(item.productId)
            console.log("name:  " + this.getProductName(item.productId))
            var name = this.getProductName(item.productId)
            console.log(name)
            let itemToPush: IWarehouseIndex = {

                productName: name,
                productId: item.productId,
                warehouseId: item.warehouseId,
                quantity: item.quantity

            }
            console.log(itemToPush)
            this._warehouseIndex.push(itemToPush)

        }

    }

    getProductName(id: string): string {
        //console.log(id)

        let name: string
        this.productService.getProductName(id).then(response => {

                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    console.log("--------------------")
                    console.log(response.data)
                    name = response.data!
                    return response.data!
                    console.log()
                }
            }
        );
        return name!;
    }


    getProductsInWarehouse(id: string) {
        this.productInWarehouseService.getProductsInWarehouse(id).then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._productsInWarehouse = response.data!;
                    this.getIndexView();
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
        console.log(this._productsInWarehouse)
    }
}
