import { Injectable } from '@angular/core';

//models
import { cacheModelo } from '../models/cacheModelo';

@Injectable({
  providedIn: 'root'
})
export class localStorageService {

  constructor() {
  }

  dataCacheInfoSet(parametro: string, valorParametro: string) {
    localStorage.setItem(parametro, valorParametro);
  }

  dataCacheArrayInfoSet(dataArray: Array<cacheModelo>) {
    for (let index = 0; index < dataArray.length; index++) {
      localStorage.setItem(dataArray[index].parametro, dataArray[index].valor);
    }
  }

  dataCacheInfoGet(nombreCache: string) {
    return localStorage.getItem(nombreCache);
  }
}
