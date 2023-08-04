import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Policy } from 'src/app/Models/policy';
import { Location } from '@angular/common';
import { PolicyserviceService } from 'src/app/service/policy/policy-service.service';

@Component({
  selector: 'app-policyform',
  templateUrl: './policyform.component.html',
  styleUrls: ['./policyform.component.css']
})
export class PolicyformComponent implements OnInit {

  policyForm!: FormGroup;
  formSubmitted: boolean = false;
  @Input() 
  type:string='';
  @Input()
  policyDetail:Policy = {
        policyId : 0,
        title: '',
        description: '',
        startDate: '', 
        endDate: '',
        insuredAmount: 0, 
        premium: 0, 
        duration: 0,
        insurerName: '', 
        insurerHolderAge: 0, 
        policyTypeId: 0, 
        coverage: 0, 
        vehicleNumber: '',
        vehicleModel: '',
        houseAddress: '',
        assetValue: 0,
        statusofPolicy: '',
    };
    
  @Input()
  policyid: number=0; //item
  @Input()
  disabledValue!:boolean;
  @Output()
  output = new EventEmitter<any>

  constructor(private FB: FormBuilder,  private location: Location,private route: ActivatedRoute, private service: PolicyserviceService) { }

  ngOnInit(): void {
  }

  ngOnChanges(){
    console.warn(this.policyid);
    console.warn(this.policyDetail.policyId);
    this.LoadForm();
    if(this.type=="view")
    this.policyForm.disable();
  }
  
  LoadForm() {
    console.warn(this.policyDetail)
    this.policyForm = this.FB.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      insuredAmount: [0, Validators.required],
      premium: [0, Validators.required],
      duration: [0, Validators.required],
      insurerName: ['', Validators.required],
      insurerHolderAge: [0, Validators.required],
      policyTypeId: [0, Validators.required],
      coverage: [0, Validators.required],
      vehicleNumber: [''],
      vehicleModel: [''],
      houseAddress: [''],
      status: [true],
      claims: [[]],
      statusOfPolicy: ['', Validators.required],
    });
    
  }

  createPolicy() {
    this.formSubmitted = true;
    const policy ={
      policyId: 0,
      title: this.policyForm.value['Title'],
      description: this.policyForm.value['Description'],
      startDate: this.policyForm.value['StartDate'],
      endDate: this.policyForm.value['EndDate'],
      insuredAmount: this.policyForm.value['InsuredAmount'],
      premium: this.policyForm.value['Premium'],
      duration: this.policyForm.value['Duration'],
      insurerName: this.policyForm.value['InsurerName'],
      insurerHolderAge: this.policyForm.value['InsurerHolderAge'],
      policyTypeId: this.policyForm.value['PolicyType'],
      vehicleModel: this.policyForm.value['VehicleModel'],
      vehicleNumber: this.policyForm.value['VehicleNumber'],
      houseAddress: this.policyForm.value['HouseAddress'],
      assetValue: this.policyForm.value['AssetValue'],
      coverage: this.policyForm.value['Coverage'],
      statusOfPolicy: this.policyForm.value['StatusOfPolicy'],
    }
    this.output.emit(policy);
  }

  updatePolicy() {
    console.warn(this.policyid);
    const policy = {
      policyId: this.policyid,
      title: this.policyForm.value['Title'],
      description: this.policyForm.value['Description'],
      startDate: this.policyForm.value['StartDate'],
      endDate: this.policyForm.value['EndDate'],
      insuredAmount: this.policyForm.value['InsuredAmount'],
      premium: this.policyForm.value['Premium'],
      duration: this.policyForm.value['Duration'],
      insurerName: this.policyForm.value['InsurerName'],
      insurerHolderAge: this.policyForm.value['InsurerHolderAge'],
      policyTypeId: this.policyForm.value['PolicyType'],
      vehicleModel: this.policyForm.value['VehicleModel'],
      vehicleNumber: this.policyForm.value['VehicleNumber'],
      houseAddress: this.policyForm.value['HouseAddress'],
      assetValue: this.policyForm.value['AssetValue'],
      coverage: this.policyForm.value['CoverageType'],
      statusOfPolicy: this.policyForm.value['StatusOfPolicy'],
    }
    console.warn(policy);
    this.output.emit(policy);
  }
  Back() {
    this.location.back();
  }

}
