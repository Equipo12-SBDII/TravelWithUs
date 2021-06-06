export class Paquete {
  codigo: number;
  precio: string;
  descripcion: string;
  duracion: string;
  excursion: any;
  constructor(codigo: number, precio: string, descripcion: string, duracion: string, excursion: any) {
    this.codigo = codigo;
    this.precio = precio;
    this.descripcion = descripcion;
    this.duracion = duracion;
    this.excursion = excursion;
  }
}
