export interface BusinessPartner {
  id: number;
  createdAt: Date;
  cardName: string;
  avatar: string;
  address: string;
  zipCode: string;
  cardCode: string;
  marca: string;
  modelo: string;
  ano?: number;
}
