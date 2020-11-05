import React, { useEffect } from 'react';
import { connect, useSelector, useDispatch } from 'react-redux';

import CustomerList from '../../components/CustomerList';
import CustomerForm from '../../components/CustomerForm';
import Loading from '../../components/Loading';

import './customers.css';

import { 
    getCustomers, 
    showAddCustomer, 
    hideAddCustomer,
    addCustomer
} from './actions';

function Customers() {
    const customers = useSelector(state => state.customers.items);
    const err = useSelector(state => state.customers.error);
    const viewState = useSelector(state => state.customers.viewState);
    const dispatch = useDispatch();
    
    useEffect(() => {
        dispatch(getCustomers());
    }, []);
    
    let content;
    switch(viewState) {
        case 'showAdd':
            content = <CustomerForm onSubmit={(customer) => dispatch(addCustomer(customer))} onCancel={() => dispatch(hideAddCustomer())} />;
            break;
        case 'error':
            content =  
                <div className="error">
                    <div>Could not get customers</div>
                    <div className="stack">
                        {err.stack}
                    </div>
                </div>;
            break;
        case 'loading':
            content = <Loading>Loading Customers</Loading>
            break;
        case 'adding':
            content = <Loading>Adding Customer</Loading>
            break;
        default:
            content = <CustomerList customers={customers} />;
            break;
    }

    return (
        <div className="customers">
            <h1>Customers</h1>
            <button onClick={() => dispatch(showAddCustomer())}>Add Customer</button>
            {content}
        </div>
    );
}

export default connect()(Customers);
