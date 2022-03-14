import { createContext } from "react";
import type { ILibro, ILibroState, Queries } from "../interfaces";

type LibroContextProps = {
  tareaState: ILibroState;
  changeQuery: (query: Queries) => void;
  changeValue: (value: string) => void;
  changeLibro: (libro: ILibro) => void;
  changeQueryChange: (queryChange: Queries) => void;
};

export const LibroContext = createContext<LibroContextProps>(
  {} as LibroContextProps
);
