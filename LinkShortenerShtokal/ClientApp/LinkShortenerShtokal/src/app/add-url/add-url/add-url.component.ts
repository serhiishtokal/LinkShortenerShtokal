import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddUrlHttpService } from './shared/add-url-http.service';
import { IShortenedUrl } from './shared/shortened-url';

@Component({
  selector: 'add-url',
  templateUrl: './add-url.component.html',
  styleUrls: ['./add-url.component.scss'],
})
export class AddUrlComponent implements OnInit {
  public form: FormGroup;
  public baseRedirectUrl: string;
  public shortenedUrls: IShortenedUrl[] = [];

  constructor(private addUrlHttpService: AddUrlHttpService, fb: FormBuilder, private cd: ChangeDetectorRef) { 
    this.form = fb.group({
      url: ['', Validators.required]
    })
    this.baseRedirectUrl = addUrlHttpService.baseRedirectUrl;
  }

  ngOnInit(): void {
    this.form.statusChanges.subscribe(result=>console.log(result));
    this.addUrlHttpService.getAll()
      .subscribe(shortenedUrls=>this.shortenedUrls = shortenedUrls);
  }

  addNewUrlClicked(){
    if(this.form.valid){
      const url = this.form.controls["url"].value;
      this.addUrlHttpService.createShortenedUrl(url)
      .subscribe((shortenedUrl)=>this.onUrlCreated(shortenedUrl));
    }
  }

  onUrlCreated(shortenedUrl: IShortenedUrl){
    this.shortenedUrls.push(shortenedUrl);
  }

  deleteClicked(idx: number){
    const shortenedUrl = this.shortenedUrls[idx];
    this.shortenedUrls.splice(idx, 1);
    this.addUrlHttpService.delete(shortenedUrl.id)
      .subscribe();
    }
}
