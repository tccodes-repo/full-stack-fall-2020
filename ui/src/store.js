import { applyMiddleware, compose, createStore } from 'redux';
import thunkMiddleware from 'redux-thunk';
import createRootReducer from './reducer';

export default function configureStore(preloadState){      
    var composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

    var store = createStore(
        createRootReducer(), 
        preloadState, 
        composeEnhancers(
            applyMiddleware(thunkMiddleware)));

   return store;
}
