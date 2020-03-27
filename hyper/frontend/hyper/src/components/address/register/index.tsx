import React from "react";

import ItemForm from "../../shared/ItemForm";
import { Address } from "../../../store/sagas/person/types";
import PersonEnum from "../../wizard/types";

interface OwnProps {
  address: Address;
  handleInputChange: (e: React.FormEvent<EventTarget>) => void;
  setForm: (e: PersonEnum) => void;
  handleSave: () => void;
}

const Register = ({
  address,
  handleInputChange,
  setForm,
  handleSave
}: OwnProps) => {
  const { street, number, city, state } = address;

  return (
    <div className="form">
      <div className="header">Endereço</div>
      <div className="content">
        <ItemForm
          label="Rua"
          name="street"
          value={street}
          onChange={handleInputChange}
        />
        <ItemForm
          label="Numero"
          name="number"
          value={number}
          onChange={handleInputChange}
        />
        <ItemForm
          label="Cidade"
          name="city"
          value={city}
          onChange={handleInputChange}
        />
        <ItemForm
          label="Estado"
          name="state"
          value={state}
          onChange={handleInputChange}
        />
      </div>
      <div className="footer">
        <button onClick={handleSave}>Salvar</button>
        <button onClick={() => setForm(PersonEnum.REGISTER)}>Voltar</button>
      </div>
    </div>
  );
};

export default Register;
