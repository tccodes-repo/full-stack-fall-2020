import { SHOW_ADD_CUSTOMER } from '../Customers/constants';
import {
    SHOW_ADD_RECIPIENT,
    ADD_RECIPIENT_STARTED,
    ADD_RECIPIENT_SUCCESS,
    ADD_RECIPIENT_ERROR
} from './constants';

export function showRecipientForm() {
    return {
        type: SHOW_ADD_RECIPIENT
    }
}

export function addRecipient({ name, email, customerId }) {
    return (dispatch) => {
        dispatch(addRecipientStarted());
        // do the work

        setTimeout(function() {
            dispatch(addRecipientSuccessfull())
        }, 2000)
    }
}

export function addRecipientStarted() {
    return {
        type: ADD_RECIPIENT_STARTED
    }
}

export function addRecipientSuccessfull() {
    return {
        type: ADD_RECIPIENT_SUCCESS,
    }
}

export function addRecipientError(e) {
    return {
        type: ADD_RECIPIENT_ERROR
    }
}