import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ReferencesComponent } from './references/references.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  {path:'', redirectTo:'/home', pathMatch:'full'},
  {path:'home', component: HomeComponent},
  {path: 'upload', component: UploadComponent},
  {path:'references', component: ReferencesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
