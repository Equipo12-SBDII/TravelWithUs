export class Excursion {
  excursionID: number;
  precio: string;
  descripcion: string;
  fechadesalida: string;
  fechadellegada: string;
  constructor(id: number, precio: string, descripcion: string, fechadesalida: string, fechadellegada: string) {
    this.excursionID = id;
    this.precio= precio;
    this.descripcion = descripcion;
    this.fechadesalida = fechadesalida;
    this.fechadellegada = fechadellegada;
  }
}
