import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Claims } from 'src/app/Models/claims';

@Injectable({
  providedIn: 'root'
})
export class ClaimsServiceService {

  constructor(private http: HttpClient) { }

  createClaim( app: Claims) {
    // app.status = status
   // console.warn(policyData);
    return this.http.post<Claims>('https://localhost:5001/api/Claim', app);
  }
  getClaim() {
    return this.http.get<any>(`https://localhost:5001/api/Claim`);
  }
  getClaimById(claimId: number) {
    return this.http.get<any>(`https://localhost:5001/api/Claim/id?id=${claimId}`);
  }
  deleteCLaim(claimId: number) {
    console.warn(claimId);
    return this.http.delete<any>(`https://localhost:5001/api/Claim?id=${claimId}`)
  }
  updateClaim(id: number, claim: Claims) {
    claim.claimId = id;
    console.log(claim);
    return this.http.put<any>(`https://localhost:5001/api/Claim`, claim);
  }
}
