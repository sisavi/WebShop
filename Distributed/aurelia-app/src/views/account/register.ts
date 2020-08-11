import {autoinject, LogManager} from 'aurelia-framework';
import {AccountService} from 'service/account-service';
import {AppState} from 'state/app-state';
import {Router} from 'aurelia-router';
import {AlertType} from "../../types/AlertType";
import {IAlertData} from "../../types/IAlertData";
import {LayoutResources} from "../../lang/LayoutResources";


@autoinject
export class AccountRegister {
    private langResources = LayoutResources;
    private _alert: IAlertData | null = null;
    private _email: string = "";
    private password: string = "";
    private _firstname: string = "";
    private _lastname: string = "";
    private confirmPassword: string = "";
    private _errorMessage: string | null = null;
    private emailError = "";
    private firstNameError = "";
    private lastNameError = "";
    private passwordError = "";
    private passwordConfirmError = "";


    constructor(
        private accountService: AccountService,
        private appState: AppState,
        private router: Router
    ) {

    }

    attached() {

    }

    submit(): void {
        if (this._email == "") {
            this.emailError = "Please enter email";
            // @ts-ignore
            document.getElementById('popupEmail').style.display = 'block';
            return
        }
        if (this._firstname == "") {
            this.firstNameError = "Please enter first name";
            // @ts-ignore
            document.getElementById('popupFirstName').style.display = 'block';
            return
        }
        if (this._lastname == "") {
            this.lastNameError = "Please enter last name";
            // @ts-ignore
            document.getElementById('popupLastName').style.display = 'block';

            return
        }/**
         if(this._phoneNr=="" || this._phoneNr.length > 20){
            this.phoneNrError = "Please enter valid phone number";
            // @ts-ignore
            document.getElementById('popupPhoneNr').style.display = 'block';

            return
        }
         **/


        if (this.confirmPassword == "") {
            this.passwordConfirmError = "Please confirm your password";
            // @ts-ignore
            document.getElementById('popupPasswordConfirm').style.display = 'block';

            return
        }
        if (this.password != this.confirmPassword) {
            this.passwordError = "Passwords do not match";
            // @ts-ignore
            document.getElementById('popupPassword').style.display = 'block';

            this.passwordConfirmError = "Passwords do not match";
            // @ts-ignore
            document.getElementById('popupPassword').style.display = 'block';
            return
        }
        if (this.password == "") {
            this.passwordError = "Please enter password";
            // @ts-ignore
            document.getElementById('popupPassword').style.display = 'block';

            return
        }


        //this._phoneNr
        this.accountService.register(this._email, this.password, this._firstname, this._lastname,)
            .then(response => {
                if (response !== undefined && response.status >= 200 && response.status < 300) {
                    this.router.navigateToRoute('products-index');
                    this.appState.jwt = response.token;



                }
            });
    }
}
