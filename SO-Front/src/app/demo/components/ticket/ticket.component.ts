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
    ticket: ticket = {};

    cols: any[] = [];
    _selectedColumns: any[] = [];

    _ = get;

    loading: boolean = true;
    ticketDialog: boolean = false;
    submitted: boolean = false;

    complexity: any;
    priority: any;

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
                header: 'Protocolo',
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
        this.priority = ['Baixa', 'Média', 'Alta'];
        this.complexity = ['Baixa', 'Média', 'Alta'];
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
    openNew() {
        this.ticket = {};
        this.submitted = false;
        this.ticketDialog = true;
    }
    hideDialog() {
        this.ticketDialog = false;
        this.submitted = false;
    }
    saveTicket() {
        console.log(this.ticket);
        this.submitted = true;
        if (
            this.ticket.protocol &&
            this.ticket.complexity &&
            this.ticket.priority &&
            this.ticket.subject
        ) {
            if (!this.ticket.id) {
                this.ticketService.createTicket(this.ticket).subscribe(
                    (x) => {
                        this.messageService.add({
                            severity: 'success',
                            summary: `Ticket criado!`,
                            detail: `Seu ticket foi criado em: ${x.elapsed.elapsedMilliseconds}ms`,
                            life: 3000,
                        });
                        this.ticketDialog = false;
                        this.fetchData();
                    },
                    (error) => {
                        this.messageService.add({
                            severity: 'error',
                            summary: `Erro ${error.code ?? error.status}`,
                            detail: `Não foi possível salvar seu ticket! \n Erro: ${
                                error.title ?? error.message
                            }`,
                            life: 3000,
                        });
                    }
                );
            } else {
                this.ticketService
                    .updateTicket(this.ticket.id, this.ticket)
                    .subscribe(
                        (x) => {
                            this.messageService.add({
                                severity: 'success',
                                summary: `Ticket atualizado!`,
                                detail: `Seu ticket foi atualizado em: ${x.elapsed.elapsedMilliseconds}ms`,
                                life: 3000,
                            });
                            this.ticketDialog = false;
                            this.fetchData();
                        },
                        (error) => {
                            this.messageService.add({
                                severity: 'error',
                                summary: `Erro ${error.code ?? error.status}`,
                                detail: `Não foi possível atualizar seu ticket! \n Erro: ${
                                    error.title ?? error.message
                                }`,
                                life: 3000,
                            });
                        }
                    );
            }
        }
    }

    editTicket(ticketSelected: ticket) {
        this.ticket = { ...ticketSelected };
        this.ticketDialog = true;
    }

    deleteTicket(ticketSelected: ticket) {
        this.confirmationService.confirm({
            message: `Você tem certeza que deseja excluir o ticket ${ticketSelected.protocol}?`,
            header: 'Confirmar operação',
            acceptLabel: 'Sim',
            rejectLabel: 'Não',
            accept: () => {
                this.ticketService.deleteTicket(ticketSelected.id!).subscribe(
                    (x) => {
                        this.messageService.add({
                            severity: 'success',
                            summary: `Ticket excluído!`,
                            detail: `Seu ticket foi excluído em: ${x.elapsed.elapsedMilliseconds}ms`,
                            life: 3000,
                        });
                        this.fetchData();
                    },
                    (error) => {
                        this.messageService.add({
                            severity: 'error',
                            summary: `Erro ${error.code ?? error.status}`,
                            detail: `Não foi possível excluir seu ticket! \n Erro: ${
                                error.title ?? error.message
                            }`,
                            life: 3000,
                        });
                    }
                );
            },
        });
    }

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
