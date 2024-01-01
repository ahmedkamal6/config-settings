import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { mapType, mapSubTypeFeature, mapSubTypeBasemap } from './data';
import { customNumValidator } from './custom-validators';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { ionAlertCircleOutline } from '@ng-icons/ionicons';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-configs-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgIconComponent,
    MatSlideToggleModule,
  ],
  providers: [provideIcons({ ionAlertCircleOutline })],
  templateUrl: './configs-form.component.html',
  styleUrl: './configs-form.component.css',
})
@Injectable()
export class ConfigsFormComponent {
  async ngOnInit() {
    try {
      const response = await this.http
        .get<any>('https://localhost:7031/api/Config/getConfig?id=1')
        .toPromise();
      if (response.data !== null) {
        this.yourForm.patchValue({
          clusterRadius: response.data.clusterRadius || '', // Replace 'clusterRadius' with your actual field names
          geoFencing: response.data.geoFencing || false,
          timeBuffer: response.data.timeBuffer || '',
          locationBuffer: response.data.locationBuffer || '',
          duration: response.data.duration || '',
          mapType:
            response.data.mapType === 'Feature'
              ? this.mapTypes[0]
              : response.data.mapType === 'Basemap'
              ? this.mapTypes[1]
              : '',
          mapSubType:
            response.data.mapSubType === 'Dynamic'
              ? this.mapFeatureSubTypes[0]
              : response.data.mapSubType === 'Cached'
              ? this.mapFeatureSubTypes[1]
              : response.data.mapSubType === 'Imagery'
              ? this.mapBasemapSubTypes[0]
              : response.data.mapSubType === 'Topographic'
              ? this.mapBasemapSubTypes[1]
              : '',
        });
      }
      this.yourForm.setValue({mapType:response.data.mapType})
    } catch (error) {
      
    }
  }

  async cancel() {
    console.log('here');
    try {
      console.log('here');
      const response = await this.http
      .delete<any>('https://localhost:7031/api/Config/deleteConfig?id=1').toPromise();
      console.log(response)
      alert('config deleted successfully');
      this.reset()
    } catch (error) {
      alert('error deleting config or nothing to delete');
      console.log(error);
    }
  }
  async save() {
    if (this.yourForm.valid) {
      try {
        const response = await this.http
          .get<any>('https://localhost:7031/api/Config/getConfig?id=1')
          .toPromise();
        if (response.data === null) {
          const formData = this.yourForm.value;
          console.log(formData)
          this.http
            .post('https://localhost:7031/api/Config/addConfig', formData, {
              headers: {
                'Content-Type': 'application/json',
              },
            })
            .subscribe(
              (response) => {
                alert('Data saved successfully:');
              },
              (error) => {
                alert('Error saving data');
                console.error('Error saving data:', error);
              }
            );
        } else {
          const formData = this.yourForm.value;
          this.http
            .put(
              'https://localhost:7031/api/Config/updateConfig',
              { id: 1, ...formData },
              {
                headers: {
                  'Content-Type': 'application/json',
                },
              }
            )
            .subscribe(
              (response) => {
                alert('Data updated successfully:');
              },
              (error) => {
                alert('Error updating data');
                console.error('Error updated data:', error);
              }
            );
        }
      } catch (error) {
        
      }
    } else {
      Object.values(this.yourForm.controls).forEach((control) => {
        control.markAsTouched();
      });
    }
  }
  reset() {
    this.yourForm.reset();
  }
  mapTypes: string[] = mapType;
  mapFeatureSubTypes: string[] = mapSubTypeFeature;
  mapBasemapSubTypes: string[] = mapSubTypeBasemap;
  selectedDataArray: string[] = []; // Array to store selected data array
  mapSubTypes: string[] = [];
  yourForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private http: HttpClient) {
    this.yourForm = this.formBuilder.group({
      clusterRadius: ['', customNumValidator(99, 0.01)],
      geoFencing: [false],
      timeBuffer: ['', customNumValidator(999, 1)],
      locationBuffer: ['', customNumValidator(9.999, 1)],
      duration: ['', customNumValidator(99, 1)],
      mapType: ['', Validators.required],
      mapSubType: ['', Validators.required],
    });
  }

  onSelectChange(event: any) {
    const value = event.target.value;
    if (value === this.mapTypes[0]) {
      this.selectedDataArray = this.mapFeatureSubTypes;
    } else if (value === this.mapTypes[1]) {
      this.selectedDataArray = this.mapBasemapSubTypes;
    } else {
      this.selectedDataArray = [];
    }
  }
  numberChange(event: any): void {
    const enteredValue: string = event.target.value;
    const decimalIndex: number = enteredValue.indexOf('.');
    if (decimalIndex !== -1 && enteredValue.length - decimalIndex > 3)
      event.target.value = enteredValue.slice(0, decimalIndex + 3);
  }
}
