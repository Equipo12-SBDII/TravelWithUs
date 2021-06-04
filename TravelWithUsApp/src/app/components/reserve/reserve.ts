export class Agencia {
  agenciaId: number;
  agenciaNombre: string;
  constructor(id: number, nombre: string) {
    this.agenciaId = id;
    this.agenciaNombre = nombre;
  }
}

export class Oferta {
  ofertaId: number;
  hotelId: number;
  ofertaDescripcion: string;
  ofertaPrecio: number;
  constructor(oId: number, hId: number, descripcion: string, precio: number) {
    this.hotelId = hId;
    this.ofertaDescripcion = descripcion;
    this.ofertaId = oId;
    this.ofertaPrecio = precio;
  }
}

export class Turista {
  turistaId: number;
  turistaNombre: string;
  constructor(id: number, nombre: string) {
    this.turistaId = id;
    this.turistaNombre = nombre;
  }
}

export class Reserve {
  agenciaList: Agencia[];
  ofertaList: Oferta[];
  turistaList: Turista[];
  constructor(agencias: Agencia[], ofertas: Oferta[], turistas: Turista[]) {
    this.agenciaList = agencias;
    this.ofertaList = ofertas;
    this.turistaList = turistas;
  }
}
