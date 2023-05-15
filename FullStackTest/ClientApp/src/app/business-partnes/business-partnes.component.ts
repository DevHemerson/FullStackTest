import { Component, OnInit } from '@angular/core';
import { BusinessPartner } from '../business-partner.interface';
import { BusinessPartnerService } from '../_data-service/business-partnes';

@Component({
  selector: 'app-business-partner',
  templateUrl: './business-partner.component.html',
  styleUrls: ['./business-partner.component.css']
})
export class BusinessPartnerComponent implements OnInit {
  businessPartners: BusinessPartner[];

  constructor(private businessPartnerService: BusinessPartnerService) { }

  ngOnInit() {
    this.getBusinessPartners();
  }

  getBusinessPartners(): void {
    this.businessPartnerService.getAllBusinessPartners()
      .subscribe(businessPartners => this.businessPartners = businessPartners);
  }
}
