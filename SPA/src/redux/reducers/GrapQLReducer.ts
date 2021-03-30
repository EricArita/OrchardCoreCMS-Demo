let initialState = {
    query: "",
    queryVariables: {}
};

export const GraphQLReducer = (state = initialState, action: { type: string; payload: object }) => {
    switch (action.type) {
        case "SAVE_QUERY":
        case "SAVE_QUERY_VARIABLES":
            return {
                ...state,
                ...action.payload
            };
        default:
            return state;
    }
};