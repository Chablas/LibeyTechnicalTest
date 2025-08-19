import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Province } from "src/app/entities/province";
@Injectable({
    providedIn: "root",
})
export class ProvinceService {
    constructor(private http: HttpClient) { }

    Find(provinceCode: string): Observable<Province> {
        const uri = `${environment.pathLibeyTechnicalTest}ProvinceCode/${provinceCode}`;
        return this.http.get<Province>(uri);
    }

    async GetAll(): Promise<Province[]> {
        const uri = `${environment.pathLibeyTechnicalTest}Province`;
        const respuesta = await fetch(uri, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        });
        if (!respuesta.ok) {
            throw new Error("Error");
        }
        const datos = await respuesta.json();
        return datos;
    }
}