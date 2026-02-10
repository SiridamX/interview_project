import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-user-form-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-form-modal.component.html',
  styleUrls: ['./user-form-modal.component.scss']
})
export class UserFormModalComponent {

  @Input() visible = false;
  @Input() mode: 'create' | 'view' | 'list' = 'list';
  @Input() user?: User;

  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<User>();

  model: User = {
    id: 0,
    name: '',
    firstName: '',
    lastName: '',
    address: '',
    birthOfDate: '',
    age: 0
  };

  get age(): number {
    if (!this.model.birthOfDate) return 0;

    const today = new Date();
    const birth = new Date(this.model.birthOfDate);

    let age = today.getFullYear() - birth.getFullYear();

    const birthdayPassed =
      today.getMonth() > birth.getMonth() ||
      (today.getMonth() === birth.getMonth() &&
        today.getDate() >= birth.getDate());

    if (!birthdayPassed) {
      age--;
    }

    return Math.max(age, 0);
  }


  ngOnChanges() {
    if (this.user) {
      this.model = { ...this.user };
    }
  }

  onSave() {
    this.save.emit(this.model);
    this.close.emit()
  }

  onClose() {
    this.close.emit();
  }

  get readonly() {
    return this.mode === 'view';
  }
}
