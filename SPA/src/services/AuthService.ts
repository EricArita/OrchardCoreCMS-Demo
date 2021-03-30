import { Log, User, UserManager } from 'oidc-client';
import { endianness } from 'os';

import { Constants } from '../helpers/Constants';

export class AuthService {
  public userManager: UserManager;

  constructor() {
    const settings = {
      authority: Constants.stsAuthority,
      client_id: Constants.clientId,
      redirect_uri: process.env.REACT_APP_REDIRECT_URL,
      silent_redirect_uri: process.env.REACT_APP_SILENT_REDIRECT_URL,
      // tslint:disable-next-line:object-literal-sort-keys
      post_logout_redirect_uri: process.env.REACT_APP_POST_LOGOUT_REDIRECT_URL,
      response_type: 'code',
      scope: Constants.clientScope
    };
    this.userManager = new UserManager(settings);

    Log.logger = console;
    Log.level = Log.INFO;
  }

  public getUser(): Promise<User | null> {
    return this.userManager.getUser();
  }

  async isLoggedIn() {
   const user = await this.userManager.getUser();
    const userCurrent = !!user && !user.expired;
    return userCurrent;

  }

  public login(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public renewToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }
}
