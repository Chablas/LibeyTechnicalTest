import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { DocumentType } from "src/app/entities/documentType";
@Injectable({
    providedIn: "root",
})
export class DocumentTypeService {
    constructor(private http: HttpClient) { }

    Find(documentTypeId: number): Observable<DocumentType> {
        const uri = `${environment.pathLibeyTechnicalTest}DocumentType/${documentTypeId}`;
        return this.http.get<DocumentType>(uri);
    }

    async GetAll(): Promise<DocumentType[]> {
        const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
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