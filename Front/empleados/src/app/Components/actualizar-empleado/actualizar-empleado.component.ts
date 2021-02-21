import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms'

import { operacionesService } from '../../service/operaciones.service'
import { localStorageService } from '../../service/localStorage.service'

import { Empleado } from '../../models/Empleado'

@Component({
  selector: 'app-actualizar-empleado',
  templateUrl: './actualizar-empleado.component.html',
  styleUrls: ['./actualizar-empleado.component.scss']
})
export class ActualizarEmpleadoComponent implements OnInit {
  constructor(private servicio: operacionesService, private router: Router, private FormBuilder: FormBuilder, private cache: localStorageService) { }

  empleadoEditar:Empleado;

  ngOnInit(): void {
    this.ListarEmpleadoEditar();
  }

  ListarEmpleadoEditar(){
    this.servicio.ObtenerEmpleado(this.cache.dataCacheInfoGet("Documento")).subscribe(res =>{
      this.empleadoEditar = res;

      if(this.empleadoEditar == null){
        alert("No se pudo encontrar informacion del empleado: "+this.cache.dataCacheInfoGet("Documento"));
      }

    },err =>{
      alert("ocurrio un error al consultar usuario a editar; Error = "+ err.error.text);
    });
  }

  EditEmpleado = this.FormBuilder.group({
    NombreEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    ApellidoEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    CargoEmpleado!: ['', { validators: [Validators.required, Validators.maxLength(30)] }]
  });

  ToListaEmpleados(){
    this.router.navigate(['ListaEmpleados']);
  }

  ActualizarEmpleado(){
    let resultAddData = new Empleado(
      this.empleadoEditar.IdEmpleado,
      this.EditEmpleado.get('NombreEmpleado').value,
      this.EditEmpleado.get('ApellidoEmpleado').value,
      this.empleadoEditar.DocumentoIdentidad,
      this.EditEmpleado.get('CargoEmpleado').value,
      this.empleadoEditar.contrasena
    )

    this.servicio.ActualizarEmpleado(resultAddData).subscribe( res => {
      alert(res)
      if (res === "Actualizacion exitosa"){
        this.ToListaEmpleados();
      }
    },err =>{
      alert(err.error.text);
    });
  }

}
