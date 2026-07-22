import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { Appcomponent } from './app/app';

bootstrapApplication(Appcomponent, appConfig)
  .catch((err) => console.error(err));
