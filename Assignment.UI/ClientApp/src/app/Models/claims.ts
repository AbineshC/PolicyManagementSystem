export interface Claims{
    claimId : number;
    policyId: number;
    claimAmount : number;
    claimReason : string;
    claimDescription : string;
    claimDate : string;
    statusOfClaim : string;
    isActive : boolean;
}