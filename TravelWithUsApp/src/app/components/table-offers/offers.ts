export class Oferta {
  ofertaID: number;
  nombre: string;
  descripcion: string;
  precio: string;
  hotel: string;
  constructor(id: number, nombre: string, descripcion: string, precio: string, hotel: string) {
    this.ofertaID = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
    this.precio = precio;
    this.hotel = hotel
  }
}
