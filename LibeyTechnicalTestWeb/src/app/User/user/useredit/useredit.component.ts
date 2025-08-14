import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import swal from 'sweetalert2';

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
    regionCode: '',
    provinceCode: '',
    ubigeoCode: '',
    phone: '',
    email: '',
    password: '',
    active: true
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private libeyUserService: LibeyUserService
  ) {}

  ngOnInit(): void {
    const docNumber = this.route.snapshot.paramMap.get('documentNumber');
    if (docNumber) {
      this.libeyUserService.Find(docNumber).subscribe({
        next: (data) => {
          this.user = { ...data, active: data.active ?? true };
        },
        error: (err) => console.error(err)
      });
    }
  }

  async Submit() {
    try {
      await this.libeyUserService.Update(this.user);
      swal.fire('Éxito', 'Usuario actualizado correctamente', 'success');
      this.router.navigate(['/user/list']);
    } catch (error) {
      swal.fire('Error', 'Ocurrió un error al actualizar el usuario', 'error');
      console.error(error);
    }
  }
}