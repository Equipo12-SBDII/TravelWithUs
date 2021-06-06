import { Component, Inject, OnInit } from '@angular/core';
import { Reserve, Turista, Agencia, Oferta, Reservaind } from './reserve';
import { FormControl, FormGroup } from "@angular/forms";
import { DOCUMENT, JsonPipe } from "@angular/common";
import { ReserveService } from './reserve.service';
import { Reserva } from '../table-reserves/reserveIndividual';

/**
 * @title Basic select with initial value and no form
 */
@Component({
  selector: 'reserve',
  templateUrl: 'reserve.component.html',
  styleUrls: ['reserve.component.scss']
})
export class ReserveComponent implements OnInit {
  reserveData: any;
  constructor(@Inject(DOCUMENT) private document: any, private service: ReserveService) {
    this.agencies = [];
    this.offers = [];
    this.tourist = [];

    // this.onGet();
    // this.onGetAgencies();
    // this.onGetOffers();
    // this.onGetTourist();
  }

  ngOnInit() {
    this.onGetAgencies();
    this.onGetOffers();
    this.onGetTourist();
    // this.onGet();
  }

  agencies: Agencia[] = [new Agencia(1, 'a')];
  offers: Oferta[] = [new Oferta(1, -1, 'dd', 'laal', 1)];
  tourist: Turista[] = [new Turista(1, 'a')];
  selectedOff: string = '';
  selectedTou: string = '';
  selectedAge: string = '';
  sO: Oferta = new Oferta(-1, -1, '', '', 1);
  sT: Turista = new Turista(-1, '');
  sA: Agencia = new Agencia(-1, '');
  reservedPrice: number = 0;
  fechas: any;
  fechaSalida: Date = new Date();
  fechaEntrada: Date = new Date();
  computedPrice: number = 0;

  aerolinea: string = '';
  numAcompa: number = 0;

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  selectAge(event: Event) {
    this.selectedAge = (event.target as HTMLSelectElement).value;
    for (let i of this.agencies) {
      if (i.nombre == this.selectedAge) {
        this.sA = i;
      }
    }
  }
  selectTou(event: Event) {
    this.selectedTou = (event.target as HTMLSelectElement).value;
    for (let i of this.tourist) {
      if (i.nombre == this.selectedTou) {
        this.sT = i;
      }
    }
  }
  selectOff(event: Event) {
    this.selectedOff = (event.target as HTMLSelectElement).value;
    this.price();
    for (let i of this.offers) {
      if (i.descripcion == this.selectedOff) {
        this.sO = i;
      }
    }
  }
  price() {
    const days = this.fechaSalida.getDay() - this.fechaEntrada.getDay();
    this.reservedPrice = this.sO.price * (this.numAcompa + 1) * days;
    // for (let off of this.offers) {
    //   if (off.descripcion == this.selectedOff) {
    //     this.reservedPrice += off.price;
    //   }
    // }

  }
  date() {
    let input = (this.range.value.start.toISOString())
    let output = (this.range.value.end.toISOString())
    let entrada = '';
    let salida = '';
    for (let i of input) {
      if (i == 'T')
        break;

      entrada += i;
    }
    for (let i of output) {
      if (i == 'T')
        break;

      salida += i;
    }
    this.fechas = [new Date(entrada), new Date(salida)];
    this.fechaEntrada = new Date(entrada);
    this.fechaSalida = new Date(salida);
    console.log(this.fechas);
  }

  reserve() {
    this.date();
    this.price();
    this.onSave();
    this.document.location.href = 'myreserves';

  }

  onGet() {
    this.service.GetData().subscribe(
      (res) => {

        console.log(res);
        this.reserveData = res;
        this.agencies = res.agencias;
        this.offers = res.ofertas;
        this.tourist = res.turistas;
        console.log(this.reserveData);
        alert(res.agencias[0].nombre);
      },
      (err) => console.log(err)
    );
  }
  onGetTourist() {
    this.service.GetTourists().subscribe(
      (res) => {
        this.tourist = res;
      },
      (err) => console.log("Error en turistas: " + err));
  }
  onGetAgencies() {
    this.service.GetAgencies().subscribe(
      (res) => {
        this.agencies = res;
        console.log(res);
      },
      (err) => console.log("Error en agencias: " + err)
    );
  }
  onGetOffers() {
    this.service.GetOffers().subscribe(
      (res) => {
        this.offers = res;
        console.log(res);
      },
      (err) => console.log("Error en ofertas: " + err)
    );
  }

  onSave() {
    const res = new Reservaind(this.sA.agenciaID, this.sT.turistaID, this.sO.hotelID, this.sO.ofertaID
      , this.numAcompa, this.aerolinea, this.reservedPrice, this.fechaEntrada, this.fechaSalida);
    // alert(new JsonPipe().transform(res));
    this.service.PostReservaIndividual(res)
      .subscribe(
        (response) => alert(new JsonPipe().transform(response)),
        (err) => alert(new JsonPipe().transform(err))
      );
  }
}

