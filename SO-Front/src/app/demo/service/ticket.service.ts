import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { base } from '../api/base';
import { ticket } from '../api/ticket';

@Injectable()
export class TicketService {
    constructor(private http: HttpClient) {}

    getAllTickets() {
        return this.http.get<base<ticket[]>>(
            `${environment.stringApiBase}/ticket/read`
        );
    }

    getTicket(id: number) {
        return this.http.get<base<ticket>>(
            `${environment.stringApiBase}/ticket/read/${id}`
        );
    }

    createTicket(ticketDTO: ticket) {
        return this.http.post<base<ticket>>(
            `${environment.stringApiBase}/ticket/create`,
            ticketDTO
        );
    }

    updateTicket(id: number, ticketDTO: ticket) {
        return this.http.put<base<ticket>>(
            `${environment.stringApiBase}/ticket/update/${id}`,
            ticketDTO
        );
    }

    deleteTicket(id: number) {
        return this.http.delete<base<ticket>>(
            `${environment.stringApiBase}/ticket/delete/${id}`
        );
    }
}
