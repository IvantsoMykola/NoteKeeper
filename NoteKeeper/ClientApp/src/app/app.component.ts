import { Component, Inject, LOCALE_ID, } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(@Inject(LOCALE_ID) protected localeId: string) { }
}
