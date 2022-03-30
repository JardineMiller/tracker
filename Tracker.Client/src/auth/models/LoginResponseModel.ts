export class LoginResponseModel {
    constructor(
        readonly _userId: string,
        readonly _username: string,
        readonly _email: string,
        readonly _token: string
    ) {}

    get userId(): string {
        return this._userId;
    }

    get username(): string {
        return this._username;
    }

    get email(): string {
        return this._email;
    }

    get token(): string {
        return this._token;
    }
}