export class Oferta {
  ofertaID: number;
  nombre: string;
  descripcion: string;
  precio: number;
  hotel: string;
  constructor(id: number, nombre: string, descripcion: string, precio: number, hotel: string) {
    this.ofertaID = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
    this.precio = precio;
    this.hotel = hotel
  }
}
