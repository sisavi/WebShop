import {IFetchResponse} from "../types/IFetchResponse";
import {IBasket} from "../domain/IBasket";
import {autoinject} from "aurelia-framework";
import {AppState} from "../state/app-state";
import {HttpClient} from "aurelia-fetch-client";


@autoinject
export class BasketService {
    constructor(private appState: AppState, private httpClient: HttpClient) {
        this.httpClient.baseUrl = this.appState.baseUrl;
    }

    private readonly _baseUrl = 'baskets'

    async getBasketByAppUser(id: string): Promise<IFetchResponse<IBasket>> {
        try {
            const response = await this.httpClient
                .fetch(this._baseUrl + '/UserBasket/' + id, {
                    cache: "no-store",
                    headers: {
                        authorization: "Bearer " + this.appState.jwt
                    }
                });
            // happy case
            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as IBasket;
                console.log(data)
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
}
