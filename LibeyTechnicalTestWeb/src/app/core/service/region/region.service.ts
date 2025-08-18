import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Region } from "src/app/entities/region";
@Injectable({
    providedIn: "root",
})
export class RegionService {
    constructor(private http: HttpClient) { }

    Find(regionCode: string): Observable<Region> {
        const uri = `${environment.pathLibeyTechnicalTest}RegionCode/${regionCode}`;
        return this.http.get<Region>(uri);
    }

    async GetAll(): Promise<Region[]> {
        const uri = `${environment.pathLibeyTechnicalTest}Region`;
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