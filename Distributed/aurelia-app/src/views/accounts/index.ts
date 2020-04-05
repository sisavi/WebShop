import {autoinject} from 'aurelia-framework'
import { AccountService } from 'service/account-service';
import { ValidInterceptorMethodName } from 'aurelia-fetch-client';
import { IAccount } from 'domain/IAccount';
@autoinject
export class AccountsIndex {
    private _accounts: IAccount[] = [];
    
    constructor(private accountService:AccountService){

    }
    /*attached(){
        this.accountService.getAccounts().then(
            data=>this._accounts = data
        );
    }*/


    
}
