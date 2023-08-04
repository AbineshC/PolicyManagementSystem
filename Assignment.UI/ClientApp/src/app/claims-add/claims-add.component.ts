import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Claims } from '../Models/claims';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../_services/alert.service';
import { ClaimsServiceService } from '../service/claims/claims-service.service';
import { first } from 'rxjs/internal/operators/first';

@Component({
  selector: 'app-claims-add',
  templateUrl: './claims-add.component.html',
  styleUrls: ['./claims-add.component.css']
})
export class ClaimsAddComponent implements OnInit {
  form!: FormGroup;
  id?: any;
  title!: string;
  loading = false;
  submitting = false;
  submitted = false;
  claims? : Claims[];

  isEditing: boolean = false;

  status: boolean = true;
  
  policyId:number=0;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private claimService : ClaimsServiceService,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.form = this.formBuilder.group({
     policyId : [0],
     claimAmount : [0],
     claimReason : [''],
     claimDescription : [''],
     claimDate : [''],
     statusOfClaim : [''],
     isActive : [true],

    });

    this.title = 'Add Claim';

    if (this.id) {

      // edit mode

      this.title = 'Edit Claim';

      this.loading = true;

      this.claimService.getClaimById(this.id)

        .pipe(first())

        .subscribe(x => {

          this.form.patchValue(x);

          console.log(x);

          this.loading = false;

        });

      this.isEditing = true;

    }
  }


  get f() { return this.form.controls; }
 
  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.submitting = true;
    if (!this.isEditing) {
      this.claimService.createClaim(this.form.value)
        .subscribe({
          next: () => {
            console.log(this.form.value)
            this.alertService.success('claim detail saved', { keepAfterRouteChange: true });
            this.router.navigateByUrl('/claim-view');
          },
          error: (error: any) => {
            this.alertService.error(error);
            this.submitting = false;
          }
        })
    }
    else {

      this.claimService.updateClaim(this.id, this.form.value)
      
        .subscribe(data =>

          this.claims = data);

      this.alertService.success('claims detail updated', { keepAfterRouteChange: true });

      this.router.navigateByUrl('/claim-view');

      (error: any) => {

        this.alertService.error(error);

        this.submitting = false;

      }

    }


  }
}
