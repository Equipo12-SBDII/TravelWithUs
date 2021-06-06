export class Agencia {
  agenciaID: number;
  nombre: string;
  constructor(id: number, nombre: string) {
    this.agenciaID = id;
    this.nombre = nombre;
  }
}

export class Oferta {
  ofertaID: number;
  hotelID: number;
  hotelNombre: string;
  descripcion: string;
  price: number;
  constructor(oId: number, hId: number, hNombre: string, descripcion: string, precio: number) {
    this.hotelID = hId;
    this.descripcion = descripcion;
    this.ofertaID = oId;
    this.price = precio;
    this.hotelNombre = hNombre;
  }
}

export class Turista {
  turistaID: number;
  nombre: string;
  constructor(id: number, nombre: string) {
    this.turistaID = id;
    this.nombre = nombre;
  }
}

export class Reserve {
  agencias: Agencia[];
  ofertas: Oferta[];
  turistas: Turista[];
  constructor(agencias: Agencia[], ofertas: Oferta[], turistas: Turista[]) {
    this.agencias = agencias;
    this.ofertas = ofertas;
    this.turistas = turistas;
  }
}

export class Reservaind {
  agenciaID: number;
  turistaID: number;
  hotelID: number;
  ofertaID: number;
  acompanantes: number;
  aerolinea: string;
  precio: number;
  llegada: Date;
  salida: Date;
  constructor(agenciaID: number, turistaID: number, hotelID: number, ofertaID: number, acompanantes: number
    , aerolinea: string, precio: number, llegada: Date, salida: Date) {
    this.agenciaID = agenciaID;
    this.turistaID = turistaID;
    this.hotelID = hotelID;
    this.ofertaID = ofertaID;
    this.acompanantes = acompanantes;
    this.aerolinea = aerolinea;
    this.precio = precio;
    this.llegada = llegada;
    this.salida = salida;
  }
}
