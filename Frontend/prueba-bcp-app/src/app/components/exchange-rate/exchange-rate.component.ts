import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CurrencyExchangeCalculatorPayload } from 'src/app/interfaces/currency-exchange-calculator-payload';
import { CurrencyExchangeCalculatorResponse } from 'src/app/interfaces/currency-exchange-calculator-response';
import { ExchangeRateService } from 'src/app/services/exchange-rate.service';

@Component({
  selector: 'app-exchange-rate',
  templateUrl: './exchange-rate.component.html',
  styleUrls: ['./exchange-rate.component.scss']
})
export class ExchangeRateComponent implements OnInit {

  form = new FormGroup({
    FromCurrency: new FormControl('', Validators.required),
    ToCurrency: new FormControl('', Validators.required),
    Amount: new FormControl('', Validators.required)
  });

  model: CurrencyExchangeCalculatorResponse;

  constructor(private service: ExchangeRateService) { }

  ngOnInit(): void { }

  calculate() {
    this.service.calculate(this.form.value as CurrencyExchangeCalculatorPayload)
      .subscribe(response => {
        this.model = response;
      })
  }
}