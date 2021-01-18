import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  public consulta: Consulta[];

  private ConsultatURL = "https://localhost:44368/api/Resultado/Ruby"; //Entorno Local

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));

    http.get<Consulta[]>(this.ConsultatURL).subscribe(result => {
      this.consulta = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string; 
  temperatureC: number;
  temperatureF: number;
  summary: string;
}


interface Consulta {
  id_consulta: number;
  engine: string;
  language: string;
  resultado: number

}
