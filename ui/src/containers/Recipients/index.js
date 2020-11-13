import React, { useState } from 'react';
import { connect, useDispatch, useSelector } from 'react-redux';
import Loading from '../../components/Loading';

import { showRecipientForm, addRecipient } from './actions';

function Recipients() {
    const dispatch = useDispatch();
    const showForm = useSelector(state => state.recipients.showForm);
    const isAdding = useSelector(state => state.recipients.isAdding);

    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [customerId, setCustomerId] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
        dispatch(addRecipient({
            name,
            email,
            customerId
        }));
    }

    if(isAdding) {
        return <Loading />;
    }

    return (
        <div>
            <h1>Recipients</h1>
            <button onClick={() => dispatch(showRecipientForm())}>Add Recipient</button>

            {(showForm) ? 
            <div>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>Name</label>
                        <input type="text" onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div>
                        <label>Email</label>
                        <input type="text" onChange={(e) => setEmail(e.target.value)} />
                    </div>
                    <div>
                        <label>Customer Id</label>
                        <input type="text" onChange={(e) => setCustomerId(e.target.value)} />
                    </div>
                    <input type="submit" />
                </form>
            </div> :
            <div>List of Recipients</div>}

        </div>
    );
}

export default connect()(Recipients);
