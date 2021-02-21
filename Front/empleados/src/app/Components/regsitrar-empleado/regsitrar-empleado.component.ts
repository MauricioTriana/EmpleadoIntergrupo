import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms'

import { operacionesService } from '../../service/operaciones.service'
import { Empleado } from '../../models/Empleado'

@Component({
  selector: 'app-regsitrar-empleado',
  templateUrl: './regsitrar-empleado.component.html',
  styleUrls: ['./regsitrar-empleado.component.scss']
})
export class RegsitrarEmpleadoComponent implements OnInit {

  constructor(private servicio: operacionesService, private router: Router, private FormBuilder: FormBuilder) { }

  noIguales: boolean = true;

  ngOnInit(): void {
  }


  AddEmpleado = this.FormBuilder.group({
    NombreEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    ApellidoEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    DocumentoEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    CargoEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    ContrasenaEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    ContrasenaEmpleadoConf!: ['', { validators: [Validators.required, Validators.maxLength(30)] }]
  });

  validarCoincideContrasena() {
    let Pass: string = this.AddEmpleado.get('ContrasenaEmpleado').value;
    let passConf: string = this.AddEmpleado.get('ContrasenaEmpleadoConf').value;
    
    if (
      Pass != "" && passConf != ""
    ) {
      if (Pass === passConf) {
        this.noIguales = true;
      } else {
        this.noIguales = false;
      }
    }
  }


  ToListas(){
    this.router.navigate(['ListaEmpleados']);
  }

  RegistarEmpleado(){
    let resultAddData = new Empleado(
      0,
      this.AddEmpleado.get('NombreEmpleado').value,
      this.AddEmpleado.get('ApellidoEmpleado').value,
      this.AddEmpleado.get('DocumentoEmpleado').value,
      this.AddEmpleado.get('CargoEmpleado').value,
      this.AddEmpleado.get('ContrasenaEmpleado').value
    )

    this.servicio.RegistrarEmpleado(resultAddData).subscribe( res => {
      alert(res)
      if (res === "registro exitoso"){
        this.ToListas();
      }
    },err =>{
      alert(err.error.text);
    });
  }

}
