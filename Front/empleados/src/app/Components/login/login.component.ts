import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms'


import { operacionesService } from '../../service/operaciones.service'
import { error } from 'protractor';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor( private servicio: operacionesService, private router: Router, private FormBuilder: FormBuilder) { }

   resValLoguin: string = "";
   _showAlertLogin: boolean = false;
  

  ngOnInit(): void {
  }

  formLogin = this.FormBuilder.group({
    usuario!: ['', { validators: [Validators.required, Validators.maxLength(20)] }],
    contrasena!: ['', { validators: [Validators.required] }],
  })


  alerts!: any[];
  onClosedAlert() {
    this._showAlertLogin = false;
  }

  ValidarLogin(){

      let user: string = this.formLogin.get('usuario').value;
      let pass: string = this.formLogin.get('contrasena').value;

      this.servicio.LoguearEmpleado(user, pass).subscribe( res => {
        
        if (res == "OK"){
          this.router.navigate(['ListaEmpleados']);
        }else{  
          this._showAlertLogin = true;
          this.resValLoguin = res.toString();
        }
      }, error => {
        this._showAlertLogin = true;
        this.resValLoguin = error.error.text;
      });
  }

}
