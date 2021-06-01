export class Paquete {
  codigo: number;
  precio: string;
  descripcion: string;
  duracion: string;
  constructor(codigo: number, precio: string, descripcion: string, duracion: string) {
    this.codigo = codigo;
    this.precio = precio;
    this.descripcion = descripcion;
    this.duracion = duracion;
  }
}

export class PaqueteMedia {
  paquetes: Paquete[];
  count: number;
  constructor(paquetes: Paquete[], count: number) {
    this.paquetes = paquetes;
    this.count = count;
  }
}
