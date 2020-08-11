import {AppState} from './state/app-state';
import {autoinject, PLATFORM, LogManager, View} from 'aurelia-framework';
import {RouterConfiguration, Router} from 'aurelia-router';
import 'bootstrap';
import * as environment from '../config/environment.json';
import {IState} from "./state/State";
import {ICulture} from "./domain/ICulture";
import {CultureService} from "./service/culture-service";
import {connectTo, Store} from "aurelia-store";
import {LayoutResources} from 'lang/LayoutResources';
import {HttpClient} from "aurelia-fetch-client";
export const log = LogManager.getLogger('app.App');
import { EventAggregator, Subscription } from 'aurelia-event-aggregator';
import {IndexResources} from "./lang/IndexResources";

@connectTo()
@autoinject
export class App {
    router?: Router;
    private subscriptions: Subscription[] = [];

    private langResources = LayoutResources;
    private indexResources = IndexResources;
    public state!: IState;
    private userFirstName = this.appState.userFirstName;

    constructor(private appState: AppState,private httpClient: HttpClient, private store: Store<IState>, private cultureService: CultureService) {
        this.httpClient.configure(config => {
            config
                .withBaseUrl(environment.backendUrl)
                .withDefaults({
                    credentials: 'same-origin',
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json',
                        'X-Requested-With': 'Fetch'
                    }
                })
                .withInterceptor({
                    request(request) {
                        console.log(`Requesting ${request.method} ${request.url}`);
                        return request;
                    },
                    response(response) {
                        console.log(`Received ${response.status} ${response.url}`);
                        return response;
                    }
                });
        });

        this.store.registerAction('stateUpdateCultures', this.stateUpdateCultures);
        this.store.registerAction('stateUpdateSelectedCulture', this.stateUpdateSelectedCulture);


    }
    created(owningView: View, myView: View): void {
        log.debug("created");

    }

    bind(bindingContext: Record<string, any>, overrideContext: Record<string, any>): void {
        log.debug("bind");
    }

    async attached(): Promise<void> {
        log.debug("attached");

        // get the languages from backend
        const result = await this.cultureService.getAll();
        if (result.statusCode >= 200 && result.statusCode < 300) {
            log.debug('data', result.data);
            if (result.data) {
                this.store.dispatch(this.stateUpdateCultures, result.data);
            }
        }


    }

    detached(): void {
        log.debug("detached");
        this.subscriptions.forEach(subscription => {
            subscription.dispose();
        });
        this.subscriptions = [];
    }

    setCulture(culture: ICulture): void {
        this.store.dispatch(this.stateUpdateSelectedCulture, culture);
    }

    stateUpdateCultures(state: IState, cultures: ICulture[]): IState {
        const newState = Object.assign({}, state);
        newState.cultures = cultures;
        return newState;
    }

    stateUpdateSelectedCulture(state: IState, culture: ICulture): IState {
        const newState = Object.assign({}, state);
        newState.selectedCulture = culture;
        return newState;
    }


    configureRouter(config: RouterConfiguration, router: Router): void {
        this.router = router;

        config.title = "shop";

        config.map([
                {
                    route: ['', 'Home', 'home/index'],
                    name: 'Home',
                    moduleId: PLATFORM.moduleName('views/home/index'),
                    nav: true,
                    title: 'Home'
                },
                {
                    route: ['AdminViews/index'],
                    name: 'adminviews-index',
                    moduleId: PLATFORM.moduleName('views/AdminViews/index'),
                    nav: false,
                    title: 'Admin View'
                },
                {
                    route: ['AdminViews/details/:id?'],
                    name: 'adminviews-details',
                    moduleId: PLATFORM.moduleName('views/AdminViews/details'),
                    nav: false,
                    title: 'admin Details'
                },


                {
                    route: ['account/login'],
                    name: 'account-login',
                    moduleId: PLATFORM.moduleName('views/account/login'),
                    nav: false,
                    title: 'Login'
                },
                {
                    route: ['account/register'],
                    name: 'account-register',
                    moduleId: PLATFORM.moduleName('views/account/register'),
                    nav: false,
                    title: 'Register'
                },
                {
                    route: ['account/login'],
                    name: 'account-login',
                    moduleId: PLATFORM.moduleName('views/account/login'),
                    nav: false,
                    title: 'Login'
                },
                {
                    route: ['account/register'],
                    name: 'account-register',
                    moduleId: PLATFORM.moduleName('views/account/register'),
                    nav: false,
                    title: 'Register'
                },
                {
                    route: ['account/account'],
                    name: 'account-index',
                    moduleId: PLATFORM.moduleName('views/account/account'),
                    nav: false,
                    title: 'Your Account'
                },

                {
                    route: ['warehouses', 'warehouses/index'],
                    name: 'warehouses-index',
                    moduleId: PLATFORM.moduleName('views/warehouses/index'),
                    nav: true,
                    title: 'warehouses'
                },
                {
                    route: ['warehouses/details/:id?'],
                    name: 'warehouses-details',
                    moduleId: PLATFORM.moduleName('views/warehouses/details'),
                    nav: false,
                    title: 'warehouses Details'
                },
                {
                    route: ['warehouses/edit/:id?'],
                    name: 'warehouses-edit',
                    moduleId: PLATFORM.moduleName('views/warehouses/edit'),
                    nav: false,
                    title: 'warehouses Edit'
                },
                {
                    route: ['warehouses/delete/:id?'],
                    name: 'warehouses-delete',
                    moduleId: PLATFORM.moduleName('views/warehouses/delete'),
                    nav: false,
                    title: 'warehouses Delete'
                },
                {
                    route: ['warehouses/create'],
                    name: 'warehouses-create',
                    moduleId: PLATFORM.moduleName('views/warehouses/create'),
                    nav: false,
                    title: 'warehouses Create'
                },
                {
                    route: ['productInWarehouses', 'productInWarehouses/index'],
                    name: 'productInWarehouses-index',
                    moduleId: PLATFORM.moduleName('views/productInWarehouses/index'),
                    nav: true,
                    title: 'productInWarehouses'
                },
                {
                    route: ['productInWarehouses/details/:id?'],
                    name: 'productInWarehouses-details',
                    moduleId: PLATFORM.moduleName('views/productInWarehouses/details'),
                    nav: false,
                    title: 'warehouses Details'
                },
                {
                    route: ['productInWarehouses/edit/:id?'],
                    name: 'productInWarehouses-edit',
                    moduleId: PLATFORM.moduleName('views/productInWarehouses/edit'),
                    nav: false,
                    title: 'productInWarehouses Edit'
                },
                {
                    route: ['productInWarehouses/delete/:id?'],
                    name: 'productInWarehouses-delete',
                    moduleId: PLATFORM.moduleName('views/productInWarehouses/delete'),
                    nav: false,
                    title: 'productInWarehouses Delete'
                },
                {
                    route: ['productInWarehouses/create'],
                    name: 'productInWarehouses-create',
                    moduleId: PLATFORM.moduleName('views/productInWarehouses/create'),
                    nav: false,
                    title: 'productInWarehouses Create'
                },

                {
                    route: ['campaigns', 'campaigns/index'],
                    name: 'campaigns-index',
                    moduleId: PLATFORM.moduleName('views/campaigns/index'),
                    nav: true,
                    title: 'campaigns'
                },
                {
                    route: ['campaigns/details/:id?'],
                    name: 'campaigns-details',
                    moduleId: PLATFORM.moduleName('views/campaigns/details'),
                    nav: false,
                    title: 'campaigns Details'
                },
                {
                    route: ['campaigns/edit/:id?'],
                    name: 'campaigns-edit',
                    moduleId: PLATFORM.moduleName('views/campaigns/edit'),
                    nav: false,
                    title: 'campaigns Edit'
                },
                {
                    route: ['campaigns/delete/:id?'],
                    name: 'campaigns-delete',
                    moduleId: PLATFORM.moduleName('views/campaigns/delete'),
                    nav: false,
                    title: 'campaigns Delete'
                },
                {
                    route: ['campaigns/create'],
                    name: 'campaigns-create',
                    moduleId: PLATFORM.moduleName('views/campaigns/create'),
                    nav: false,
                    title: 'campaigns Create'
                },


                {
                    route: ['categories', 'categories/index'],
                    name: 'categories-index',
                    moduleId: PLATFORM.moduleName('views/categories/index'),
                    nav: true,
                    title: 'categories'
                },
                {
                    route: ['categories/details/:id?'],
                    name: 'categories-details',
                    moduleId: PLATFORM.moduleName('views/categories/details'),
                    nav: false,
                    title: 'categories Details'
                },
                {
                    route: ['categories/edit/:id?'],
                    name: 'categories-edit',
                    moduleId: PLATFORM.moduleName('views/categories/edit'),
                    nav: false,
                    title: 'categories Edit'
                },
                {
                    route: ['categories/delete/:id?'],
                    name: 'categories-delete',
                    moduleId: PLATFORM.moduleName('views/categories/delete'),
                    nav: false,
                    title: 'categories Delete'
                },
                {
                    route: ['categories/create'],
                    name: 'categories-create',
                    moduleId: PLATFORM.moduleName('views/categories/create'),
                    nav: false,
                    title: 'categories Create'
                },

                {
                    route: ['products', 'products/index'],
                    name: 'products-index',
                    moduleId: PLATFORM.moduleName('views/products/index'),
                    nav: true,
                    title: 'products'
                },
                {
                    route: ['orders', 'orders/index'],
                    name: 'orders-index',
                    moduleId: PLATFORM.moduleName('views/orders/index'),
                    nav: true,
                    title: 'orders'
                },
                {
                    route: ['products/details/:id?'],
                    name: 'products-details',
                    moduleId: PLATFORM.moduleName('views/products/details'),
                    nav: false,
                    title: 'products Details'
                },
                {
                    route: ['products/edit/:id?'],
                    name: 'products-edit',
                    moduleId: PLATFORM.moduleName('views/products/edit'),
                    nav: false,
                    title: 'products Edit'
                },
                {
                    route: ['products/delete/:id?'],
                    name: 'products-delete',
                    moduleId: PLATFORM.moduleName('views/products/delete'),
                    nav: false,
                    title: 'products Delete'
                },
                {
                    route: ['products/create'],
                    name: 'products-create',
                    moduleId: PLATFORM.moduleName('views/products/create'),
                    nav: false,
                    title: 'products Create'
                },

                {
                    route: ['productsInBasket', 'productsInBasket/index'],
                    name: 'productsInBasket',
                    moduleId: PLATFORM.moduleName('views/productsInBasket/index'),
                    nav: true,
                    title: 'Cart'
                },
            ]
        );

        config.mapUnknownRoutes('views/home/index');
    }

    logoutOnClick() {
        this.appState.jwt = null;
        this.router!.navigateToRoute('account-login');
    }

    openCartOnClick() {
        this.router!.navigateToRoute('productsInBasket');
    }
}
