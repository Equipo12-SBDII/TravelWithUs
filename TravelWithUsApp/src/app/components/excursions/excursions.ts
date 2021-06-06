export class Excursion {
  lugarSalida: string;
  lugarLlegada: string;
  fechaSalida: Date;
  fechaLlegada: Date;
  precio: number;
  constructor(lugarSalida: string, fechaSalida: Date, lugarLlegada: string, fechaLlegada: Date, precio: number) {
    this.lugarSalida = lugarSalida;
    this.fechaSalida = fechaSalida;
    this.lugarLlegada = lugarLlegada;
    this.fechaLlegada = fechaLlegada;
    this.precio = precio;
  }
}
