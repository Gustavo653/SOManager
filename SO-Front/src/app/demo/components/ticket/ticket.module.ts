import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketRoutingModule } from './ticket-routing.module';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { MultiSelectModule } from 'primeng/multiselect';
import { ProgressBarModule } from 'primeng/progressbar';
import { RatingModule } from 'primeng/rating';
import { RippleModule } from 'primeng/ripple';
import { SliderModule } from 'primeng/slider';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { TicketComponent } from './ticket.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogModule } from 'primeng/dialog';

@NgModule({
    declarations: [TicketComponent],
    imports: [
        CommonModule,
        TicketRoutingModule,
        FormsModule,
        TableModule,
        RatingModule,
        ButtonModule,
        SliderModule,
        InputTextModule,
        ToggleButtonModule,
        RippleModule,
        MultiSelectModule,
        DropdownModule,
        ProgressBarModule,
        ToastModule,
        ToolbarModule,
        ConfirmDialogModule,
        DialogModule
    ],
})
export class TicketModule {}
