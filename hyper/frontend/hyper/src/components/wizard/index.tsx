import React, { useState } from "react";

import Register from "../person/register/index";
import PersonEnum from "./types";
import { Person } from "../../store/sagas/person/types";
import Address from "../address/register/index";
import api from "../../utils/api";

const Wizard: React.SFC = () => {
  const [state, setState] = useState<Person>({
    firstName: "",
    lastName: "",
    email: "",
    address: {
      street: "",
      number: "",
      city: "",
      state: ""
    }
  });
  const [form, setForm] = useState<PersonEnum>(PersonEnum.REGISTER);

  const handleInputChange = (e: React.FormEvent<EventTarget>) => {
    const { name, value } = e.target as HTMLInputElement;

    if (name === "firstName" || name === "lastName" || name === "email") {
      setState({ ...state, [name]: value });
    } else {
      setState({
        ...state,
        address: {
          ...state.address,
          [name]: value
        }
      });
    }
  };

  const handleSave = async () => {
    const data = await api.post("person", state);

    if (data.status === 200) {
      window.location.pathname = "/";
    }
  };

  switch (form) {
    case PersonEnum.REGISTER:
      return (
        <Register
          firstName={state.firstName}
          lastName={state.lastName}
          email={state.email}
          handleInputChange={handleInputChange}
          setForm={setForm}
        />
      );
    case PersonEnum.ADDRESS:
      return (
        <Address
          address={state.address}
          handleInputChange={handleInputChange}
          setForm={setForm}
          handleSave={handleSave}
        />
      );
    default:
      return null;
  }
};

export default Wizard;
