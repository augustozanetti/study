export enum PersonTypes {
  LOAD_SUCCESS = "@person/LOAD_SUCCESS",
  LOAD_FAILURE = "@person/LOAD_FAILURE",
  LOAD_REQUEST = "@person/LOAD_REQUEST"
}

export interface Address {
  street: string;
  number: string;
  city: string;
  state: string;
}

export interface Person {
  id?: number;
  firstName: string;
  lastName: string;
  email: string;
  address: Address;
}

export interface PersonState {
  readonly data: Person[];
  readonly loading: boolean;
  readonly error: boolean;
}
