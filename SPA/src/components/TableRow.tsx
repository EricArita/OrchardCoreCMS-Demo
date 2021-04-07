import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import { ApiService } from '../services/ApiService';

interface Props {
    data: any,
    type: string,
    stt: number
}

interface States {

}

export default class TableRow extends Component<Props, States> {
    apiService: ApiService;

    constructor(props: Readonly<Props>) {
        super(props);
        this.apiService = new ApiService()
        this.delete = this.delete.bind(this);
        this.state = {
        };
    }

    delete() {
        // this.apiService.delete(this.props.data.contentItemId).then(() => {
        //     window.location.reload()
        // });
    }

    renderTableRow(type: string) {
        switch (type) {
            case "role": 
                return (
                    <tr>
                        <td>{this.props.stt}</td>
                        <td>{this.props.data.name}</td>
                        <td>{this.props.data.description}</td>
                        <td>
                            <Link className="edit-link" to={`/edit-role/${this.props.data.name}`}>
                                &nbsp;&nbsp;Edit&nbsp;&nbsp;
                            </Link>
                            <Button onClick={this.delete} size="sm" variant="danger">Delete</Button>
                        </td>
                    </tr>
                );
            default:
                return (
                    <tr>
                        <td>{this.props.data.firstName}</td>
                        <td>{this.props.data.lastName}</td>
                        <td>{this.props.data.email}</td>
                        <td>
                            <Link className="edit-link" to={"/edit-/" + this.props.data.contentItemId}>
                                &nbsp;&nbsp;Edit&nbsp;&nbsp;
                            </Link>
                            <Button onClick={this.delete} size="sm" variant="danger">Delete</Button>
                        </td>
                    </tr>
                );
        }
    }

    render() {
        return this.renderTableRow(this.props.type);
    }
}