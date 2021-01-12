import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { AccountService } from '../../_services/account.service';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  private apiUrl = environment.apiUrl;

  title = "The Dating App";
  users: any;
  private loggedIn = false;
  constructor(private http: HttpClient, private accountService: AccountService) {
    this.loggedIn = this.accountService.loggedIn;
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.http.get(this.apiUrl + '/users')
      .subscribe(response => {
        this.users = response;
      }, error => {
        console.log(error);
      });
  }
}
