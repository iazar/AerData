import { DirectoryResolver } from './../resolvers/directory-resolver';
import { DirectoryService } from './../services/directory.service';
import { FolderComponent } from './components/directory/folder/folder.component';
import { DirectoryComponent } from './components/directory/directory.component';
import { NavComponent } from './components/nav/nav.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutComponent } from './components/about/about.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AccordionModule } from 'ngx-bootstrap/accordion';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DirectoryComponent,
    FolderComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    AccordionModule.forRoot()
  ],
  providers: [ DirectoryService,
    DirectoryResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
