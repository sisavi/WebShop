import { Router } from 'aurelia-router';
import { AppState } from '../../state/app-state';
import { autoinject } from 'aurelia-framework';
import { AccountService } from 'service/account-service';
import {IndexResources} from "../../lang/IndexResources";
import {LayoutResources} from "../../lang/LayoutResources";


@autoinject
export class AccountLogin {

    private _email: string = "";
    private _password: string = "";
    private _errorMessage: string | null = null;
    private emailError = "";
    private passwordError = "";
    private langResources = LayoutResources;

    constructor(private accountService: AccountService, private appState: AppState, private router: Router) {

    }

    onSubmit(event: Event) {
        if(this._email == ""){
            this.emailError = "Please enter email";
            // @ts-ignore
            document.getElementById('popupEmail').style.display = 'block';
            return
        }
        if(this._password == ""){
            this.passwordError = "Please enter password";
            // @ts-ignore
            document.getElementById('popupPassword').style.display = 'block';

            return
        }


        event.preventDefault();

        this.accountService.login(this._email, this._password).then(
            response => {
                if (response.statusCode == 200) {
                    this.appState.jwt = response.data!.token;
                    this.router.navigateToRoute('products-index');
                } else {
                    this._errorMessage = response.statusCode.toString()
                        + ' '
                        + response.errorMessage!
                }
            }
        );
    }

}
