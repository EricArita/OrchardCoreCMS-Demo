import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import { TreeItem, TreeView } from '@material-ui/lab';
import { ApiService } from '../services/ApiService';
import { saveQuery, saveQueryVariables } from '../redux/actions/GraphQLAction';
import { connect } from 'react-redux';

const useStyles = makeStyles({
    root: {
        flexGrow: 1,
        maxWidth: 400,
        marginTop: '20px'
    },
});

interface Props {
    saveQuery: (payload: any) => any
    saveQueryVariables: (payload: any) => any
}

const QueryBuiderTreeView = (props: Props) => {
    const classes = useStyles();
    const [expanded, setExpanded] = React.useState<string[]>([]);
    const [selected, setSelected] = React.useState<string[]>([]);
    const [contentTypes, setContentTypes] = React.useState<string[]>([]);
    const [selectedContentType, setSelectedContentType] = useState("");
    const [reportData, setReportData] = useState(undefined);
    const [queryVariables, setQueryVariables] = useState({});

    const apiService = new ApiService();

    useEffect(() => {
        getAllContentTypes()
    }, [])

    useEffect(() => {
        if (!expanded.includes(`content-type-${selectedContentType}`)) {
            setSelectedContentType("");
        }
    }, [expanded, selectedContentType])

    useEffect(() => {
        if (selectedContentType.length !== 0) {
            buildQuery()
        }
    }, [selectedContentType])

    useEffect(() => {
        if (Object.keys(queryVariables).length !== 0) {
            props.saveQueryVariables({ queryVariables });
        }
    }, [queryVariables])

    const getAllContentTypes = async () => {
        let res = await apiService.getAllContentTypes();
        setContentTypes(res.data);
    }

    const buildQuery = () => {
        let queryTemplate: string = `
            query MyQuery($contentType: Boolean = false, 
                          $displayText: Boolean = false) {
                ${selectedContentType}  {
                    contentType @include(if: $contentType)
                    displayText @include(if: $displayText)
                }
            }`;

        props.saveQuery({ query: queryTemplate });

        return queryTemplate;
    }

    const handleNodeToggle = (event: React.ChangeEvent<{}>, nodeIds: string[]) => {
        setExpanded([...nodeIds]);
    };

    const handleOnClickTreeItem = (e: any) => {
        setSelectedContentType(e.target.textContent);
    }

    const handleSelectedOption = (e: any) => {
        setQueryVariables({
            ...queryVariables,
            [e.target.value]: e.target.checked ? true : false
        })
    }

    return (
        <div>
            <TreeView
                className={classes.root}
                defaultCollapseIcon={<ExpandMoreIcon />}
                defaultExpandIcon={<ChevronRightIcon />}
                expanded={expanded}
                selected={selected}
                onNodeToggle={handleNodeToggle}
            >
                {
                    contentTypes.map((contentType, index) =>
                        <TreeItem
                            key={index}
                            nodeId={`content-type-${contentType}`}
                            label={contentType}
                            onLabelClick={handleOnClickTreeItem}
                            onIconClick={handleOnClickTreeItem}
                        >
                            <div>
                                <input id={`option-condition-first-${contentType}`} type="checkbox" />
                                <label htmlFor={`option-condition-first-${contentType}`} style={{ marginLeft: '4px' }}>first</label>
                            </div>

                            <div>
                                <input id={`option-field-displayText-${contentType}`} type="checkbox" value="contentType" onChange={e => handleSelectedOption(e)} />
                                <label htmlFor={`option-field-displayText-${contentType}`} style={{ marginLeft: '4px' }}>contentType</label>
                            </div>

                            <div>
                                <input id={`option-field-contentType-${contentType}`} type="checkbox" value="displayText" onChange={e => handleSelectedOption(e)} />
                                <label htmlFor={`option-field-contentType-${contentType}`} style={{ marginLeft: '4px' }}>displayText</label>
                            </div>
                        </TreeItem>
                    )
                }
            </TreeView>
        </div>
    );
}

const mapDispatchToProps = (dispatch: any) => ({
    saveQuery: (payload: any) => dispatch(saveQuery(payload)),
    saveQueryVariables: (payload: any) => dispatch(saveQueryVariables(payload))
})

export default connect(null, mapDispatchToProps)(QueryBuiderTreeView);