import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { LibroProvider } from "./context/LibroProvider";

ReactDOM.render(
  <React.StrictMode>
    <LibroProvider>
      <App />
    </LibroProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
