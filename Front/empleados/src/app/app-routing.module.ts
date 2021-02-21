import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActualizarEmpleadoComponent } from './Components/actualizar-empleado/actualizar-empleado.component';
import { ListarEmpleadoComponent } from './Components/listar-empleado/listar-empleado.component';
import { LoginComponent } from './Components/login/login.component';
import { RegsitrarEmpleadoComponent } from './Components/regsitrar-empleado/regsitrar-empleado.component';

const routes: Routes = [
  {
    path: 'ListaEmpleados', component: ListarEmpleadoComponent,
    children: [{ path: 'RegistrarEmpleado', component: RegsitrarEmpleadoComponent },
               { path: 'ActualizarEmpleado', component: ActualizarEmpleadoComponent }]
  },
  { path: 'Login', component: LoginComponent },
  { path: '', redirectTo: '/Login', pathMatch: 'full' }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
