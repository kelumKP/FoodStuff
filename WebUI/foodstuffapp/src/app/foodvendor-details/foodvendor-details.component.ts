import { Component, OnInit } from '@angular/core';
import { FoodvendorDetailService } from '../shared/foodvendor-detail.service';
import { FoodvendorDetail } from '../shared/foodvendor-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-foodvendor-details',
  templateUrl: './foodvendor-details.component.html',
  styleUrls: ['./foodvendor-details.component.scss']
})
export class FoodvendorDetailsComponent implements OnInit{
    constructor(public service: FoodvendorDetailService, private toastr:ToastrService){

    }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:FoodvendorDetail){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to remove this record?'))
    this.service.removeFoodVendorDetail(id)
    .subscribe({
      next: res => {
        this.service.list = res as FoodvendorDetail[]
        this.toastr.error('Deleted Successfully', 'Food Vendor Register')
      },
      error: err => { console.log(err)}
    })
  }
}
