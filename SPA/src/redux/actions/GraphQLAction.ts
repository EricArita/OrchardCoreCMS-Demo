export const saveQuery = (payload: object) => ({
    type: "SAVE_QUERY",
    payload
});

export const saveQueryVariables = (payload: object) => ({
    type: "SAVE_QUERY_VARIABLES",
    payload
});