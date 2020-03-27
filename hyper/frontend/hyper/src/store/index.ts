import { createStore, Store } from 'redux';
import { PersonState } from './sagas/person/types'
import rootReducer from './sagas/rootReducer';

export interface ApplicationState {
    persons: PersonState,
}

const store: Store<ApplicationState> = createStore(rootReducer);

export default store;
