import type { ILibroState, QueryAction } from "../interfaces";

export const LibroReducer = (
  state: ILibroState,
  action: QueryAction
): ILibroState => {
  switch (action.type) {
    case "changeQuery":
      return {
        ...state,
        query: action.payload,
      };
    case "changeValue":
      return {
        ...state,
        value: action.payload,
      };
    case "changeLibro":
      return {
        ...state,
        libro: action.payload,
      };
    case "changeQueryChange":
      return {
        ...state,
        queryChange: action.payload,
      };
    default:
      return state;
  }
};
