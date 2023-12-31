import { Component } from '@angular/core';
import { FoodvendorDetailService } from 'src/app/shared/foodvendor-detail.service';
import { NgForm } from "@angular/forms";
import { FoodvendorDetail } from 'src/app/shared/foodvendor-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-foodvendor-detail-form',
  templateUrl: './foodvendor-detail-form.component.html',
  styleUrls: ['./foodvendor-detail-form.component.scss']
})
export class FoodvendorDetailFormComponent {
  constructor(public service: FoodvendorDetailService, private toastr:ToastrService){
  }

  onSubmit(form: NgForm){
    this.service.formSubmitted = true
    if(form.valid)
    {
      if (this.service.formData.id == 0) {
        this.insertRecord(form)
      } else {
        this.updateRecord(form)
      }
    }
  }

  insertRecord(form: NgForm)
  {
    this.service.postFoodVendorDetail()
    .subscribe({
      next: res => {
        this.service.list = res as FoodvendorDetail[]
        this.service.resetForm(form)
        this.toastr.success('Inserted Successfully', 'Food Vendor Register')
      },
      error: err => { console.log(err)}
    })
  }
  updateRecord(form: NgForm){
    this.service.putFoodVendorDetail()
    .subscribe({
      next: res => {
        this.service.list = res as FoodvendorDetail[]
        this.service.resetForm(form)
        this.toastr.info('Updated Successfully', 'Food Vendor Register')
      },
      error: err => { console.log(err)}
    })
  }
}
