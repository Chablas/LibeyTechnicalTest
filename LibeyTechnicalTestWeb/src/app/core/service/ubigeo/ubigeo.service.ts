import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
    providedIn: "root",
})
export class UbigeoService {
    constructor(private http: HttpClient) { }

    Find(ubigeoCode: string): Observable<Ubigeo> {
        const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/${ubigeoCode}`;
        return this.http.get<Ubigeo>(uri);
    }

    async GetAll(): Promise<Ubigeo[]> {
        const uri = `${environment.pathLibeyTechnicalTest}Ubigeo`;
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