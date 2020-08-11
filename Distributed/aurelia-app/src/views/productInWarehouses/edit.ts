import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { ProductService } from 'service/product-service';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import {IProductEdit} from "../../domain/IProductEdit";
import {IProductWarehouseDTO} from "../../domain/IProductWarehouseDTO";
import {ProductInWarehouseService} from "../../service/productInWarehouse-service";
import {WarehouseService} from "../../service/warehouse-services";
import {IProduct} from "../../domain/IProduct";
import {IProductInWarehouse} from "../../domain/IProductInWarehouse";

@autoinject
export class ProductInWarehouseEdit {
    //we need:
    //productId
    //warehouseId
    //quantity
    //id
    private _alert: IAlertData | null = null;
    private _product?: IProduct;
    private _productInWarehouse: IProductInWarehouse = {id: "", quantity: 0 , warehouseId:"", productId: ""}
    private _productDTO?: IProductWarehouseDTO
    private _quantity = 0


    constructor(private productInWarehouseService: ProductInWarehouseService,private productService: ProductService, private warehouseService: WarehouseService,private router: Router) {
    }

    attached() {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        this.warehouseService.getProductInWarehouse(params.id).then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._productInWarehouse = response.data!;
                    this.warehouseService.getProductInWarehouse(response.data!.id).then(
                        response => {
                            if (response.statusCode >= 200 && response.statusCode < 300) {
                                this._alert = null;
                                this._productInWarehouse! = response.data!;
                                this.productService.getProduct(this._productInWarehouse.productId).then(
                                    response => {
                                        if (response.statusCode >= 200 && response.statusCode < 300) {
                                            this._alert = null;
                                            let product = <IProductWarehouseDTO>response.data;
                                            product!.quantity = this._productInWarehouse!.quantity
                                            this._productDTO = product;
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
                        }
                        );
                            } else {
                                // show error message
                                this._alert = {
                                    message: response.statusCode.toString() + ' - ' + response.errorMessage,
                                    type: AlertType.Danger,
                                    dismissable: true,
                                }
                            }
                        });

                    }

    onSubmit(event: Event) {
        this._productInWarehouse.quantity = Number(this._quantity)
        console.log(this._productInWarehouse)
        this.productInWarehouseService
            .updateProductInWarehouse(this._productInWarehouse)
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('productInWarehouses-details', {id: this._productInWarehouse.id});
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
