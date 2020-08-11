import jwt_decode from 'jwt-decode';
import JwtDecode from "jwt-decode";

export class AppState {
    private roles = [];

    constructor() {
    }

    public readonly baseUrl = 'https://localhost:5001/api/v1.0/';

    // Json 
    // to keep track of logged in status
    // https://developer.mozilla.org/en-US/docs/Web/API/Window/localStorage
    get jwt(): string | null {
        return localStorage.getItem('jwt');
    }


    get token() {
        let roles = null;
        if (this.jwt !== null) {
            const decoded = jwt_decode(this.jwt)
            // @ts-ignore
            roles = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        }
        this.roles = roles;
        if (this.roles != null && this.roles.length > 1) {
            return roles[1].toString();
        }
        return;
    }

    set jwt(value: string | null) {
        if (value) {
            localStorage.setItem('jwt', value);
        } else {
            localStorage.removeItem('jwt');
        }
    }

    get userId() {
        let value = localStorage.getItem('jwt');
        if (value != null) {
            const decoded = JwtDecode<Record<string, string>>(value);
            return decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        }
    }

    get getUserRole() {
        let value = localStorage.getItem('jwt');
        if (value != null) {
            const decoded = JwtDecode<Record<string, string>>(value);
            return decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        }
    }

    get userFirstName() {
        let value = localStorage.getItem('jwt');
        if (value != null) {
            const decoded = JwtDecode<Record<string, string>>(value);
            return decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'];
        }
    }


}
