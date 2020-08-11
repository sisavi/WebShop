import { autoinject } from 'aurelia-framework';
import { AppState } from "state/app-state";

interface ILangStrings {
    name: string;
    description: string;
    language: string;
    login: string;
    logout: string;
    register: string;
    categories: string;
    order: string;
    addToBasket: string;
    homePage: string;
    products: string,
    Basket: string;
    privacy: string;
    hello: string;
    image: string;
    price: string;
    quantity: string;
    total: string;
    remove: string;
    continueShopping: string;
    checkout: string;
    phone: string;
    backToOrders: string;
    createNew: string;
    edit: string;
    save: string;
    delete: string;
}

interface ILangResources {
    'en-GB': ILangStrings;
    'et-EE': ILangStrings;
    [propName: string]: ILangStrings;
}

const LangResources: ILangResources = {
    'en-GB': {
        name: 'Name',
        description: 'Description',
        language: 'Language',
        login: 'Login',
        logout: 'Logout',
        register: 'Register',
        categories: 'Categories',
        order: 'Order by',
        homePage: 'Home',
        products: 'Products',
        privacy: 'Privacy',
        hello: 'Hello',
        image: 'Image',
        price: 'Price',
        quantity: 'Quantity',
        total: 'Total cost',
        remove: 'Remove?',
        continueShopping: 'Continue shopping',
        checkout: 'CHECKOUT',
        phone: 'Phone',
        backToOrders: 'Back to orders',
        createNew: 'Create new',
        addToBasket: 'Add to Basket',
        Basket: 'Basket',
        edit: 'Edit',
        save: 'Save',
        delete: 'Delete',
    },
    'et-EE': {
        addToBasket: 'Lisa Ostukorvi',
        Basket: 'Ostukorv',
        name: 'Nimi',
        description: 'Kirjeldus',
        language: 'Keel',
        login: 'Logi sisse',
        logout: 'Logi välja',
        register: 'Registreeri',
        categories: 'Kategooriad',
        order: 'Järjesta',
        homePage: 'Avaleht',
        products: 'Tooted',
        privacy: 'Privaatsus',
        hello: 'Tere',
        image: 'Pilt',
        price: 'Hind',
        quantity: 'Kogus',
        total: 'Kokku',
        remove: 'Eemalda?',
        continueShopping: 'Jätka poodlemist',
        checkout: 'VORMISTA OST',
        phone: 'Telefon',
        backToOrders: 'Tagasi tellimuste juurde',
        createNew: 'Loo uus',
        edit: 'Muuda',
        save: 'Salvesta',
        delete: 'Kustuta',
    }
}

@autoinject
export default class LangStrings {
    /*
    selected: ILangStrings;
    constructor(private appState: AppState) {
        this.selected = LangResources[this.appState.culture?.code || 'en-GB'];
    }

    setLang(lang = 'en-GB'): void {
        this.selected = LangResources[lang];
    }
    */
}


