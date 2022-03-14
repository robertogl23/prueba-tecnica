import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { Alert, Box, TextField } from "@mui/material";
import { useForm } from "react-hook-form";
import { ILibro } from "../interfaces";
import { libroInstance } from "../api/libroInstance";
export default function AlertDialog() {
  const [open, setOpen] = React.useState(false);
  const [error, setError] = React.useState(false);
  const [message, setMessage] = React.useState("");
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<ILibro>();

  const onSubmit = (data: ILibro) => {
    console.log(data);
    const libro = {
      Autor: data.autor,
      TituloLibro: data.tituloLibro,
      FechaPublicacion: data.fechaPublicacion,
      Editorial: data.editorial,
    };
    libroInstance
      .post("/create-libro", libro)
      .then((res) => {
        console.log(res);
        setOpen(false);
      })
      .catch((err) => {
        console.log(err);
        setMessage('Error al crear el libro');
        setError(true);
      });
  };
  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button variant="outlined" onClick={handleClickOpen}>
        Nuevo Libro
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <form onSubmit={handleSubmit(onSubmit)}>
          <DialogTitle id="alert-dialog-title">
            {"Formulario para crear nuevo libro"}
          </DialogTitle>
          <DialogContent>
            <Box marginTop={1}>
              <TextField
                {...register("autor", {
                  required: true,
                  maxLength: 100,
                })}
                error={
                  errors?.autor?.type === "required" ||
                  errors?.autor?.type === "maxLength"
                }
                size="small"
                fullWidth
                id="outlined-basic"
                label="Autor"
                variant="outlined"
                helperText={
                  errors?.autor?.type === "required"
                    ? "Campo requerido"
                    : errors?.autor?.type === "maxLength"
                    ? "Maximo 100 caracteres"
                    : ""
                }
              />
            </Box>
            <Box marginTop={2}>
              <TextField
                {...register("tituloLibro", {
                  required: true,
                  maxLength: 100,
                })}
                error={
                  errors?.tituloLibro?.type === "required" ||
                  errors?.tituloLibro?.type === "maxLength"
                }
                size="small"
                fullWidth
                id="outlined-basic"
                label="Tituulo"
                variant="outlined"
                helperText={
                  errors?.tituloLibro?.type === "required"
                    ? "Campo requerido"
                    : errors?.tituloLibro?.type === "maxLength"
                    ? "Maximo 100 caracteres"
                    : ""
                }
              />
            </Box>
            <Box marginTop={2}>
              <TextField
                {...register("fechaPublicacion", {
                  required: true,
                  maxLength: 100,
                  pattern: /^\d{4}-\d{2}-\d{2}$/,
                })}
                error={
                  errors?.fechaPublicacion?.type ===
                    "required" ||
                  errors?.fechaPublicacion?.type ===
                    "maxLength" ||
                  errors?.fechaPublicacion?.type === "pattern"
                }
                size="small"
                fullWidth
                id="outlined-basic"
                label="Fecha Publicacion"
                variant="outlined"
                type={"date"}
                defaultValue={new Date().toISOString().substr(0, 10)}
                helperText={
                  errors?.fechaPublicacion?.type === "required"
                    ? "Campo requerido"
                    : errors?.fechaPublicacion?.type ===
                      "maxLength"
                    ? "Maximo 100 caracteres"
                    : errors?.fechaPublicacion?.type ===
                      "pattern"
                    ? "Formato de fecha invalido"
                    : ""
                }
              />
            </Box>
            <Box marginTop={2}>
              <TextField
                {...register("editorial", {
                  required: true,
                  maxLength: 100,
                })}
                error={
                  errors?.editorial?.type === "required" ||
                  errors?.editorial?.type === "maxLength"
                }
                size="small"
                fullWidth
                id="outlined-basic"
                label="Editorial"
                variant="outlined"
                helperText={
                  errors?.editorial?.type === "required"
                    ? "Campo requerido"
                    : errors?.editorial?.type === "maxLength"
                    ? "Maximo 100 caracteres"
                    : ""
                }
              />
            </Box>
            {error && (
              <Box marginTop={2}>
                <Alert severity="error">{message}</Alert>
              </Box>
            )}
          </DialogContent>
          <DialogActions>
            <Button variant="outlined" onClick={handleClose}>
              Cancelar
            </Button>
            <Button variant="contained" autoFocus type="submit">
              Crear libro
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </div>
  );
}
