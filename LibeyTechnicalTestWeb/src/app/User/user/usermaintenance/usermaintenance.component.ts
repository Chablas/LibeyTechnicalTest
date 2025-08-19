import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import { environment } from 'src/environments/environment';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { ProvinceService } from "src/app/core/service/province/province.service";
import { UbigeoService } from "src/app/core/service/ubigeo/ubigeo.service";
import { DocumentTypeService } from "src/app/core/service/documentType/documentType.service";
import { RegionService } from "src/app/core/service/region/region.service";
import { Region } from "src/app/entities/region";
import { Province } from "src/app/entities/province";
import { Ubigeo } from "src/app/entities/ubigeo";
import { DocumentType } from "src/app/entities/documentType";

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  user = {
    documentType: '',
    documentNumber: '',
    name: '',
    fathersLastName: '',
    mothersLastName: '',
    address: '',
    department: '',
    province: '',
    district: '',
    phone: '',
    email: '',
    password: ''
  };

  regions: Region[] = [];
  provinces: Province[] = [];
  ubigeos: Ubigeo[] = [];
  documentTypes: DocumentType[] = [];

  constructor(private libeyUserService: LibeyUserService, 
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private documentTypeService: DocumentTypeService) { }

  async ngOnInit(): Promise<void> {
    try {
      this.regions = await this.regionService.GetAll();
      this.provinces = await this.provinceService.GetAll();
      this.ubigeos = await this.ubigeoService.GetAll();
      this.documentTypes = await this.documentTypeService.GetAll();
    } catch (error) {
      console.error("Error al cargar regiones:", error);
    }
  }

  async Submit() {
    try {
      await this.libeyUserService.Create(this.user);
      swal.fire("Éxito", "Usuario registrado correctamente", "success");
    } catch (error) {
      swal.fire("Oops!", "Ocurrió un error al registrar el usuario", "error");
      console.error(error);
    }
  }
}