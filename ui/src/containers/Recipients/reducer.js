import { SHOW_ADD_CUSTOMER } from '../Customers/constants';
import {
    SHOW_ADD_RECIPIENT,
    ADD_RECIPIENT_STARTED,
    ADD_RECIPIENT_SUCCESS,
    ADD_RECIPIENT_ERROR
} from './constants';

const initialState = {
    showForm: false,
    isAdding: false
};

export default function RecipientReducer(state = initialState, action) {
    switch(action.type) {
        case SHOW_ADD_RECIPIENT:
            return {
                ...state,
                showForm: true
            }
        case ADD_RECIPIENT_STARTED:
            return {
                ...state,
                isAdding: true
            }
        case ADD_RECIPIENT_SUCCESS:
            return {
                ...state,
                isAdding: false,
                showForm: false
            }
    }

    return state;
}