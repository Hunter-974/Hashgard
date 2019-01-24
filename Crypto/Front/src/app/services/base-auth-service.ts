import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Observable, Subscriber } from "rxjs";

export class BaseAuthService {

  private baseUrl: string;

  protected static token: string = null;
  protected static _userId: number = null;

  public static get userId(): number {
    return BaseAuthService._userId;
  }

  constructor(private http: HttpClient, private path: string) {
    this.baseUrl = `${environment.settings.apiBaseUrl}/${path}`;
  }

  protected get<T>(path: string, success?: (result: T) => void): Observable<T> {
    return new Observable<T>(subscriber => {
      try {
        this.http.get<T>(this.formatPath(path), this.getOptions()).subscribe(
          this.getResultSubscription<T>(subscriber, success),
          this.getErrorSubscription<T>(subscriber)
        );  
      } catch (ex) {
        subscriber.error(ex);
      }
    });
  }

  protected post<T>(path: string, body?: any, before?: (subscriber: Subscriber<T>) => void, success?: (result: T) => void): Observable<T> {
    return new Observable<T>(subscriber => {
      try {
        this.execute(subscriber, before);
        this.http.post<T>(this.formatPath(path), body, this.getOptions()).subscribe(
          this.getResultSubscription<T>(subscriber, success),
          this.getErrorSubscription<T>(subscriber)
        );
      } catch (ex) {
        subscriber.error(ex);
      }
    });
  }

  protected put<T>(path: string, body?: any, before?: (subscriber: Subscriber<T>) => void, success?: (result: T) => void): Observable<T> {
    return new Observable<T>(subscriber => {
      try {
        this.execute(subscriber, before);
        this.http.put<T>(this.formatPath(path), body, this.getOptions()).subscribe(
          this.getResultSubscription<T>(subscriber, success),
          this.getErrorSubscription<T>(subscriber)
        );
      } catch (ex) {
        subscriber.error(ex);
      }
    });
  }

  protected delete<T>(path: string, success?: (result: T) => void): Observable<T> {
    return new Observable<T>(subscriber => {
      try {
        this.http.delete<T>(this.formatPath(path), this.getOptions()).subscribe(
          this.getResultSubscription<T>(subscriber, success),
          this.getErrorSubscription<T>(subscriber)
        );
      } catch (ex) {
        subscriber.error(ex);
      }
    });
  }

  private formatPath(path: string) {
    var formatted = this.baseUrl;
    if (path && path.length) {
      formatted = `${this.baseUrl}/${path}`;
    }
    return formatted;
  }

  private getOptions(): { headers: HttpHeaders } {
    var headers = new HttpHeaders();
    if (BaseAuthService.token) {
      headers = headers.append("Token", BaseAuthService.token);
    }
    return { headers: headers };
  }

  private execute<T>(subscriber: Subscriber<T>, before: (subscriber: Subscriber<T>) => void) {
    if (before) {
      before(subscriber);
    }
  }

  private getResultSubscription<T>(subscriber: Subscriber<T>, success: (result: T) => void): (result: T) => void {
    return (result: T) => {
      if (success) {
        success(result);
      }
      subscriber.next(result);
      subscriber.complete();
    };
  }

  private getErrorSubscription<T>(subscriber: Subscriber<T>): (error: HttpErrorResponse) => void {
    return (error: HttpErrorResponse) => {
      subscriber.error(Error(error.statusText));
    };
  }
}

HttpErrorResponse.prototype.toString = function () {
  return this.statusText;
}
