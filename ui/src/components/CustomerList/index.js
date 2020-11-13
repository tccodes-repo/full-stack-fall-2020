import React from 'react';
import './list.css';

export default function CustomerList({ customers }) {

    if (customers == null || customers.length == 0){
        return (
            <div>No Customers</div>
        );
    }

    return (
        <table className="customer-list">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
            </thead>
            <tbody>
                {customers.map(c => 
                    <tr key={c.id}>
                        <td>{c.firstName}</td>
                        <td>{c.lastName}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
};