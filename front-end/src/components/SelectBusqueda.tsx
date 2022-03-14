import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select, { SelectChangeEvent } from "@mui/material/Select";
import { Queries } from "../interfaces";
import { useGetQuery } from "../hooks/useGetQuery";
import { useState } from "react";

export default function SelectBusqueda() {
  const [query, setQuery] = useState(Queries.GET_BY_AUTOR);
  const { changeQueryChange, changeValue } = useGetQuery();

  const handleChange = (event: SelectChangeEvent) => {
    const queryChange = event.target.value as Queries;
    setQuery(queryChange);
    changeQueryChange(queryChange);

  };

  return (
    <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth size="small">
        <InputLabel id="demo-simple-select-label">
          Buscar por
        </InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={query}
          label="Buscar por"
          onChange={handleChange}
          size="small"
        >
          <MenuItem value={Queries.GET_BY_AUTOR}>Autor</MenuItem>
          <MenuItem value={Queries.GET_BY_TITLE}>
            Titulo
          </MenuItem>
          <MenuItem value={Queries.GET_BY_EDITORIAL}>
            Editorial
          </MenuItem>
          <MenuItem value={Queries.GET_BY_DATE}>
            Fecha Publicacion
          </MenuItem>
          <MenuItem value={Queries.GET_BY_AUTOR_DATE}>
            Autor y Fecha Publicacion
          </MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
}
