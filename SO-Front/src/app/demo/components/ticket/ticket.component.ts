import { Component, OnInit } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';

@Component({
    templateUrl: './ticket.component.html',
    providers: [MessageService, ConfirmationService],
    styles: [
        `
            :host ::ng-deep .p-frozen-column {
                font-weight: bold;
            }

            :host ::ng-deep .p-datatable-frozen-tbody {
                font-weight: bold;
            }

            :host ::ng-deep .p-progressbar {
                height: 0.5rem;
            }
        `,
    ],
})
export class TicketComponent implements OnInit {
    constructor() {}

    ngOnInit() {    }
}
