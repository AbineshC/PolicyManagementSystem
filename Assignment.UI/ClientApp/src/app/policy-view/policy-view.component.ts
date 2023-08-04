import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PolicyserviceService } from '../service/policy/policy-service.service';
import { AlertService } from '../_services/alert.service';
import { first } from 'rxjs/internal/operators/first';
import { Policy } from '../Models/policy';

@Component({
  selector: 'app-policy-view',
  templateUrl: './policy-view.component.html',
  styleUrls: ['./policy-view.component.css']
})
export class PolicyViewComponent implements OnInit {
  form!: FormGroup;
  id?: any;
  title!: string;
  loading = false;
  submitting = false;
  submitted = false;
  policy? : Policy[];

  isEditing: boolean = false;

  status: boolean = true;
  
  policyId:number=0;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private policyService: PolicyserviceService,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.form = this.formBuilder.group({
      title: [''],
      description: [''],
      startDate: [''],
      endDate: [''],
      insuredAmount: [0],
      premium: [0],
      duration: [0],
      insurerName: [''],
      insurerHolderAge: [0],
      policyTypeId: [0],
      coverage: [0],
      vehicleNumber: [''],
      vehicleModel: [''],
      houseAddress: [''],
     status: [true],
      claims: [[]],
      statusOfPolicy: [''],
    });
    
    if (this.id) {

      this.loading = true;

      this.policyService.getPolicyById(this.id)

        .pipe(first())

        .subscribe(x => {

          this.form.patchValue(x);

          console.log(x);

          this.loading = false;

        });
  }
}
  

}
