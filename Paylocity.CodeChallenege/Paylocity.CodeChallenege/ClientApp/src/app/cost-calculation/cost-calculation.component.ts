import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cost-calculation-component',
  templateUrl: './cost-calculation.component.html'
})
export class CostCalculationComponent {
  public customerTypes = [{ 'id': 'c', 'name': 'Employee' }, { 'id': 'd', 'name': 'Dependent' }];

  public costCalculationForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl(''),
    customerType: new FormControl('')
  });

}
