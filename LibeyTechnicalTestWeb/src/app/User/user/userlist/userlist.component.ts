import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { LibeyUser } from "src/app/entities/libeyuser";
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {
	users: LibeyUser[] = [];
	constructor(private libeyUserService: LibeyUserService, private router: Router) { }

  ngOnInit(): void {
    this.libeyUserService.GetAll().then(data => {
      this.users = data;
    });
  }

  async deleteUser(documentNumber: string, index: number) {
    const confirmDelete = confirm('¿Seguro que quieres eliminar este usuario?');
    if (!confirmDelete) return;

    try {
      await this.libeyUserService.Delete(documentNumber);
      this.users.splice(index, 1);
    } catch (error) {
      console.error('Error eliminando usuario:', error);
    }
  }

  editUser(documentNumber: string) {
    this.router.navigate(['/user/edit', documentNumber]);
  }
}