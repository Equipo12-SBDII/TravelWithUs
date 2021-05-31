export class Paquete {
  paqueteID: number;
  precio: string;
  descripcion: string;
  duracion: string;
  constructor(id: number, precio: string, descripcion: string, duracion: string) {
    this.paqueteID = id;
    this.precio= precio;
    this.descripcion = descripcion;
    this.duracion = duracion;
  }
}
