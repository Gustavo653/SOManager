import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { TicketService } from './demo/service/ticket.service';
import { TicketComponent } from './demo/components/ticket/ticket.component';

@NgModule({
    declarations: [AppComponent, NotfoundComponent, TicketComponent],
    imports: [AppRoutingModule, AppLayoutModule],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        TicketService,
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
