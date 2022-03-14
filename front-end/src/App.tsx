import {
  Typography,
  Container,
  Box,
  Paper,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from "@mui/material";
import AlertDialog from "./components/Dialog";
import BasicList from "./components/GridData";
import { useGetQuery } from "./hooks/useGetQuery";

function App() {
  const { libro } = useGetQuery();

  return (
    <Container maxWidth="lg" sx={{ marginTop: 4 }}>
      <Typography variant="h3" component="h2">
        App - Libros
      </Typography>

      <Box sx={{ marginTop: 4 }}>
        <AlertDialog />
      </Box>

      <Box sx={{ marginTop: 4, display: "flex", gap: 2 }}>
        <Box width={"45%"}>
          <Paper elevation={3}>
            <BasicList />
          </Paper>
        </Box>
        <Box width={"65%"}>
          <Paper elevation={3}>
            {libro != undefined ? (
              <Box>
                <TableContainer component={Paper}>
                  <Table
                    aria-label="simple table"
                  >
                    <TableHead>
                      <TableRow>
                        <TableCell>Autor</TableCell>
                        <TableCell align="right">
                          Titulo
                        </TableCell>
                        <TableCell align="right">
                          Fecha Publicacion
                        </TableCell>
                        <TableCell align="right">
                          Editorial
                        </TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      <TableRow
                        sx={{
                          "&:last-child td, &:last-child th": {
                            border: 0,
                          },
                        }}
                      >
                        <TableCell component="th" scope="row">
                          {libro.autor}
                        </TableCell>
                        <TableCell align="right">
                          {libro.tituloLibro}
                        </TableCell>
                        <TableCell align="right">
                          {libro.fechaPublicacion}
                        </TableCell>
                        <TableCell align="right">
                          {libro.editorial}
                        </TableCell>
                      </TableRow>
                    </TableBody>
                  </Table>
                </TableContainer>
              </Box>
            ) : (
              <Box padding={2}>
                <Typography variant="h5" component="h2">
                  No hay libro seleccionado
                </Typography>
              </Box>
            )}
          </Paper>
        </Box>
      </Box>
    </Container>
  );
}

export default App;
