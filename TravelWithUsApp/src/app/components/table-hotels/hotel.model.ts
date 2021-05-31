
export class Hotel {
  hotelID: number;
  nombre: string;
  descripcion: string;
  direccion: string;
  categoria: number;
  ofertas: any[];
  excursiones: any[];
  constructor(id: number, nombre: string, descripcion: string, direccion: string, categoria: number, ofertas: any[], excursiones: any[]) {
    this.hotelID = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
    this.direccion = direccion;
    this.categoria = categoria;
    this.ofertas = ofertas;
    this.excursiones = excursiones;
  }
}
