import React, { Component } from "react";
import Table from 'react-bootstrap/Table';
import TableRow from './TableRow';
import { ApiService } from '../services/ApiService';

interface Props {
  type: string
}

interface States {
  subscribers: object[],
  roles: object[]
}

export default class ListView extends Component<Props, States> {
  apiService: ApiService;
  token = '';

  constructor(props: Readonly<Props>) {
    super(props)
    this.state = {
      subscribers: [],
      roles: []
    };

    this.apiService = new ApiService()
    this.renderTableHeaderRow = this.renderTableHeaderRow.bind(this);
  }

  componentDidMount() {
    setTimeout(() => {
      this.apiService.getAllRoles().then(res => {
        this.setState({
          roles: res.data
        });
      })
      .catch((error) => {
        console.log(error);
      })

      // this.apiService.callApi().then(res => {
      //   this.setState({
      //     subscribers: res
      //   });
      // })
      // .catch((error) => {
      //   console.log(error);
      // })
    }, 500);

  }

  DataTable(type: string) {
    switch (type) {
      case "role":
        return this.state.roles.map((role, i) => {
          return <TableRow type={"role"} data={role} stt={i+1} key={i} />;
        });
      default:
        return this.state.subscribers.map((role, i) => {
          return <TableRow type={""} data={role} stt={i+1} key={i} />;
        });
    }
  }

  renderTableHeaderRow(type: string) {
    switch (type) {
      case "role":
        return (
          <tr>
            <th>Stt</th>
            <th>Role Name</th>
            <th>Description</th>
            <th>Action</th>
          </tr>
        );
      default:
        return (
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Action</th>
          </tr>
        );
    }
  }

  render() {
    return (
      <div className="table-wrapper">
        <Table striped bordered hover>
          <thead>
            {this.renderTableHeaderRow(this.props.type)}
          </thead>
          <tbody>
            {this.DataTable(this.props.type)}
          </tbody>
        </Table>
      </div>
    )
  }
}