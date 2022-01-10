import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  loginBool: boolean = false;
  signUpBool: boolean = false;

  email: string = "";
  password: string = "";

  constructor() { }

  ngOnInit(): void {
  }
  loginBoolean(): void{
    this.loginBool = true;
  }
  signUpBoolean(): void{
    this.signUpBool = true;
  }

  login(): void{

  }
  signUp(): void{
    
  }
}
