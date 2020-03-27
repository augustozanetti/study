import React from "react";

import { Person } from "../../../store/sagas/person/types";
import "./index.css";

interface OwnProps {
  person: Person;
  remove: (id: number) => void;
}

const List: React.SFC<OwnProps> = ({ person, remove }) => (
  <li className="person-item">
    <header>
      <div className="user-info">
        <strong>
          {person.firstName} {person.lastName}
        </strong>
      </div>
    </header>
    <p>{person.email}</p>
    <div className="footer">
      <button onClick={() => remove(person.id as number)}>Remover</button>
    </div>
  </li>
);

export default List;
