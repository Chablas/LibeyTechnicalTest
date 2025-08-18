import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import { environment } from 'src/environments/environment';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { RegionService } from "src/app/core/service/region/region.service";
import { Region } from "src/app/entities/region";

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

  constructor(private libeyUserService: LibeyUserService, private regionService: RegionService) { }

  async ngOnInit(): Promise<void> {
    try {
      this.regions = await this.regionService.GetAll();
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