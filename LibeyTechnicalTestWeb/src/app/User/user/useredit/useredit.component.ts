import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { ProvinceService } from "src/app/core/service/province/province.service";
import { UbigeoService } from "src/app/core/service/ubigeo/ubigeo.service";
import { DocumentTypeService } from "src/app/core/service/documentType/documentType.service";
import { LibeyUser } from 'src/app/entities/libeyuser';
import swal from 'sweetalert2';
import { Region } from "src/app/entities/region";
import { RegionService } from "src/app/core/service/region/region.service";
import { Province } from "src/app/entities/province";
import { Ubigeo } from "src/app/entities/ubigeo";
import { DocumentType } from "src/app/entities/documentType";

@Component({
  selector: 'app-user-edit',
  templateUrl: './useredit.component.html',
  styleUrls: ['./useredit.component.css']
})
export class UserEditComponent implements OnInit {
  user: any = {
    documentTypeId: '',
    documentNumber: '',
    name: '',
    fathersLastName: '',
    mothersLastName: '',
    address: '',
    region: {
      regionCode: '',
      regionDescription: ''
    },
    province: {
      provinceCode: '',
      provinceDescription: '',
      region: {
        regionCode: '',
        regionDescription: ''
      }
    },
    ubigeo: {
      ubigeoCode: '',
      ubigeoDescription: '',
      province: {
        provinceCode: '',
        provinceDescription: '',
        region: '',
      },
      region: {
        regionCode: '',
        regionDescription: ''
      }
    },
    phone: '',
    email: '',
    password: '',
    active: true
  };

  regions: Region[] = [];
  provinces: Province[] = [];
  ubigeos: Ubigeo[] = [];
  documentTypes: DocumentType[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private libeyUserService: LibeyUserService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private documentTypeService: DocumentTypeService
  ) {}

  async ngOnInit(): Promise<void> {
    try {
      this.regions = await this.regionService.GetAll();
      this.provinces = await this.provinceService.GetAll();
      console.log(this.provinces);
      this.ubigeos = await this.ubigeoService.GetAll();
      this.documentTypes = await this.documentTypeService.GetAll();
      const docNumber = this.route.snapshot.paramMap.get('documentNumber');
      if (docNumber) {
        this.libeyUserService.Find(docNumber).subscribe({
          next: (data) => {
            this.user = { ...data, active: data.active ?? true };
          },
          error: (err) => console.error(err)
        });
      }
    } catch (error) {
      console.error("Error al cargar regiones:", error);
    }
  }

  async Submit() {
    try {
      await this.libeyUserService.Update(this.libeyUserService.mapUserToAPIEdit(this.user));
      swal.fire('Éxito', 'Usuario actualizado correctamente', 'success');
      this.router.navigate(['/user/list']);
    } catch (error) {
      swal.fire('Error', 'Ocurrió un error al actualizar el usuario', 'error');
      console.error(error);
    }
  }
}