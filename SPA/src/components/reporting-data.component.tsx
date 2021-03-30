import React, { Component } from "react";
import { ApiService } from '../services/ApiService';
import { graphqlLodash } from 'graphql-lodash';
import QueryBuiderTreeView from './QueryBuilderTreeView';
import { Grid, WithStyles, withStyles, Button } from "@material-ui/core";
import { connect } from "react-redux";

const styles = {
    root: {
        border: 'solid 1px purple'
    },
    resultPart: {
        border: 'solid 1px green'
    },
    queryPart: {
        border: 'solid 1px red'
    },
};

interface Props extends WithStyles<typeof styles> {
    query: string,
    queryVariables: object
}

interface State {
    contentType: string
    reportingData: Array<object> | object | undefined
}

class ReportingData extends Component<Props, State> {
    private apiService: ApiService;

    constructor(props: Readonly<Props>) {
        super(props)

        this.apiService = new ApiService()

        // Setting up functions
        this.lodashQuery = this.lodashQuery.bind(this);

        // Setting up state
        this.state = {
            contentType: "",
            reportingData: undefined
        }
    }

    private lodashQuery = async () => {
        const gqlWithLodashQuery = this.props.query;
        const queryVariables = this.props.queryVariables;

        if (gqlWithLodashQuery.length === 0 || Object.keys(queryVariables).length === 0) return;

        let { query, transform } = graphqlLodash(gqlWithLodashQuery);

        let body = {
            query,
            variables: {
                ...queryVariables,
                //groupBy: "displayText"
            }
        }

        let result = await this.apiService.callApi(body);
        result.data = transform(result.data);
        this.setState({
            reportingData: result.data
        });
    }


    render() {
        const { classes } = this.props;
        return (
            <Grid container>
                <Grid item xs={3} className={classes.queryPart}>
                    <QueryBuiderTreeView />
                </Grid>
                <Grid item xs={9} className={classes.resultPart}>
                    <Button variant="contained" color="primary" onClick={() => this.lodashQuery()}>
                        Get report
                    </Button>
                    <div>
                        {JSON.stringify(this.state.reportingData)}
                    </div>
                </Grid>
                {/* {
                    this.state.data == null || this.state.data == [] ? null : this.state.data.map(({ contentType, displayText }: any, index: number) =>
                        <div key={index}>
                            <span>Content Type: {contentType}</span><br />
                            <span>Display: {displayText} </span>
                        </div>
                    )
                } */}
            </Grid>
        );
    }
}

const mapStateToProps = (state: any) => ({
    query: state.graphQL.query,
    queryVariables: state.graphQL.queryVariables
})

export default connect(mapStateToProps, null)(withStyles(styles)(ReportingData));
