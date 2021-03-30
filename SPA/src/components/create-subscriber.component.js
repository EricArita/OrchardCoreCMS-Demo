import React, { Component } from "react";
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import { AuthService } from '../services/AuthService';
import { ApiService } from '../services/ApiService';

export default class CreateTOR extends Component {

  constructor(props) {
    super(props)

    this.authService = new AuthService()
    this.apiService = new ApiService()

    // Setting up functions
    this.onChangeTORTitle = this.onChangeTORTitle.bind(this);
    this.onChangeTORDescription = this.onChangeTORDescription.bind(this);
    this.onChangeTORAssignee = this.onChangeTORAssignee.bind(this);
    this.onChangeTORStatus = this.onChangeTORStatus.bind(this);
    this.onChangeTORStage = this.onChangeTORStage.bind(this);
    this.getAllUsers = this.getAllUsers.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    // Setting up state
    this.state = {
      title: '',
      description: '',
      status: 'pending',
      stage: '',
      contentItemId: '',
      assignee: '',
      users: []
    }
  }

  componentDidMount() {
    this.getAllUsers();
  }

  async getAllUsers(){
    let body = {
      query: `query getUsers {
                user(orderBy: {displayText: ASC}) {
                  contentItemId
                  displayText
                }
              }`
    }

    let result = await this.apiService.callApi(body);
    this.setState({users: result.data.user, assignee: result.data.user[0].contentItemId});
  }

  onChangeTORTitle(e) {
    this.setState({ title: e.target.value })
  }

  onChangeTORDescription(e) {
    this.setState({ description: e.target.value })
  }

  onChangeTORAssignee(e) {
    this.setState({ assignee: e.target.value })
  }

  onChangeTORStatus(e) {
    this.setState({ status: e.target.value })
  }

  onChangeTORStage(e) {
    this.setState({ stage: e.target.value })
  }

  async onSubmit(e) {
    e.preventDefault()

    const TORObject = {
      title: this.state.title,
      description: this.state.description,
      assignee: this.state.assignee,
      stage: this.state.stage,
      status: this.state.status
    };

    let res = await this.apiService.createTOR(TORObject.title, TORObject.description, TORObject.assignee, TORObject.status, TORObject.stage);      
    
    if (res.status === 200) {
      //call api api to n8n
      console.log(res.data.ContentItemId);
      const body = {
        contentItemId: res.data.ContentItemId,
        stage: TORObject.stage,
        status: TORObject.status
      }

      res = await this.apiService.callN8N(body);
      console.log(res);
    }

    this.setState({
      title: '',
      description: '',
      assignee: '',
      stage: '',
      status: ''
    });
    

    // Redirect to TOR List 
    //this.props.history.push('/subscriber-list')
  }

  render() {
    return (<div className="form-wrapper">
      <Form onSubmit={this.onSubmit}>
        <Form.Group controlId="Title">
          <Form.Label>Title</Form.Label>
          <Form.Control type="text" value={this.state.title} onChange={this.onChangeTORTitle} />
        </Form.Group>

        <Form.Group controlId="Description">
          <Form.Label>Description</Form.Label>
          <Form.Control type="text" value={this.state.description} onChange={this.onChangeTORDescription} />
        </Form.Group>
       
        <Form.Group controlId="Stage">
          <Form.Label>Stage</Form.Label>
          <Form.Control type="text" value={this.state.stage} onChange={this.onChangeTORStage} />
        </Form.Group>

        <Form.Group controlId="Assignee">
          <Form.Label>Assignee</Form.Label>
          <Form.Control onChange={this.onChangeTORAssignee} defaultValue={this.state.assignee} as="select">
            {
              this.state.users.map(user => (
                <option key={user.contentItemId} value={user.contentItemId}>{user["displayText"]}</option>
              ))
            }
          </Form.Control>
        </Form.Group>

        <Form.Group controlId="Status">
          <Form.Label>Status</Form.Label>
          <Form.Control onChange={this.onChangeTORStatus} as="select">
            <option key={1} value={"Pending"}>Pending</option>
            <option key={2} value={"Submitted"}>Submitted</option> 
            <option key={3} value={"Approved"}>Approved</option>
            <option key={4} value={"Rejected"}>Rejected</option>
          </Form.Control>
        </Form.Group>

        <Button variant="danger" size="lg" block="block" type="submit" style={{marginTop: '60px'}}>
          Create TOR
        </Button>
      </Form>
    </div>);
  }
}
