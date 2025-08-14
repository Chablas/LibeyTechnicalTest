import { Component, OnInit } from '@angular/core';
import swal from 'sweetalert2';
import { environment } from 'src/environments/environment';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";

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

  constructor(private libeyUserService: LibeyUserService) { }

  ngOnInit(): void { }

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