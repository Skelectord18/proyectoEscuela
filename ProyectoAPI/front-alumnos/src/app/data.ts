import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Data {
   getItems(): Observable<string[]> {
        return of(["item 1","item 2", "item 3"]);
    }
}
