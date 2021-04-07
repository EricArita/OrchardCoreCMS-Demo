import React, { Component } from "react";
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';
import { ApiService } from '../services/ApiService';

interface Props {
  roleName: string
  match: any
}

interface States {
  roleName:  string,
  description: string
  data: any,
  requestBody: RequestBody
}

interface RequestBody {
  selectedPermissions: string[]
}

export default class EditRole extends Component<Props, States> {
  apiService: ApiService;

  constructor(props: Readonly<Props>) {
    super(props);
    
    this.apiService = new ApiService()

    this.onChangeDescription = this.onChangeDescription.bind(this);
    this.onChangeCheckBox = this.onChangeCheckBox.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    // State
    this.state = {
      roleName: this.props.match.params.roleName,
      description: "",
      data: null,
      requestBody: {
        selectedPermissions: []
      }
    }
  }

  async componentDidMount() {
    const res = await this.apiService.getAllPermissions(this.state.roleName);
    await this.setState({data: res.data});

    const selected: string[] = [];
    Object.keys(this.state.data.roleCategoryPermissions).map((category, i) => {
      this.state.data.roleCategoryPermissions[category].map((permission: any, i: any) => {
        if (this.state.data.role.roleClaims.some((claim: {claimValue: string}) => claim.claimValue === permission.name)){
          selected.push(permission.name);
        }
      })
    });

    this.setState({
      requestBody: {
        selectedPermissions: [...selected]
      }
    })
  }

  onChangeDescription (e: any) {
    this.setState({
      description: e.target.value
    })
  }

  onChangeCheckBox = (e: any) => {
    const arr = this.state.requestBody.selectedPermissions;
    if (e.target.checked) {
      this.setState({
        requestBody: {
          selectedPermissions: [...arr, e.target.value]
        }
      })
    }
    else {
      const index = arr.indexOf(e.target.value);
      if (index > -1) {
        arr.splice(index, 1)
        this.setState({
          requestBody: {
            selectedPermissions: [...arr]
          }
        })
      }
    }
  }

  async onSubmit(e: any) {
    e.preventDefault();
    const body = {
      RoleName: this.state.roleName,
      roleDescription: this.state.description,
      ...this.state.requestBody
    }
    await this.apiService.updateRole(body);
    window.location.reload();
  }

  render() {
    return (
      <div>
        <div>
          <h2>Edit Role {this.state.roleName}</h2>
        </div>
        <div className="form-wrapper">
          <Form onSubmit={this.onSubmit}>
            <Form.Group controlId="Descrition">
              <Form.Label>Role Descrition</Form.Label>
              <Form.Control type="text" value={this.state.description} onChange={this.onChangeDescription} />
            </Form.Group>
            <hr></hr>
            <div>
              <h3>Role permissions</h3>
              <div>
                Allow — Permission is granted explicitly. <br />
                Effective — Permission is implied by a higher level permission, or explicitly granted.
              </div>
              <button className="btn btn-success" style={{float: 'right'}} type="submit">
                  Save
              </button>
            </div>
            <div className="permissions">
                {            
                 this.state.data !== null ?
                 Object.keys(this.state.data.roleCategoryPermissions).map((category, i) => (
                    <div key={i}>
                      <div className="permission-category" style={{marginTop: '40px'}}>
                        <h3>{category}</h3>
                        <hr></hr>
                      </div>
                      <div>
                        <Table striped bordered hover>
                          <thead>
                            <tr>
                              <th>Permission</th>
                              <th>Allow</th>
                              <th>Effective</th>
                            </tr>
                          </thead>
                          <tbody>
                            {
                              this.state.data.roleCategoryPermissions[category].map((permission: any, i: any) => (
                                <tr key={i}>
                                  <td>{permission.description}</td>
                                  <td>
                                    <Form.Group controlId={`Allow.${permission.name}`}>
                                      <Form.Control 
                                        type="checkbox" 
                                        size="sm"
                                        value={`${permission.name}`}
                                        defaultChecked={this.state.data.role.roleClaims.some((claim: {claimValue: string}) => claim.claimValue === permission.name)}
                                        onChange={this.onChangeCheckBox}
                                      />
                                    </Form.Group>
                                  </td>
                                  <td>
                                    <Form.Group controlId={`Effective.${permission.name}`}>
                                      <Form.Control 
                                        type="checkbox" 
                                        size="sm" 
                                        defaultChecked={this.state.data.effectivePermissions.includes(permission.name)}
                                        disabled
                                        readOnly
                                      />
                                    </Form.Group>
                                  </td>
                              </tr>
                              ))
                            }
                          </tbody>
                        </Table>
                      </div>
                    </div>
                  )) :
                  ''
                }
            </div>
          </Form>
        </div>
      </div>
    );
  }
}
