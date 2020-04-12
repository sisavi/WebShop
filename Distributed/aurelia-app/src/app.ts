import { AppState } from './state/app-state';
import { autoinject, PLATFORM } from 'aurelia-framework';
import { RouterConfiguration, Router } from 'aurelia-router';

@autoinject
export class App {
  router?: Router;
  constructor(private appState: AppState) {

  }

  configureRouter(config: RouterConfiguration, router: Router): void {
      this.router = router;

      config.title = "shop";

      config.map([
          { route: ['', 'home', 'home/index'], name: 'home', moduleId: PLATFORM.moduleName('views/home/index'), nav: true, title: 'Home' },

          { route: ['user/login'], name: 'user-login', moduleId: PLATFORM.moduleName('views/user/login'), nav: false, title: 'Login' },
          { route: ['user/register'], name: 'user-register', moduleId: PLATFORM.moduleName('views/user/register'), nav: false, title: 'Register' },

          { route: ['accounts', 'accounts/index'], name: 'accounts-index', moduleId: PLATFORM.moduleName('views/accounts/index'), nav: true, title: 'accounts' },
          { route: ['accounts/details/:id?'], name: 'accounts-details', moduleId: PLATFORM.moduleName('views/accounts/details'), nav: false, title: 'accounts Details' },
          { route: ['accounts/edit/:id?'], name: 'accounts-edit', moduleId: PLATFORM.moduleName('views/accounts/edit'), nav: false, title: 'accounts Edit' },
          { route: ['accounts/delete/:id?'], name: 'accounts-delete', moduleId: PLATFORM.moduleName('views/accounts/delete'), nav: false, title: 'accounts Delete' },
          { route: ['accounts/create'], name: 'accounts-create', moduleId: PLATFORM.moduleName('views/accounts/create'), nav: false, title: 'accounts Create' },

          { route: ['warehouses', 'warehouses/index'], name: 'warehouses-index', moduleId: PLATFORM.moduleName('views/warehouses/index'), nav: true, title: 'warehouses' },
          { route: ['warehouses/details/:id?'], name: 'warehouses-details', moduleId: PLATFORM.moduleName('views/warehouses/details'), nav: false, title: 'warehouses Details' },
          { route: ['warehouses/edit/:id?'], name: 'warehouses-edit', moduleId: PLATFORM.moduleName('views/warehouses/edit'), nav: false, title: 'warehouses Edit' },
          { route: ['warehouses/delete/:id?'], name: 'warehouses-delete', moduleId: PLATFORM.moduleName('views/warehouses/delete'), nav: false, title: 'warehouses Delete' },
          { route: ['warehouses/create'], name: 'warehouses-create', moduleId: PLATFORM.moduleName('views/warehouses/create'), nav: false, title: 'warehouses Create' },

          { route: ['campaigns', 'campaigns/index'], name: 'campaigns-index', moduleId: PLATFORM.moduleName('views/campaigns/index'), nav: true, title: 'campaigns' },
          { route: ['campaigns/details/:id?'], name: 'campaigns-details', moduleId: PLATFORM.moduleName('views/campaigns/details'), nav: false, title: 'campaigns Details' },
          { route: ['campaigns/edit/:id?'], name: 'campaigns-edit', moduleId: PLATFORM.moduleName('views/campaigns/edit'), nav: false, title: 'campaigns Edit' },
          { route: ['campaigns/delete/:id?'], name: 'campaigns-delete', moduleId: PLATFORM.moduleName('views/campaigns/delete'), nav: false, title: 'campaigns Delete' },
          { route: ['campaigns/create'], name: 'campaigns-create', moduleId: PLATFORM.moduleName('views/campaigns/create'), nav: false, title: 'campaigns Create' },


          { route: ['categories', 'categories/index'], name: 'categories-index', moduleId: PLATFORM.moduleName('views/categories/index'), nav: true, title: 'categories' },
          { route: ['categories/details/:id?'], name: 'categories-details', moduleId: PLATFORM.moduleName('views/categories/details'), nav: false, title: 'categories Details' },
          { route: ['categories/edit/:id?'], name: 'categories-edit', moduleId: PLATFORM.moduleName('views/categories/edit'), nav: false, title: 'categories Edit' },
          { route: ['categories/delete/:id?'], name: 'categories-delete', moduleId: PLATFORM.moduleName('views/categories/delete'), nav: false, title: 'categories Delete' },
          { route: ['categories/create'], name: 'categories-create', moduleId: PLATFORM.moduleName('views/categories/create'), nav: false, title: 'categories Create' },
      ]
      );

      config.mapUnknownRoutes('views/home/index');
  }

  logoutOnClick(){
      this.appState.jwt = null;
      this.router!.navigateToRoute('user-login');
  }
}
