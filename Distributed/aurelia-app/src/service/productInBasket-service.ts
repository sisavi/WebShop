import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { IProductInBasket } from 'domain/IProductInBasket';
import { IFetchResponse } from 'types/IFetchResponse';
import { IProductInBasketCreate } from 'domain/IProductInBasketCreate';
import { AppState } from 'state/app-state';

@autoinject
export class ProductInBasketService {
    constructor(private appState: AppState, private httpClient: HttpClient) {
        this.httpClient.baseUrl = this.appState.baseUrl;
    }

    //private readonly _baseUrl = 'Owners';
    private readonly _baseUrl = 'productinbaskets'


    async getProductsInBasket(): Promise<IFetchResponse<IProductInBasket[]>> {
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
                const data = (await response.json()) as IProductInBasket[];
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

    async getUserProductsInBasket(id:string): Promise<IFetchResponse<IProductInBasket[]>> {
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl + "/userProducts/" + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });
            // happy case
            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IProductInBasket[];
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
    async getTotal(id:string): Promise<IFetchResponse<number>>{
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl + '/userTotal/' + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as number;
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



    async getProductInBasket(id: string): Promise<IFetchResponse<IProductInBasket>> {
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl + '/' + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IProductInBasket;
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



    async createProductInBasket(productInBasket: IProductInBasketCreate): Promise<IFetchResponse<string>> {
        try {
            const response = await this.httpClient
                .post(this._baseUrl, JSON.stringify(productInBasket), {
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


    async addProductToShoppingCart(connection: IProductInBasketCreate): Promise<IFetchResponse<string>> {
        console.log("lisan toote")
        try {
            const response = await this.httpClient
                .post(this.appState.baseUrl + 'ProductInBaskets', JSON.stringify(connection), {
                    cache: 'no-store',
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                })

            if (response.status >= 200 && response.status < 300) {
                console.log("lisatud")
                console.log('response', response);
                return {
                    statusCode: response.status
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

    async removeFromShoppingCart(connectionId: string): Promise<IFetchResponse<string>> {
        try {
            const response = await this.httpClient
                .delete(this.appState.baseUrl + 'productinbaskets/' + connectionId, null, {
                    cache: 'no-store',
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });

            if (response.status >= 200 && response.status < 300) {
                return {
                    statusCode: response.status
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
