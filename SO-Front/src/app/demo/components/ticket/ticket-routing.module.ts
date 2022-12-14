import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TicketComponent } from './ticket.component';

@NgModule({
    imports: [
        RouterModule.forChild([{ path: '', component: TicketComponent }]),
    ],
    exports: [RouterModule],
})
export class TicketRoutingModule {}
