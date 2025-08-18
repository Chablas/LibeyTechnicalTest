import { Region } from "src/app/entities/region";
export interface LibeyUser{
    documentNumber:string;
    documentTypeId:number;
    name:string;
    fathersLastName :string;
    mothersLastName :string;
    address :string;
    regionCode :string;
    provinceCode :string;       
    ubigeoCode :string;
    phone :string;
    email :string;
    password :string;
    active :boolean;
}
export interface LibeyUserAPIPost{
    documentNumber:string;
    documentTypeId:number;
    name:string;
    fathersLastName :string;
    mothersLastName :string;
    address :string;
    regionCode :string;
    provinceCode :string;       
    ubigeoCode :string;
    phone :string;
    email :string;
    password :string;
}
export interface LibeyUserAPIEdit{
    name:string;
    fathersLastName :string;
    mothersLastName :string;
    address :string;
    regionCode :string;
    provinceCode :string;       
    ubigeoCode :string;
    phone :string;
    email :string;
    password :string;
    active :boolean;
}
export interface LibeyUserForm {
  documentNumber: string;
  documentTypeId: number;
  name: string;
  fathersLastName: string;
  mothersLastName: string;
  address: string;
  region: Region;
  provinceCode: string;
  ubigeoCode: string;
  phone: string;
  email: string;
  password: string;
  active: boolean;
}