import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../enums/Status';

@Pipe({
  name: 'orderStatusColor',
  pure: false
})
export class OrderStatusPipe implements PipeTransform {

  transform(value: Status, ...args: unknown[]): string {
    switch (value) {
      case Status.Approved:
        return 'background-color:green;';
      case Status.Rejected:
        return 'background-color:red;';
      case Status.NeedApprove:
        return 'background-color:rgb(0, 8, 255);';
      case Status.NeedReject:
        return 'background-color:rgb(109, 26, 134);';
      case Status.RejectedDeclined:
        return 'background-color:rgb(0, 0, 0);';
      default:
        return '';
    }
  }

}
