import { Component, OnInit } from '@angular/core';
import { FoodvendorDetailService } from '../shared/foodvendor-detail.service';

@Component({
  selector: 'app-foodvendor-details',
  templateUrl: './foodvendor-details.component.html',
  styleUrls: ['./foodvendor-details.component.scss']
})
export class FoodvendorDetailsComponent implements OnInit{
    constructor(public service: FoodvendorDetailService){

    }
  ngOnInit(): void {
    this.service.refreshList();
  }
}
