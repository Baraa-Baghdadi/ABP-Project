import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'FirstProjet',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44322/',
    redirectUri: baseUrl,
    clientId: 'FirstProjet_App',
    responseType: 'code',
    scope: 'offline_access FirstProjet',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44322',
      rootNamespace: 'Acme.FirstProjet',
    },
  },
} as Environment;
