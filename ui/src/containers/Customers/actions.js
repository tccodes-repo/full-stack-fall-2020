import { GET_CUSTOMERS_ERROR, GET_CUSTOMERS_STARTED, GET_CUSTOMERS_SUCCESS } from './constants';
import { getApiClient } from '../../api';

export function getCustomers() {
    return (dispatch) => {
        dispatch(getCustomersStarted());
        var apiClient = getApiClient();

        // Set timeout here is only used to fake a delay getting the data 
        // from the API.  I used it to show the loading indicator.
        setTimeout(function() {        
            apiClient.getCustomers()
            .then(r => dispatch(getCustomersSuccess(r)))
            .catch(err => dispatch(getCustomersError(err)));
        }, 2000);
    }
}

export function getCustomersStarted() {
    return {
        type: GET_CUSTOMERS_STARTED,
    }
}

export function getCustomersSuccess(customers) {
    return {
        type: GET_CUSTOMERS_SUCCESS,
        payload: customers
    }
}

export function getCustomersError(error) {
    return {
        type: GET_CUSTOMERS_ERROR,
        payload: error
    }
}