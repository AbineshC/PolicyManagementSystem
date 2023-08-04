import { Component, OnInit } from '@angular/core';
import { Policy } from '../Models/policy';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PolicyserviceService } from '../service/policy/policy-service.service';
import { AlertService } from '../_services/alert.service';

@Component({
  selector: 'app-createpolicy',
  templateUrl: './createpolicy.component.html',
  styleUrls: ['./createpolicy.component.css']
})
export class CreatepolicyComponent implements OnInit {

  error: string = ""
  typeOfFunction:string="create";


  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private policyService: PolicyserviceService,
    private alertService: AlertService) { }

  ngOnInit(): void {
   
  }


  createPolicy(policy : Policy) {
    this.policyService.createPolicy(policy).subscribe(
      {
        next: (data) => { },
        error: (error) => {
          this.error = error.error;
          console.log(this.error);
        },
        complete: () => {
          this.alertService.success('policy detail saved', { keepAfterRouteChange: true });
          this.router.navigateByUrl('/policy-grid');
        }
      });
  }

}
