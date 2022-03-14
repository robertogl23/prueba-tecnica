import Box from "@mui/material/Box";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import BookIcon from "@mui/icons-material/BookRounded";
import { ILibro, Queries } from "../interfaces";
import {
  Button,
  CircularProgress,
  ListSubheader,
  TextField,
} from "@mui/material";
import useSWR from "swr";
import { fetcher } from "../api/libroInstance";
import { useGetQuery } from "../hooks/useGetQuery";
import SelectBusqueda from "./SelectBusqueda";
import { useRef, useState } from "react";

export default function BasicList() {
  const {
    query,
    value,
    changeValue,
    changeLibro,
    change,
    queryChange,
  } = useGetQuery();
  const [textValue, setTextValue] = useState(value || "");
  const [textValue2, setTextValue2] = useState(
    new Date().toISOString().substr(0, 10)
  );
  const textInput1Ref = useRef<HTMLInputElement>(null);
  const { data } = useSWR<ILibro[]>(`${query}${value}`, fetcher);
  const [selectedIndex, setSelectedIndex] = useState<number>();
  const handleListItemClick = (
    event: React.MouseEvent<HTMLDivElement, MouseEvent>,
    index: number
  ) => {
    setSelectedIndex(index);
    data != undefined && changeLibro(data[index]);
  };

  const handleClickBtn = (event: any): void => {
    change(queryChange);
    if (queryChange === Queries.GET_BY_AUTOR_DATE) {
      changeValue(`/?autor=${textValue}&fecha=${textValue2}`);
      return;
    }

    changeValue(textValue);
  };

  const handleTextChange = (event: any): void => {
    const value = event.target.value;
    setTextValue(value);
  };

  const handleTextChange2 = (event: any): void => {
    console.log(event.target.value);
    setTextValue2(event.target.value);
  };

  return (
    <Box sx={{ width: "100%", bgcolor: "background.paper" }}>
      <nav aria-label="main mailbox folders">
        <List
          sx={{ width: "100%", bgcolor: "background.paper" }}
          component="nav"
          aria-labelledby="books-list"
          subheader={
            <ListSubheader
              component="div"
              id="nested-list-subheader"
            >
              <>
                Lista libros
                <Box>
                  <TextField
                    ref={textInput1Ref}
                    id="outlined-basic"
                    defaultValue={
                      queryChange === Queries.GET_BY_DATE
                        ? textValue2
                        : textValue
                    }
                    variant="outlined"
                    fullWidth
                    size="small"
                    label={
                      queryChange === Queries.GET_BY_AUTOR
                        ? "Autor"
                        : queryChange === Queries.GET_BY_TITLE
                        ? "Titulo"
                        : queryChange ===
                          Queries.GET_BY_EDITORIAL
                        ? "Editorial"
                        : queryChange === Queries.GET_BY_DATE
                        ? "Fecha Publicacion"
                        : queryChange ===
                          Queries.GET_BY_AUTOR_DATE
                        ? "Autor"
                        : "Buscar por"
                    }
                    type={
                      queryChange === Queries.GET_BY_DATE
                        ? "date"
                        : "text"
                    }
                    onChange={handleTextChange}
                  />
                </Box>
                {queryChange === Queries.GET_BY_AUTOR_DATE && (
                  <Box sx={{ marginTop: 1 }}>
                    <TextField
                      id="outlined-basic"
                      label="Fecha Publicacion"
                      variant="outlined"
                      fullWidth
                      size="small"
                      type="date"
                      value={textValue2}
                      onChange={handleTextChange2}
                    />
                  </Box>
                )}
                <Box sx={{ marginTop: 1 }}>
                  <SelectBusqueda />
                </Box>
                <Box>
                  <Button
                    disabled={textValue.trim().length === 0}
                    size="small"
                    variant="contained"
                    onClick={handleClickBtn}
                  >
                    Buscar
                  </Button>
                </Box>
              </>
            </ListSubheader>
          }
        >
          {data?.length === 0 && (
            <ListItem
              sx={{
                display: "grid",
                placeItems: "center",
                width: "100%",
              }}
            >
              <ListItemText primary="No se encontraron resultados" />
            </ListItem>
          )}
          {!data && (
            <ListItem
              sx={{
                display: "grid",
                placeItems: "center",
                width: "100%",
              }}
            >
              <CircularProgress />
            </ListItem>
          )}
          {data?.map((libro: ILibro, i: number) => (
            <ListItem key={i} disablePadding>
              <ListItemButton
                selected={selectedIndex === i}
                onClick={(event) =>
                  handleListItemClick(event, i)
                }
              >
                <ListItemIcon>
                  <BookIcon />
                </ListItemIcon>
                <ListItemText primary={libro.tituloLibro} />
              </ListItemButton>
            </ListItem>
          ))}
        </List>
      </nav>
    </Box>
  );
}
