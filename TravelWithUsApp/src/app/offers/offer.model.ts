export class Offer {
  public OfferID: number;
  public HotelID: number;
  public Precio: number;
  public Descripcion: string;

  constructor(offerID: number, hotelID: number, precio: number, descripcion: string) {
    this.OfferID = offerID;
    this.HotelID = hotelID;
    this.Precio = precio;
    this.Descripcion = descripcion;
  }
}
