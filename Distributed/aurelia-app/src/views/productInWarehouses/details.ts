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
import {IProductWarehouseDTO} from "../../domain/IProductWarehouseDTO";

@autoinject
export class ProductInWarehouseDetails {
    private _warehouse?: IWarehouse;
    private _product?: IProduct;
    private _productsInWarehouse: IProductInWarehouse[] = [];
    private _products: IProductWarehouseDTO[] = [];
    private _warehouseIndex: IWarehouseIndex[] = [];
    private _alert: IAlertData | null = null;

    constructor(private productService: ProductService,
                private productInWarehouseService: ProductInWarehouseService,
                private warehouseService: WarehouseService) {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log("activate")
        if (params.id && typeof (params.id) == 'string') {
            this.warehouseService.getWarehouse(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._warehouse = response.data!;
                        this.warehouseService.getProductsInWarehouse(response.data!.id).then(
                            response => {
                                if (response.statusCode >= 200 && response.statusCode < 300) {
                                    this._alert = null;
                                    this._productsInWarehouse! = response.data!;
                                    for (let i = 0; i < this._productsInWarehouse.length; i++) {
                                        this.productService.getProduct(this._productsInWarehouse[i].productId).then(
                                            response => {
                                                if (response.statusCode >= 200 && response.statusCode < 300) {
                                                    this._alert = null;
                                                    let product = <IProductWarehouseDTO>response.data;
                                                    product!.quantity = this._productsInWarehouse[i].quantity
                                                    this._products.push(<IProductWarehouseDTO>product)
                                                    console.log(this._products)
                                                } else {
                                                    // show error message
                                                    this._alert = {
                                                        message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                                        type: AlertType.Danger,
                                                        dismissable: true,
                                                    }
                                                }
                                            }
                                        )
                                    }
                                } else {
                                    // show error message
                                    this._alert = {
                                        message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                        type: AlertType.Danger,
                                        dismissable: true,
                                    }
                                }
                            }
                        )

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

    }

}
