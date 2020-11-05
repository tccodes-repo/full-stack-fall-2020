import { applyMiddleware, compose, createStore } from 'redux';
import { routerMiddleware } from 'connected-react-router';
import thunkMiddleware from 'redux-thunk';
import createRootReducer from './reducer';
import { createBrowserHistory } from 'history';

export const history = createBrowserHistory();

export default function configureStore(preloadState){
    const middlewares = [thunkMiddleware, routerMiddleware(history)];
    const middlewareEnhancer = applyMiddleware(...middlewares);
       
    var composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

    const store = createStore(
        createRootReducer(history), 
        preloadState, 
        composeEnhancers(middlewareEnhancer));

    return store;
}
