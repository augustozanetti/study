import { Reducer } from "redux";
import { PersonState, PersonTypes } from "./types";

const INITIAL_STATE: PersonState = {
  data: [],
  error: false,
  loading: false
};

const reducer: Reducer<PersonState> = (
  state = INITIAL_STATE,
  action
): PersonState => {
  switch (action.type) {
    case PersonTypes.LOAD_REQUEST:
      return {
        ...state,
        loading: true
      };
    case PersonTypes.LOAD_SUCCESS:
      return {
        ...state,
        loading: false,
        error: false,
        data: action.payload.data
      };
    case PersonTypes.LOAD_FAILURE:
      return {
        ...state,
        loading: false,
        error: true,
        data: []
      };
    default:
      return { ...state };
  }
};

export default reducer;
