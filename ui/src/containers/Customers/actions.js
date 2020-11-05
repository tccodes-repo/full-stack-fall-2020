import { 
    GET_CUSTOMERS_ERROR, 
    GET_CUSTOMERS_STARTED, 
    GET_CUSTOMERS_SUCCESS,
    SHOW_ADD_CUSTOMER,
    HIDE_ADD_CUSTOMER,
    ADD_CUSTOMER_STARTED,
    ADD_CUSTOMER_ERROR,
    ADD_CUSTOMER_SUCCESS,
} from './constants';
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

export function showAddCustomer() {
    return {
        type: SHOW_ADD_CUSTOMER
    }
}

export function hideAddCustomer() {
    return {
        type: HIDE_ADD_CUSTOMER
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

export function addCustomerStarted() {
    return {
        type: ADD_CUSTOMER_STARTED
    }
}

export function addCustomerError(err) {
    return {
        type: ADD_CUSTOMER_ERROR,
        payload: err
    }
}

export function addCustomerSuccess(customer) {
    return {
        type: ADD_CUSTOMER_SUCCESS,
        payload: customer
    }
}

export function addCustomer(customer) {
    return (dispatch) => {
        dispatch(addCustomerStarted());

         // Set timeout here is only used to fake a delay getting the data 
        // from the API.  I used it to show the loading indicator.
        setTimeout(function() {        
            var api = getApiClient();
            api.addCustomer({ body: customer })
                .then(r => {
                    dispatch(addCustomerSuccess(r));
                    dispatch(getCustomers());
                })
                .catch(err => addCustomerError(err));

        }, 2000);
    }   
}