export class Paquete {
  codigo: number;
  precio: string;
  descripcion: string;
  duracion: string;
  constructor(codigo: number, precio: string, descripcion: string, duracion: string) {
    this.codigo = codigo;
    this.precio = precio;
    this.descripcion = descripcion;
    this.duracion = duracion;
  }
}


