export class Excursion {
  lugar: string;
  fechasalida: Date;
  duracion: number;
  constructor(lugar: string, fechasalida: Date, duracion: number) {
    this.lugar = lugar;
    this.fechasalida = fechasalida;
    this.duracion = duracion;
  }
}
