// import { Injectable } from '@angular/core';
// import { Actions, createEffect, ofType } from '@ngrx/effects';
// import { catchError, map, mergeMap } from 'rxjs/operators';
// import { UserService } from '../services/user.service';
// import * as UserActions from '../state/actions/user.actions';

// @Injectable()
// export class UserEffects {
//   loadUsers$ = createEffect(() =>
//     this.actions$.pipe(
//       ofType(UserActions.loadUsers),
//       mergeMap(() =>
//         this.userService.getAllUsers().pipe(
//           map(users => UserActions.loadUsersSuccess({ users })),
//           catchError(error => of(UserActions.loadUsersFailure({ error })))
//         )
//       )
//     )
//   );

//   constructor(private actions$: Actions, private userService: UserService) {}
// }
