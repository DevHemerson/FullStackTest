import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusinessPartner } from '../business-partner.interface';

@Injectable({
  providedIn: 'root'
})
export class BusinessPartnerService {
  private apiUrl = 'https://637283b2348e947299f77e08.mockapi.io/b1s/v2/BusinessPartners';

  constructor(private http: HttpClient) { }

  getAllBusinessPartners(): Observable<BusinessPartner[]> {
    return this.http.get<BusinessPartner[]>(`${this.apiUrl}/business-partners`);
  }

  getBusinessPartner(cardCode: string): Observable<BusinessPartner> {
    return this.http.get<BusinessPartner>(`${this.apiUrl}/business-partners/${cardCode}`);
  }

  createBusinessPartner(businessPartner: BusinessPartner): Observable<BusinessPartner> {
    return this.http.post<BusinessPartner>(`${this.apiUrl}/business-partners`, businessPartner);
  }

  updateBusinessPartner(cardCode: string, businessPartner: BusinessPartner): Observable<any> {
    return this.http.put(`${this.apiUrl}/business-partners/${cardCode}`, businessPartner);
  }

  deleteBusinessPartner(cardCode: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/business-partners/${cardCode}`);
  }
}
