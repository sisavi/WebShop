import { ICampaign } from 'domain/ICampaign';
import { autoinject } from 'aurelia-framework';
import { CampaignService } from 'service/campaign-service';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class AccountsIndex{
    private _campaigns: ICampaign[] = [];
   private _alert: IAlertData | null = null;


    constructor(private campaignService: CampaignService){

    }

    attached() {
        this.campaignService.getCampaigns().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._campaigns = response.data!;
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