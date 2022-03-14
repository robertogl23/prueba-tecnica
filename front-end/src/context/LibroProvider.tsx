import { ReactNode, useReducer } from "react";
import { ILibro, ILibroState, Queries } from "../interfaces";
import { LibroContext } from "./LibroContext";
import { LibroReducer } from "./LibroReducer";

const INITIAL_STATE: ILibroState = {
  query: Queries.GET_BY_AUTOR,
  value: "Alberto Villarreal",
  queryChange: Queries.GET_BY_AUTOR,
};

export const LibroProvider = ({
  children,
}: {
  children: ReactNode;
}) => {
  const [tareaState, dispatch] = useReducer(
    LibroReducer,
    INITIAL_STATE
  );

  const changeQuery = (query: Queries) => {
    console.log(query);
    dispatch({ type: "changeQuery", payload: query });
  };

  const changeValue = (value: string) => {
    console.log(value);
    if (value === "" || value === undefined) {
      return;
    }
    dispatch({ type: "changeValue", payload: value });
  };

  const changeLibro = (libro: ILibro) => {
    console.log(libro);
    dispatch({ type: "changeLibro", payload: libro });
  };

  const changeQueryChange = (query: Queries) => {
    console.log(query);
    dispatch({ type: "changeQueryChange", payload: query });
  };

  return (
    <LibroContext.Provider
      value={{
        tareaState,
        changeQuery,
        changeValue,
        changeLibro,
        changeQueryChange,
      }}
    >
      {children}
    </LibroContext.Provider>
  );
};
