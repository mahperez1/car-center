import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from '../../environments/environment';
import { personamodel } from '../Models/persona.model';

@Injectable({
  providedIn: 'root'
})

export class PersonaService {

  private ulrBaseApi = environment.ulrBaseApi + 'V1/Persona';

  constructor(private http: HttpClient) { }

  crearSolicitudUsuario( objpersona: personamodel) {
    if (objpersona !== undefined) {
      const path = `${this.ulrBaseApi}/Persona`;
      return this.http.post(path, objpersona);
    }
  }

}


