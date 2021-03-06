import { ICampaign } from 'domain/ICampaign';
import { autoinject } from 'aurelia-framework';
import { CampaignService } from 'service/campaign-service';
import { NavigationInstruction, RouteConfig } from 'aurelia-router';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class CampaignsDetails{
    private _campaign?: ICampaign;    
    private _alert: IAlertData | null = null;

    constructor(private campaignService: CampaignService){

    }

    attached() {
       
    }
    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params);
        if (params.id && typeof (params.id) == 'string') {
            this.campaignService.getCampaign(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._campaign = response.data!;
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        this._campaign = undefined;
                    }
                }                
            );
        }
    }

}