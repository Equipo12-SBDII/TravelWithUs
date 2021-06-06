import { ɵangular_material_src_material_datepicker_datepicker_c } from "@angular/material/datepicker";

export class Reserva {
  agencia: string;
  turista: string;
  ofertaDescripcion: string;
  precio: number;
  hotel: string;
  aereolinea: string;
  acompananates: number;
  entrada: Date;
  salida: Date;
  constructor(agencia: string, turista: string, ofertaDescripcion: string, precio: number, hotel: string, aereolinea: string
    , acompananates: number, entrada: Date, salida: Date) {
    this.agencia = agencia;
    this.turista = turista;
    this.ofertaDescripcion = ofertaDescripcion;
    this.precio = precio;
    this.hotel = hotel;
    this.aereolinea = aereolinea;
    this.acompananates = acompananates;
    this.entrada = entrada;
    this.salida = salida;
  }
}
