import { action } from "typesafe-actions";
import { PersonTypes, Person } from "./types";

export const loadRequest = () => action(PersonTypes.LOAD_REQUEST);
export const loadFailure = (data: Person[]) => action(PersonTypes.LOAD_FAILURE);
export const loadSuccess = () => action(PersonTypes.LOAD_SUCCESS);
