
import { AlertType } from './../../types/AlertType';
import { autoinject } from 'aurelia-framework';
import { AccountService } from 'service/account-service';
import { IAccount} from 'domain/IAccount';
import { IAlertData } from 'types/IAlertData';

@autoinject
export class PersonsIndex {
    private _account: IAccount[] = [];

    private _alert: IAlertData | null = null;

    constructor(private accountSrevice: AccountService) {

    }

    attached() {
        this.accountSrevice.getAccounts().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._account = response.data!;
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
