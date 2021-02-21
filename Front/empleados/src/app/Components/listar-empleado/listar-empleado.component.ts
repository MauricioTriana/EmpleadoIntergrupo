import { Component, OnInit } from '@angular/core';
import {Empleado} from '../../models/Empleado'
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';

import { operacionesService } from '../../service/operaciones.service'
import { localStorageService } from '../../service/localStorage.service'


@Component({
  selector: 'app-listar-empleado',
  templateUrl: './listar-empleado.component.html',
  styleUrls: ['./listar-empleado.component.scss']
})
export class ListarEmpleadoComponent implements OnInit {

  constructor( private servicio: operacionesService, private router: Router, private route: ActivatedRoute, private cache: localStorageService ) { }

  ngOnInit(): void {
    this.ListarEmpleados();
  }

  public EmpleadosData!: Array<Empleado>;
  ListarEmpleados(){
    this.servicio.ListarEmpleados().subscribe(res => {
      this.EmpleadosData = res;
    }, error => {
      alert(error);
    });
    
  }

  ToEditEmpleado(documento: string){
    this.cache.dataCacheInfoSet("Documento", documento);
    this.router.navigate(['ActualizarEmpleado'], { relativeTo: this.route });
  }

  ToAddEmpleado(){
    this.router.navigate(['RegistrarEmpleado'], { relativeTo: this.route });
  }

}
