import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { FoodvendorDetail } from './foodvendor-detail.model';
import { NgForm } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class FoodvendorDetailService {

  url: string = environment.apiBaseUrl + '/FoodVendor'
  list:FoodvendorDetail[] = [];
  formData: FoodvendorDetail = new FoodvendorDetail()
  formSubmitted: boolean = false;
  constructor(private http:HttpClient) { }

  refreshList(){
    this.http.get(this.url).subscribe({
        next: res => {
            this.list = res as FoodvendorDetail[];
           },
          error : err => { console.log(err)}
    })
  }

  postFoodVendorDetail(){
    return this.http.post(this.url, this.formData)
  }

  resetForm(form: NgForm){
    form.form.reset()
    this.formData = new FoodvendorDetail()
    this.formSubmitted = false
  }
}
