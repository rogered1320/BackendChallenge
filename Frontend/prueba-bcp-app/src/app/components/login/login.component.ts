import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { UserInfo } from 'src/app/interfaces/user-info';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  returnUrl: string;

  constructor(private userService: AuthService, private route: ActivatedRoute, private router: Router) {
    if (this.userService.currentBearerTokenValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      Email: new FormControl('', [Validators.required]),
      Password: new FormControl('', Validators.required)
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.userService.login(this.form.value as UserInfo)
      .pipe(first())
      .subscribe(response => {
        return this.router.navigate([this.returnUrl]);
      }, _error => {
        alert('Los datos ingresados no son válidos');
        this.form.reset();
      })
  }

}
