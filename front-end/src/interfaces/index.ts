export interface ILibro {
  autor: string;
  tituloLibro: string;
  fechaPublicacion: Date;
  editorial: string;
}

export interface ILibroState {
  query: Queries;
  queryChange: Queries;
  value: string;
  valueDate?: string;
  libro?: ILibro;
}

export enum Queries {
  GET_BY_AUTOR = "/get-by-autor/?autor=",
  GET_BY_TITLE = "/get-by-title/?titulo=",
  GET_BY_EDITORIAL = "/get-by-editorial/?editorial=",
  GET_BY_AUTOR_DATE = "/get-by-autor-and-publication-date",
  GET_BY_DATE = "/get-by-publication-date/?fecha=",
}

export type QueryAction =
  | {
      type: "changeQuery";
      payload: Queries;
    }
  | {
      type: "changeValue";
      payload: string;
    }
  | {
      type: "changeValueDate";
      payload: string;
    }
  | {
      type: "changeLibro";
      payload: ILibro;
    }
  | {
      type: "changeQueryChange";
      payload: Queries;
    };
