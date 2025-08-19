import { Region } from "src/app/entities/region";
export interface Province{
    provinceCode:string;
    provinceDescription:string;
    region: Region;
}