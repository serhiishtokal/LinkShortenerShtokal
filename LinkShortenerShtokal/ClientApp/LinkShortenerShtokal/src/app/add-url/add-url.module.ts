import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUrlComponent } from './add-url/add-url.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AddUrlHttpService } from './add-url/shared/add-url-http.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: AddUrlComponent
  },
];

@NgModule({
  declarations: [
    AddUrlComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    AddUrlComponent
  ],
  providers: [AddUrlHttpService]
})
export class AddUrlModule { }
