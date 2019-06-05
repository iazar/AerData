import { DirectoryResolver } from './../resolvers/directory-resolver';
import { AboutComponent } from './components/about/about.component';
import { DirectoryComponent } from './components/directory/directory.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: DirectoryComponent, resolve: {directoriesList: DirectoryResolver}},
  { path:'about', component: AboutComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
