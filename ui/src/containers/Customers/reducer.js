import { 
    GET_CUSTOMERS_STARTED, 
    GET_CUSTOMERS_ERROR, 
    GET_CUSTOMERS_SUCCESS, 
    SHOW_ADD_CUSTOMER, 
    HIDE_ADD_CUSTOMER, 
    ADD_CUSTOMER_STARTED,
    ADD_CUSTOMER_ERROR,
    ADD_CUSTOMER_SUCCESS} 
from './constants';

const initialState = {
    items: [],
    viewState: 'list',
};

export default function customersReducer(state = initialState, action) {
    switch(action.type) {
        case GET_CUSTOMERS_STARTED:
            return {
                ...state,
                viewState: 'loading'
            }
        case GET_CUSTOMERS_SUCCESS:
            return {
                ...state,
                items: action.payload,
                viewState: 'list'
            };
        case GET_CUSTOMERS_ERROR:
            return {
                ...state,
                error: action.payload,
                viewState: 'error'
            };
        case SHOW_ADD_CUSTOMER:
            return {
                ...state,
                viewState: 'showAdd'
            }
        case HIDE_ADD_CUSTOMER:
            return {
                ...state,
                viewState: 'list'
            }
        case ADD_CUSTOMER_STARTED:
            return {
                ...state,
                viewState: 'adding'
            }
        case ADD_CUSTOMER_ERROR:
            return {
                ...state,
                viewState: 'error'
            }
        case ADD_CUSTOMER_SUCCESS:
            return {
                ...state,
                viewState: 'list'
            }
        default:
            return state;
    }
}