export class Turista {
  turistaID: number;
  nombre: string;
  descripcion: string;
  nacionalidad: string;
  constructor(id: number, nombre: string, descripcion: string, nacionalidad: string) {
    this.turistaID = id;
    this.nombre = nombre;
    this.descripcion = descripcion;
    this.nacionalidad = nacionalidad;
  }
}
