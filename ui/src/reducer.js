import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import customersReducer from './containers/Customers/reducer';

const createRootReducer = (history) => combineReducers({
    router: connectRouter(history),
    customers: customersReducer,
});

export default createRootReducer;