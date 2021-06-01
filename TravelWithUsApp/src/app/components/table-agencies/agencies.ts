export class Agencia {
  agenciaID: number;
  nombre: string;
  descripcion: string;
  direccion: string;
  email: string;
  fax: string;
  constructor(id: number, nombre: string, descripcion: string, direccion: string, email: string, fax: string) {
    this.agenciaID = id;
    this.nombre= nombre;
    this.descripcion = descripcion;
    this.direccion = direccion;
    this.email = email;
    this.fax = fax;
  }
}
