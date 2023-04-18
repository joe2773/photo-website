import { Component, OnInit } from '@angular/core';
import { User } from '../../model/app.model';
import { UserService } from 'src/app/services/user.service';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  public user$ : Observable<User> | null = null;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUserById(3);
  }

  getUserById(id : number) : void {
    console.log('fetching');
    this.user$ = this.userService.getUserById(id);
  }
}
