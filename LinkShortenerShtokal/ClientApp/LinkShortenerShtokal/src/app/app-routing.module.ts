import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./add-url/add-url.module').then(m => m.AddUrlModule),
    pathMatch: 'full'
  },
  {
    path: 'management',
    loadChildren: () => import('./add-url/add-url.module').then(m => m.AddUrlModule),
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
