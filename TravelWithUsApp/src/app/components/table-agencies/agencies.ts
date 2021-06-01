export class Agencia {
  nombre: string;
  ganancia: number;
  cantidadReservas: number;
  constructor(id: number, nombre: string, ganancia: number, cantidadReservas: number) {
    this.nombre = nombre;
    this.ganancia = ganancia;
    this.cantidadReservas = cantidadReservas;
  }
}
