import React, { useEffect } from 'react';
import { connect, useSelector, useDispatch } from 'react-redux';
import { getCustomers } from './actions';
import CustomerList from '../../components/CustomerList';

import './customers.css';

function Customers() {
    const customers = useSelector(state => state.customers.items);
    const err = useSelector(state => state.customers.error);
    const loading = useSelector(state => state.customers.loading);
    const dispatch = useDispatch();
    
    useEffect(() => {
        dispatch(getCustomers());
    }, []);
    
    let content;
    if (loading) {
        content = 
        <div className="list">
            <div className="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
        </div>;
    } else if (err) {
        content = 
        <div className="error">
            <div>Could not get customers</div>
            <div className="stack">
                {err.stack}
            </div>
        </div>;
    } else {
        content = 
        <div className="list">
            <CustomerList customers={customers} />
        </div>
    }

    return (
        <div className="customers">
            <h1>Customers</h1>
            <button>Add Customers</button>
            {content}
        </div>
    );
}

export default connect()(Customers);
