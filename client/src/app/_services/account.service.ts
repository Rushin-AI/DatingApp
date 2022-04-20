import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from 'src/app/_models/User';
import { environment } from 'src/environments/environment';
import { HomeComponent } from '../home/home.component';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseurl = environment.apiUrl;
private currentUserSource = new ReplaySubject<User>(1);
currentUser$ = this.currentUserSource.asObservable(); 

constructor(private http: HttpClient) { }
login(model:any)
{
  return this.http.post(this.baseurl + 'account/login', model).pipe(
    map((response: User) =>{
      const user = response;
      if(user){
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      }
    })
  ) 
} 
    register(model: any)
    {
      return this.http.post(this.baseurl + 'account/register', model).pipe( 
        map((user: User) =>{
          if(user){
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
          }
        
        })
      )
      } 
setCurrentUser(user: User)
{ this.currentUserSource.next(user);
  // this.currentUserSource.next(null);  
}


logout(){
  localStorage.removeItem('user');
  this.currentUserSource.next(null);  
 }

}
