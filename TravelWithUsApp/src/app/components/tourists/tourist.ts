export class Turista {
  nombre: string;
  email: string;
  viajes: number;
  nacionalidad: string;
  constructor(nombre: string, email: string, viajes: number, nacionalidad: string) {
    this.nombre = nombre;
    this.email = email;
    this.viajes = viajes;
    this.nacionalidad = nacionalidad;
  }
}
