import React, { useState } from 'react';

export default function CustomerForm({ onSubmit, onCancel }) {

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit({ firstName, lastName, email });
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>First Name</label>
                    <input type="text" defaultValue={firstName} onChange={e => setFirstName(e.target.value)} />
                </div>
                <div>
                    <label>Last Name</label>
                    <input type="text" defaultValue={lastName} onChange={e => setLastName(e.target.value)} />
                </div>
                <div>
                    <label>Email</label>
                    <input type="email" defaultValue={email} onChange={e => setEmail(e.target.value)} />
                </div>
                <input type="submit" value="Submit" />
                <button onClick={() => onCancel()}>Cancel</button>
            </form>
        </div>
    );
}