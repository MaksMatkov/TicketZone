import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../enums/Status';

@Pipe({
  name: 'orderStatus',
  pure: false
})
export class OrderStatusPipe implements PipeTransform {

  transform(value: Status, ...args: unknown[]): string {
    switch (value) {
      case Status.Approved:
        return 'Approved';
      case Status.Rejected:
        return 'Rejected';
      case Status.NeedApprove:
        return 'Need Approve';
      case Status.NeedReject:
        return 'Need Reject';
      case Status.RejectedDeclined:
        return 'Rejected Declined';
      default:
        return '';
    }
  }

}
