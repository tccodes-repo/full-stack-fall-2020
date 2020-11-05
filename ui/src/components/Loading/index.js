import React, { Children } from 'react';
import './loading.css';

export default function Loading({ children }) {
    return (
        <div className="loading">
            <div className="text">{children}</div>
            <div className="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
        </div>
    );
}