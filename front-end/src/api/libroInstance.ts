import axios from "axios";
import { ILibro } from "../interfaces";

export const libroInstance = axios.create({
  baseURL: "http://localhost/prueba/api/libros",
  timeout: 1000,
  headers: { "Content-Type": "application/json" }
});

export const fetcher = (url: string = "") =>
  libroInstance.get<ILibro[]>(url).then((res) => res.data);
