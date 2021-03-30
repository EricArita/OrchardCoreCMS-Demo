import { combineReducers } from "redux";
import { GraphQLReducer } from "./GrapQLReducer";

const rootReducer = combineReducers({ 
    graphQL: GraphQLReducer 
});

export default rootReducer;