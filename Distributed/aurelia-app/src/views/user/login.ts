import { Router } from 'aurelia-router';
import { AppState } from './../../state/app-state';
import { autoinject } from 'aurelia-framework';
import { UserService } from 'service/user-service';

@autoinject
export class UserLogin {

    private _email: string = "";
    private _password: string = "";
    private _errorMessage: string | null = null;

    constructor(private userService: UserService, private appState: AppState, private router: Router) {

    }

    onSubmit(event: Event) {
        console.log(this._email, this._password);
        event.preventDefault();

        this.userService.login(this._email, this._password).then(
            response => {
                console.log(response);
                if (response.statusCode == 200) {
                    this.appState.jwt = response.data!.token;
                    this.router!.navigateToRoute('home');
                } else {
                    this._errorMessage = response.statusCode.toString()
                        + ' '
                        + response.errorMessage!
                }
            }
        );
    }

}
