import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Observable } from 'rxjs';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { environment } from '../../environments/environment';

import { Empleado } from '../models/Empleado';

@Injectable({
  providedIn: 'root'
})
export class operacionesService {

  private API_URL_EMPLEADO = 'http://localhost:49600/api/bussiness/';

  constructor(private _http: HttpClient) { }


  ListarEmpleados(){
    return this._http.get<Empleado[]>(this.API_URL_EMPLEADO +"ListarEmpleados");
  }

  LoguearEmpleado(usuario: string, contraseña :string){
    return this._http.get(this.API_URL_EMPLEADO +"validarloginempleadoaction/"+ usuario + "/"+contraseña);
  }

  RegistrarEmpleado(dataEmpleado: Empleado){
    return this._http.post(this.API_URL_EMPLEADO +"CrearEmpleado", dataEmpleado);
  }

  ActualizarEmpleado(dataEmpleado: Empleado){
    return this._http.put(this.API_URL_EMPLEADO +"actualizarempleado", dataEmpleado);
  }

  ObtenerEmpleado(documento: string){
    return this._http.get<Empleado>(this.API_URL_EMPLEADO +"consultardatosempleado/"+documento);
  }

}

