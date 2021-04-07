import axios from 'axios';
import { Constants } from '../helpers/Constants';
import { AuthService } from './AuthService';

export class ApiService {
  private authService: AuthService;

  constructor() {
    this.authService = new AuthService();
  }

  public callApi(body?: any): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._callApi(user.access_token, body).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._callApi(renewedUser.access_token, body);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._callApi(renewedUser.access_token, body);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _callApi(token: string, body?: any) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    if (body !== undefined && body !== null) {
      return axios.post(Constants.apiRoot, body, { headers }).then(res => {
        return res.data;
      });
    }
    
    return axios.get(Constants.apiRoot + '?query={subscriber {createdUtc, displayText email firstName lastName modifiedUtc publishedUtc contentItemId }}', { headers }).then(res => {
      return res.data.data.subscriber
    });
  }

  public getSubscriber(id: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._getSubscriber(id, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._getSubscriber(id, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._getSubscriber(id, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _getSubscriber(id: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    return axios.get(Constants.apiContent + '/' + id, { headers });
  }

  public updateSubscriber(id: string, firstName: string, lastName: string, email: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._updateSubscriber(id, firstName, lastName, email, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._updateSubscriber(id, firstName, lastName, email, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._updateSubscriber(id, firstName, lastName, email, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _updateSubscriber(id: string, firstName: string, lastName: string, email: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    const body = {
      ContentItemId: id,
      DisplayText: firstName + ' ' + lastName,
      TitlePart: {
        Title: firstName + ' ' + lastName
      },
      Subscriber: {
        FirstName: {
          Text: firstName
        },
        LastName: {
          Text: lastName
        },
        Email: {
          Text: email
        }
      },
      ContainedPart: {
        ListContentItemId: '462m1ps5kkzkp2k5da5pfhh2ww',
        Order: 0
      }
    }

    return axios.post(Constants.apiContent, body, { headers });
  }

  public deleteSubscriber(id: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._deleteSubscriber(id, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._deleteSubscriber(id, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._deleteSubscriber(id, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _deleteSubscriber(id: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    return axios.delete(Constants.apiContent + '/' + id, { headers });
  }  

  public createSubscriber(firstName: string, lastName: string, email: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._createSubscriber(firstName, lastName, email, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._createSubscriber(firstName, lastName, email, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._createSubscriber(firstName, lastName, email, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _createSubscriber(firstName: string, lastName: string, email: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    const body = {
      ContentType: 'Subscriber',
      Latest: true,
      Published: true,
      Owner: 'sales',
      Author: 'sales',
      DisplayText: firstName + ' ' + lastName,
      TitlePart: {
        Title: firstName + ' ' + lastName
      },
      Subscriber: {
        FirstName: {
          Text: firstName
        },
        LastName: {
          Text: lastName
        },
        Email: {
          Text: email
        }
      },
      ContainedPart: {
        ListContentItemId: '462m1ps5kkzkp2k5da5pfhh2ww',
        Order: 0
      }
    }

    return axios.post(Constants.apiContent, body, { headers });
  }  

  public getAllContentTypes() {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._getAllContentTypes(user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._getAllContentTypes(renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._getAllContentTypes(renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _getAllContentTypes(token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    return axios.get(`${Constants.apiDocument}/content-type/all`, { headers });
  }

  public createTOR(title: string, description: string, assignee: string, status: string, stage: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._createTOR(title, description, assignee, status, stage, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._createTOR(title, description, assignee, status, stage, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._createTOR(title, description, assignee, status, stage, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _createTOR(title: string, description: string, assignee: string, status: string, stage: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    const body = {
      ContentType: 'TOR',
      Latest: true,
      Published: true,
      Owner: 'admin',
      Author: 'admin',
      DisplayText: title,
      TOR: {
        Description: {
          Text: description
        },
        Status: {
          Text: status
        },
        Stage: {
          Text: stage
        },
        // Assignee: {
        //   ContentItemIds: [
        //     assignee
        //   ]
        // }
      },
      TitlePart: {
        Title: title
      }
    }
    return axios.post(Constants.apiContent, body, { headers });
  }

  public getAllRoles() {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._getRoles(user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._getRoles(renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._getRoles(renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _getRoles(token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    return axios.get(`${Constants.apiDocument}/roles/all`, { headers });
  }

  public createRole(roleName: string, roleDescription: string): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._createRole(roleName, roleDescription, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._createRole(roleName, roleDescription, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._createRole(roleName, roleDescription, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _createRole(roleName: string, roleDescription: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    const body = {
      roleName,
      roleDescription
    }
    return axios.post(Constants.apiDocument + "/roles/create-new-role", body, { headers });
  }

  public getAllPermissions(roleName: string) {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._getAllPermissions(roleName, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._getAllPermissions(roleName, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._getAllPermissions(roleName, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _getAllPermissions(roleName: string, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    return axios.get(`${Constants.apiDocument}/role/get-permissions/${roleName}`, { headers });
  }

  public updateRole(requestBody: any): Promise<any> {
    return this.authService.getUser().then(user => {
      if (user && user.access_token) {
        return this._updateRole(requestBody, user.access_token).catch(error => {
          if (error.response.status === 401) {
            return this.authService.renewToken().then(renewedUser => {
              return this._updateRole(requestBody, renewedUser.access_token);
            });
          }
          throw error;
        });
      } else if (user) {
        return this.authService.renewToken().then(renewedUser => {
          return this._updateRole(requestBody, renewedUser.access_token);
        });
      } else {
        throw new Error('user is not logged in');
      }
    });
  }

  private _updateRole(requestBody: any, token: string) {
    const headers = {
      Accept: 'application/json',
      Authorization: 'Bearer ' + token
    };

    console.log(requestBody);
    return axios.post(Constants.apiDocument + "/role/update", requestBody, { headers });
  }
}
