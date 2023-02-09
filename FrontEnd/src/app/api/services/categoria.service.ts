/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { Categoria } from '../models/categoria-view';

@Injectable({
  providedIn: 'root',
})
export class CategoriaService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiCategoriaGet
   */
  static readonly ApiCategoriaGetPath = '/api/Categoria';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiCategoriaGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiCategoriaGet$Plain$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<Categoria>>> {

    const rb = new RequestBuilder(this.rootUrl, CategoriaService.ApiCategoriaGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Categoria>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiCategoriaGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiCategoriaGet$Plain(params?: {
  },
  context?: HttpContext

): Observable<Array<Categoria>> {

    return this.apiCategoriaGet$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<Categoria>>) => r.body as Array<Categoria>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiCategoriaGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiCategoriaGet$Json$Response(params?: {
  },
  context?: HttpContext

): Observable<StrictHttpResponse<Array<Categoria>>> {

    const rb = new RequestBuilder(this.rootUrl, CategoriaService.ApiCategoriaGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Categoria>>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiCategoriaGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiCategoriaGet$Json(params?: {
  },
  context?: HttpContext

): Observable<Array<Categoria>> {

    return this.apiCategoriaGet$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<Array<Categoria>>) => r.body as Array<Categoria>)
    );
  }

}
