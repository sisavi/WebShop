import {AppState} from "../state/app-state";
import {HttpClient} from "aurelia-fetch-client";
import {IFetchResponse} from "../types/IFetchResponse";
import {IDeliveryType} from "../domain/IDeliveryType";
import {autoinject} from "aurelia-framework";
@autoinject
export class DeliveryTypeService {
    constructor(private appState: AppState, private httpClient: HttpClient) {
        this.httpClient.baseUrl = this.appState.baseUrl;
    }

    private readonly _baseUrl = "deliveryType";


    async getDeliveryTypes(): Promise<IFetchResponse<IDeliveryType[]>> {
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
                const data = (await response.json()) as IDeliveryType[];
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
