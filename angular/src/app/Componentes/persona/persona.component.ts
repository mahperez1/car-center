import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {TipodocumentoService} from '../../Servicios/tipodocumento.service';
import {PersonaService} from '../../Servicios/persona.service';
import {tipodocumento } from '../../Models/tipodocumento.model';
import {personamodel} from '../../Models/persona.model';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html'
})
export class PersonaComponent implements OnInit {

    /*form control*/
    personaForm: FormGroup;

    lsttipodocumento : tipodocumento[];
    objpersona: personamodel;
    public cmbtipodocumento = [];

  constructor(
    private _builder: FormBuilder,
    private tipodocumentoService: TipodocumentoService,
    private personaService: PersonaService,
  ) { 

    this.personaForm = this._builder.group({
      idPersona: [],
      primerNombre: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      segundoNombre: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      primerApellido: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      segundoApellido: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      numeroDocumento: ['', Validators.compose([Validators.required, Validators.minLength(7), Validators.maxLength(10), Validators.pattern('^([0-9])*$')])],  
      celular: ['', Validators.compose([Validators.required, Validators.minLength(7), Validators.maxLength(10), Validators.pattern('^([0-9])*$')])],  
      direccion: ['', Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(50)])],
      correo: ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(50), Validators.email])]
    }
    );
 
  }

  ngOnInit() {
    this.ConsultartipoDocumento();
  }

 /*Tipo documento*/
 ConsultartipoDocumento() {
   console.log('a');
  this.tipodocumentoService.consultarTipoDocumento()
  .subscribe(
      resp => {
              this.cmbtipodocumento = [];
              this.lsttipodocumento = resp.body;
              console.log(this.lsttipodocumento);
              for (const item of this.lsttipodocumento) {
                const departamento = {
                  id: item.id_tipo_documento,
                  nombre: item.nombre
              };
                this.cmbtipodocumento.push(departamento);
            }
          },
      err => {console.log(err.error.title, 'fail'); }
    );
}

crearPersona(){
  this.objpersona = {
    primer_nombre: this.personaForm.controls.primerNombre.value,
    segundo_nombre: this.personaForm.controls.segundoNombre.value,
    primer_apellido: String(this.personaForm.controls.primerApellido.value).toLowerCase(),
    segundo_apellido: String(this.personaForm.controls.segundoApellido.value).toLowerCase(),
    id_tipo_documento: 1,
    numero_documento: Number(this.personaForm.controls.numeroDocumento.value),
    celular: Number(this.personaForm.controls.celular.value),
    direccion: this.personaForm.controls.direccion.value,
    correo: String(this.personaForm.controls.correo.value)
  };
  this.personaService.crearSolicitudUsuario(this.objpersona)
  .subscribe(
          res => console.log('HTTP response', res),
          err => {
            console.log(err.error.title, 'fail');
          },
          () => {
            alert("persona creada exitosamente.");
            this.LimpiarCampos();
        }
  );
}

LimpiarCampos(){
  this.personaForm.reset();
}

}
