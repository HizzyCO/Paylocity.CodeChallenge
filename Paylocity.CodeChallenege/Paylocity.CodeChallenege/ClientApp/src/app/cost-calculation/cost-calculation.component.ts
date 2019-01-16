import { Component } from '@angular/core';
import { Customer } from './customer.interface';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cost-calculation-component',
  templateUrl: './cost-calculation.component.html'
})
export class CostCalculationComponent {
    http: HttpClient;

    constructor(http: HttpClient) { this.http = http }   

    customer: Customer = {
        firstName: '',
        lastName: '',
        customerType: ''
    };

    cost: CustomerCost = {
        name: '',
        coverageCost: 0
    }

    customerTypes = [{ 'id': 'c', 'name': 'Employee' }, { 'id': 'd', 'name': 'Dependent' }];


    onSubmit({ value, valid }: { value: Customer, valid: boolean }) {       
        this.http.get<CustomerCost>('https://localhost:44315/api/cost/' + value.firstName + '/' + value.customerType).subscribe(result => {
            this.cost = result
        }, error => console.error(error))
    }

}

interface CustomerCost {
    name: string;
    coverageCost: number;
}
