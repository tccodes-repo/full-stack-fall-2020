import { GET_CUSTOMERS_STARTED, GET_CUSTOMERS_ERROR, GET_CUSTOMERS_SUCCESS } from './constants';

const initialState = {
    items: [],
    loading: false,
};

export default function customersReducer(state = initialState, action) {
    switch(action.type) {
        case GET_CUSTOMERS_STARTED:
            return {
                ...state,
                loading: true,
            }
        case GET_CUSTOMERS_SUCCESS:
            return {
                ...state,
                items: action.payload,
                loading: false,
            };
        case GET_CUSTOMERS_ERROR:
            return {
                ...state,
                error: action.payload,
                loading: false,
            };
        default:
            return state;
    }
}