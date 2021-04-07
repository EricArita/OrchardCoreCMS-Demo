import React, { Component } from "react";
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { ApiService } from '../services/ApiService';

interface Props {
  history: any
}

interface States {
  roleName: string,
  description: string
}


export default class CreateRole extends Component<Props, States> {
  apiService: ApiService;
  
  constructor(props: Readonly<Props>) {
    super(props)

    this.apiService = new ApiService();
    this.onChangeRoleDescription = this.onChangeRoleDescription.bind(this);
    this.onChangeRoleName = this.onChangeRoleName.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      roleName: "",
      description: ""
    }
  }

  componentDidMount() {
   
  }

  onChangeRoleName(e: any) {
    this.setState({
      roleName: e.target.value
    });
  }

  onChangeRoleDescription(e: any) {
    this.setState({
      description: e.target.value
    });
  }

  async onSubmit(e: any) {
    e.preventDefault()

    const res = await this.apiService.createRole(this.state.roleName, this.state.description);

    this.props.history.push('/subscriber-list')
  }

  render() {
    return (<div className="form-wrapper">
      <Form onSubmit={this.onSubmit}>
        <Form.Group controlId="Name">
          <Form.Label>Role name</Form.Label>
          <Form.Control type="text" value={this.state.roleName} onChange={this.onChangeRoleName} />
        </Form.Group>

        <Form.Group controlId="Description">
          <Form.Label>Role Description</Form.Label>
          <Form.Control type="text" value={this.state.description} onChange={this.onChangeRoleDescription} />
        </Form.Group>

        <Button variant="danger" size="lg" block={true} type="submit" style={{marginTop: '60px'}}>
          Create
        </Button>
      </Form>
    </div>);
  }
}
