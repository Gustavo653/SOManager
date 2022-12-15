import { Component, OnInit } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { ticket } from '../../api/ticket';
import { TicketService } from '../../service/ticket.service';

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
    tickets: ticket[] = [];
    constructor(private ticketService: TicketService) {}

    ngOnInit() {
        this.ticketService.getAllTickets().subscribe(
            (x) => {
                this.tickets = x.object;
            },
            (error) => {
                alert('Deu ruim!');
            }
        );
    }
}
