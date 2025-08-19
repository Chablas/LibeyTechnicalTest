import { Region } from "src/app/entities/region";
import { Province } from "src/app/entities/province";
export interface Ubigeo{
    ubigeoCode:string;
    ubigeoDescription:string;
    region: Region;
    province: Province;
}