import { combineReducers } from 'redux';
import customersReducer from './containers/Customers/reducer';
import recipientReducer from './containers/Recipients/reducer';

const createRootReducer = () => combineReducers({
    customers: customersReducer,
    recipients: recipientReducer,
});

export default createRootReducer;