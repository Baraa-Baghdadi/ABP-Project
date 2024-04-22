import { ConfigStateService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent implements OnInit {
  constructor(private config: ConfigStateService) {}
  ngOnInit(): void {
    const currentUser = this.config.getOne("currentUser");
    localStorage.setItem('currentUser',JSON.stringify(currentUser));
  }
}

