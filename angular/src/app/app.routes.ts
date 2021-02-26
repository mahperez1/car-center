import {RouteReuseStrategy, RouterModule, Routes} from '@angular/router';
import { PersonaComponent } from './Componentes/persona/persona.component';
import { MecanicoComponent } from './Componentes/mecanico/mecanico.component';
import { FacturaComponent } from './Componentes/factura/factura.component';
import {MantenimientoComponent} from './Componentes/mantenimiento/mantenimiento.component';
import {RepuestoComponent} from './Componentes/repuesto/repuesto.component';

const APP_ROUTES: Routes =[
    {path: 'persona', component: PersonaComponent},
    {path: 'mecanico', component: MecanicoComponent},
    {path: 'factura', component: FacturaComponent},
    {path: 'mantenimiento', component: MantenimientoComponent},
    {path: 'repuesto', component: RepuestoComponent},
    {path:'**', pathMatch:'full',redirectTo:''}
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);