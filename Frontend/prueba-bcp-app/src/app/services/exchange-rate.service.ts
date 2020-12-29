import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CurrencyExchangeCalculatorPayload } from '../interfaces/currency-exchange-calculator-payload';
import { CurrencyExchangeCalculatorResponse } from '../interfaces/currency-exchange-calculator-response';

@Injectable({
  providedIn: 'root'
})
export class ExchangeRateService {
  constructor(private http: HttpClient) { }

  calculate(request: CurrencyExchangeCalculatorPayload) {
    return this.http.post<CurrencyExchangeCalculatorResponse>(`${environment.baseUrl}CurrencyExchangeCalculator`,request);
  }
}
