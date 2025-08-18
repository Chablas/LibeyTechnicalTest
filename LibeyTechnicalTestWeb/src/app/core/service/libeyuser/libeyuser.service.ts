import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
import { LibeyUserForm } from 'src/app/entities/libeyuser';
import { LibeyUserAPIEdit } from 'src/app/entities/libeyuser';
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) { }

	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	async GetAll(): Promise<LibeyUser[]> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
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

	async Create(user: any): Promise<void> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;

		if (user.documentType === "DNI") {
			user.documentType = 0;
		}

		const data = {
			documentTypeId: user.documentType,
			documentNumber: user.documentNumber,
			name: user.name,
			fathersLastName: user.fathersLastName,
			mothersLastName: user.mothersLastName,
			address: user.address,
			ubigeoCode: user.district,
			provinceCode: user.province,
			regionCode: user.department,
			phone: user.phone,
			email: user.email,
			password: user.password
		};

		const respuesta = await fetch(uri, {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify(data),
		});

		if (!respuesta.ok) {
			throw new Error("Error al crear usuario");
		}
	}
	async Delete(documentNumber: string): Promise<void> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		const respuesta = await fetch(uri, {
			method: 'DELETE',
			headers: { 'Content-Type': 'application/json' }
		});

		if (!respuesta.ok) {
			throw new Error('Error eliminando usuario');
		}
	}

	async Update(user: any): Promise<void> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${user.documentNumber}`;
		const respuesta = await fetch(uri, {
			method: "PUT",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify(user)
		});

		if (!respuesta.ok) {
			throw new Error("Error al actualizar");
		}
	}

	mapUserToAPIEdit(formUser: LibeyUserForm): LibeyUserAPIEdit {
		return {
			...formUser,
			regionCode: formUser.region.regionCode,
		};
	}
}