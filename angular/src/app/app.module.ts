import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
//Rutas
import { APP_ROUTING } from './app.routes';

//Servicios
import {TipodocumentoService} from './Servicios/tipodocumento.service';

//Componentes
import { AppComponent } from './app.component';
import { NavbarComponent } from './Componentes/shared/navbar/navbar.component';
import { PersonaComponent } from './Componentes/persona/persona.component';
import { MecanicoComponent } from './Componentes/mecanico/mecanico.component';
import { FacturaComponent } from './Componentes/factura/factura.component';
import { MantenimientoComponent } from './Componentes/mantenimiento/mantenimiento.component';
import { RepuestoComponent } from './Componentes/repuesto/repuesto.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PersonaComponent,
    MecanicoComponent,
    FacturaComponent,
    MantenimientoComponent,
    RepuestoComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    TipodocumentoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
