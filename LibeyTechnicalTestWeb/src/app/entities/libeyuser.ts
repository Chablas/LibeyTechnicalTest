import { Region } from "src/app/entities/region";
import { Province } from "src/app/entities/province";
import { Ubigeo } from "src/app/entities/ubigeo";
import { DocumentType } from "src/app/entities/documentType";
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
  documentType: DocumentType;
  name: string;
  fathersLastName: string;
  mothersLastName: string;
  address: string;
  region: Region;
  province: Province;
  ubigeo: Ubigeo;
  phone: string;
  email: string;
  password: string;
  active: boolean;
}