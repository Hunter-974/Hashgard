import { OnInit, Input, Component, EventEmitter, Output } from '@angular/core';
import { Comment } from '../../models/comment';
import { BaseAuthService } from 'src/app/services/base-auth-service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() comment: Comment;
  @Output() reply: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

}
