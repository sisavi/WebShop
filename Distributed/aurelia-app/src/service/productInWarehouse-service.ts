import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { IFetchResponse } from 'types/IFetchResponse';
import { AppState } from 'state/app-state';
//import { IWarehouseEdit } from 'domain/IWarehouseEdit';
import { IProductInWarehouse} from 'domain/IProductInWarehouse';
import {IProductEdit} from "../domain/IProductEdit";
//import { IWarehouseCreate } from 'domain/IWarehouseCreate';

@autoinject
export class ProductInWarehouseService {
    constructor(private appState: AppState, private httpClient: HttpClient) {
        this.httpClient.baseUrl = this.appState.baseUrl;
    }

    //private readonly _baseUrl = 'Owners';
    private readonly _baseUrl = "ProductInWarehouses";


    async getProductInWarehouses(): Promise<IFetchResponse<IProductInWarehouse[]>> {
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });
            // happy case
            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IProductInWarehouse[];
                return {
                    statusCode: response.status,
                    data: data
                }
            }

            // something went wrong
            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }

        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }


    async getProductInWarehouse(id: string): Promise<IFetchResponse<IProductInWarehouse>> {
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl + '/' + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IProductInWarehouse;
                return {
                    statusCode: response.status,
                    data: data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }

        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

    async getProductsInWarehouse(id: string): Promise<IFetchResponse<IProductInWarehouse[]>> {
        try {

            console.log(this._baseUrl + '/WarehouseProducts/' + id)
            const response = await this.httpClient
                .fetch(this._baseUrl + '/WarehouseProducts/' + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            console.log(response.status)
            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IProductInWarehouse[];
                console.log(data)
                return {
                    statusCode: response.status,
                    data: data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }

        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

    async updateProductInWarehouse(productInWarehouse: IProductInWarehouse): Promise<IFetchResponse<string>> {
        console.log("....................")
        console.log(this._baseUrl)
        console.log("....................")
        try {
            const response = await this.httpClient
                .put(this._baseUrl + '/UpdatedWarehouseProduct/' + productInWarehouse.id, JSON.stringify(productInWarehouse), {
                    cache: 'no-store',
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            console.log(response.status)
            if (response.status >= 200 && response.status < 300) {
                return {
                    statusCode: response.status
                    // no data
                }
            }
            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        }
        catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }


    async createProductInWarehouse(productInWarehouse: IProductInWarehouse): Promise<IFetchResponse<string>> {
        try {
            const response = await this.httpClient
                .post(this._baseUrl, JSON.stringify(productInWarehouse), {
                    cache: 'no-store',
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                })

            if (response.status >= 200 && response.status < 300) {
                return {
                    statusCode: response.status
                    // no data
                }
            }

            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        }
        catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

    async deleteWarehouse(id: string): Promise<IFetchResponse<string>> {

        try {
            const response = await this.httpClient
                .delete(this._baseUrl + '/' + id, null, {
                    cache: 'no-store',
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            if (response.status >= 200 && response.status < 300) {
                return {
                    statusCode: response.status
                    // no data
                }
            }
            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }
        }
        catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }


}
