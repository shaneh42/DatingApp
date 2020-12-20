import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  private apiUrl = environment.apiUrl;

  title = "The Dating App";
  users: any;
  constructor(private http: HttpClient) {

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
