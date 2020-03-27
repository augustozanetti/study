import React, { useEffect, useState } from "react";

import PersonItem from "./Item";
import { Person } from "../../../store/sagas/person/types";
import "./index.css";
import api from "../../../utils/api";
import useFetch from "../../../utils/hooks/useFetch";

const List: React.SFC = () => {
  const { data: responseData, error, isLoading: loading } = useFetch<Person>(
    "person"
  );
  const [personList, setPersonList] = useState<Person[]>([]);
  const [isLoading, setIsLoading] = useState(loading);

  useEffect(() => {
    setPersonList(responseData);
  }, [responseData]);

  useEffect(() => {
    setIsLoading(loading);
  }, [loading]);

  const removeItem = async (id: number) => {
    setIsLoading(true);
    const { status } = await api.delete(`person/${id}`);

    setIsLoading(false);
    if (status === 200) {
      const list = personList.filter(item => item.id !== id);

      setPersonList(list);
      return;
    }

    alert("Erro ao removver");
  };

  if (error) {
    return <h1>error</h1>;
  }

  if (isLoading) {
    return <h1>loading...</h1>;
  }
  return (
    <ul>
      {personList.map(person => (
        <PersonItem key={person.id} person={person} remove={removeItem} />
      ))}
    </ul>
  );
};

export default List;
