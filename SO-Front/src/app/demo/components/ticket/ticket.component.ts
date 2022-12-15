import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { base } from '../../api/base';
import { ticket } from '../../api/ticket';
import { TicketService } from '../../service/ticket.service';
import { get } from 'lodash';
import { Table } from 'primeng/table';

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
    baseTicket!: base<ticket[]>;
    selectedTickets: ticket[] = [];

    cols: any[] = [];
    _selectedColumns: any[] = [];

    _ = get;

    loading: boolean = true;

    @ViewChild('filter') filter!: ElementRef;

    constructor(
        private ticketService: TicketService,
        private router: Router,
        private confirmationService: ConfirmationService,
        private messageService: MessageService
    ) {}

    ngOnInit() {
        this.cols = [
            {
                field: 'protocol',
                header: 'Chamado',
                type: 'text',
            },
            {
                field: 'subject',
                header: 'Assunto',
                type: 'text',
            },
            {
                field: 'priority',
                header: 'Prioridade',
                type: 'text',
            },
            {
                field: 'complexity',
                header: 'Complexidade',
                type: 'text',
            },
            {
                field: 'createdBy',
                header: 'Criado por',
                type: 'text',
            },
            {
                field: 'changedBy',
                header: 'Alterado por',
                type: 'text',
            },
            {
                field: 'createdDate',
                header: 'Criado em',
                type: 'date',
                date: true,
                format: `dd/MM/yyyy HH:MM:SS`,
            },
            {
                field: 'changedDate',
                header: 'Alterado em',
                type: 'date',
                date: true,
                format: `dd/MM/yyyy HH:MM:SS`,
            },
        ];
        this._selectedColumns = this.cols;
        this.fetchData();
    }
    fetchData() {
        this.loading = true;
        this.ticketService.getAllTickets().subscribe(
            (x) => {
                this.tickets = x.object;
                this.baseTicket = x;
                this.messageService.add({
                    severity: 'success',
                    summary: `Tickets carregados!`,
                    detail: `Seus tickets foram carregados em: ${x.elapsed.elapsedMilliseconds}ms`,
                    life: 3000,
                });
            },
            (error) => {
                this.messageService.add({
                    severity: 'error',
                    summary: `Erro ${error.code ?? error.status}`,
                    detail: `Não foi possível obter os tickets! \n Erro: ${
                        error.title ?? error.message
                    }`,
                    life: 3000,
                });
            }
        );
        this.loading = false;
    }
    deleteSelectedTickets() {}
    openNew() {}

    editTicket(ticket: ticket) {
        console.log(ticket);
    }
    deleteTicket(ticket: ticket) {}

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal(
            (event.target as HTMLInputElement).value,
            'contains'
        );
    }

    clear(table: Table) {
        table.clear();
        this.filter.nativeElement.value = '';
    }

    @Input() get selectedColumns(): any[] {
        return this._selectedColumns;
    }

    set selectedColumns(val: any[]) {
        this._selectedColumns = this.cols.filter((col) => val.includes(col));
    }
}
