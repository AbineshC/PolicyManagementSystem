import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Policy } from 'src/app/Models/policy';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class PolicyserviceService {


  // baseurl = 'https://localhost:5001/'
  constructor(private http: HttpClient) { }


  
  
  createPolicy( app: Policy) {
    // app.status = status
   // console.warn(policyData);
    return this.http.post<Policy>('https://localhost:5001/api/Policy', app);
  }
  getPolicy() {
    return this.http.get<any>(`https://localhost:5001/api/Policy`);
  }
  getPolicyById(policyId: number) {
    return this.http.get<any>(`https://localhost:5001/api/Policy/id?id=${policyId}`);
  }
  deletePolicy(policyId: number) {
    console.warn(policyId);
    return this.http.delete<any>(`https://localhost:5001/api/Policy?id=${policyId}`)
  }
  updatePolicy(id: number, policy: Policy) {
    policy.policyId = id;
    console.log(policy);
    return this.http.put<any>(`https://localhost:5001/api/Policy`, policy);
  }
}

