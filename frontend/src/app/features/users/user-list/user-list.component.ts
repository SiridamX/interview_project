import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../../core/services/user';
import { User } from '../../../models/user.model';
import { CreateUser } from '../../../models/create-user.model';
import { UserFormModalComponent } from '../../../shared/components/user-form-modal/user-form-modal.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, UserFormModalComponent],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  users: User[] = [];
  loading = false;

  showModal = false;
  mode: 'create' | 'view' = 'create';
  pageMode: 'list' | 'create' | 'view' = 'list';
  selectedUser?: User;
  // number_mode:number = 0;
  constructor(private userService: UserService,private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  get number_mode(): string {
  switch (this.pageMode) {
    case 'list': return '1';
    case 'create': return '2';
    case 'view': return '3';
    default: return '1';
  }
}

  loadUsers(): void {
    this.loading = true;
    this.userService.getUsers().subscribe({
      next: (data) => {
        this.users = [...data];
        console.log('users:', this.users);
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      }
    });
  }

  openAdd(): void {
    this.mode = 'create';
    this.pageMode = 'create';
    this.selectedUser = undefined;
    this.showModal = true;
  }

  openView(user: User): void {
    this.mode = 'view';
    this.pageMode = 'view';
    this.selectedUser = user;
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
    this.pageMode = 'list';
  }

  saveUser(payload: CreateUser): void {
    if (this.mode === 'create') {
      this.create(payload);
    }
  }

  private create(payload: CreateUser): void {
    this.userService.createUser(payload).subscribe({
      next: (createdUser) => {
        this.users = [...this.users, createdUser];
        this.closeModal();
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('create failed', err);
      }
    });
  }
}
