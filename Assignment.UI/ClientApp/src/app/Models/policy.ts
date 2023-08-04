export interface Policy{
    policyId: number;
    title: string;
    description: string;
    startDate: string;
    endDate: string;
    insuredAmount: number;
    premium : number;
    duration : number;
    insurerName:string;
    insurerHolderAge: number;
    policyTypeId: number;
    vehicleModel:string;
    vehicleNumber:string;
    houseAddress:string;
    assetValue:number;
    coverage: number;
    statusofPolicy : string;
    
    //status : boolean;
}