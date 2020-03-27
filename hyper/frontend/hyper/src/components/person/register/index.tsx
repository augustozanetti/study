import React, { useState } from "react";

import ItemForm from "../../shared/ItemForm";
import { Person } from "../../../store/sagas/person/types";
import PersonEnum from "../../wizard/types";
import "./index.css";

interface OwnProps extends Omit<Person, "address"> {
  handleInputChange: (e: React.FormEvent<EventTarget>) => void;
  setForm: (e: PersonEnum) => void;
}

const Register = ({
  firstName,
  lastName,
  email,
  handleInputChange,
  setForm
}: OwnProps) => (
  <div className="form">
    <div className="header"> Informações Pessoais </div>
    <div className="content">
      <ItemForm
        label="Primeiro Nome"
        name="firstName"
        value={firstName}
        onChange={handleInputChange}
      />
      <ItemForm
        label="Último Nome"
        name="lastName"
        value={lastName}
        onChange={handleInputChange}
      />
      <ItemForm
        label="E-mail"
        name="email"
        value={email}
        onChange={handleInputChange}
      />
    </div>

    <div className="footer">
      <button onClick={() => setForm(PersonEnum.ADDRESS)}>Próximo</button>
    </div>
  </div>
);

export default Register;
