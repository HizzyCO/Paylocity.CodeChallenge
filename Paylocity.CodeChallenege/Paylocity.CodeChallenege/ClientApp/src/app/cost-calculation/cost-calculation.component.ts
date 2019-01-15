import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cost-calculation-component',
  templateUrl: './cost-calculation.component.html'
})
export class CostCalculationComponent {

    customerTypes = [{ 'id': 'c', 'name': 'Employee' }, { 'id': 'd', 'name': 'Dependent' }];

 
    onSubmit(){
      console.warn("Submit");
    }

}
