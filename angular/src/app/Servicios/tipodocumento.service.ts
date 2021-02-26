import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from '../../environments/environment';
import { tipodocumento } from '../Models/tipodocumento.model';

@Injectable({
  providedIn: 'root'
})
export class TipodocumentoService {

  private ulrBaseApi = environment.ulrBaseApi + 'V1/TipoDocumento';

  constructor(private http: HttpClient) { }

  consultarTipoDocumento(): Observable<HttpResponse<tipodocumento[]>> {
    const path = `${this.ulrBaseApi}/TipoDocumentoTodo`;
    return this.http.get<tipodocumento[]>(path, {observe: 'response'});
}

}