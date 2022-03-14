import { useContext } from "react";
import { LibroContext } from "../context/LibroContext";

export const useGetQuery = () => {
  const {
    tareaState,
    changeQuery,
    changeValue,
    changeLibro,
    changeQueryChange,
  } = useContext(LibroContext);

  return {
    query: tareaState.query,
    queryChange: tareaState.queryChange,
    value: tareaState.value,
    valueDate: tareaState.valueDate,
    libro: tareaState.libro,
    change: changeQuery,
    changeValue,
    changeLibro,
    changeQueryChange,
  };
};
