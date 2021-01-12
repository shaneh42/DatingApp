import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(private router: Router,
     private accountService: AccountService) {

  }
  
  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      this.accountService.loggedIn = true;
      this.router.navigate(['/dashboard']);
    }, error => {
      console.log(error);
    });
  }

 }
