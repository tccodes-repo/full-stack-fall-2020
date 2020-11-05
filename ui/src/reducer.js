import { combineReducers } from 'redux';
import customersReducer from './containers/Customers/reducer';

const createRootReducer = () => combineReducers({
    customers: customersReducer,
});

export default createRootReducer;