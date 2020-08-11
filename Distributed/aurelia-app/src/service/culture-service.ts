import { autoinject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import { IFetchResponse } from 'types/IFetchResponse';
import { ICulture } from 'domain/ICulture';
import {BaseService} from "./IBaseService";

@autoinject
export class CultureService extends BaseService<ICulture> {

    constructor(protected httpClient: HttpClient){
        super('Cultures', httpClient);
    }


    async getAll(): Promise<IFetchResponse<ICulture[]>> {
        console.log("olen siin")
        console.log(this.apiEndpointUrl)
        try {
            const response = await this.httpClient
                .fetch(this.apiEndpointUrl, {
                    cache: "no-store"
                });
            // happy casec
            console.log(response.status)
            if (response.status >= 200 && response.status < 300) {
                const data = (await response.json()) as ICulture[];
                console.log(data);
                console.log("im here")
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
