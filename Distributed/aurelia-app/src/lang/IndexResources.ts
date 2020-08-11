export interface IIndexResourceStrings {
    admin: string;
    campaign: string;
    products: string;
    name: string;
    description: string;
    language: string;
    login: string;
    logout: string;
    register: string;
    categories: string;
    order: string;
    cancel: string;
    addToBasket: string;
    homePage: string;
    shoppingCart: string;
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
    backToProducts: string;
    createNew: string;
    edit: string;
    save: string;
    delete: string;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword: string;
    createNewAccount: string;
    forgotPassword: string;
    registerAsANew: string;
    activeOrders: string;
    location: string;
    date: string;
    viewOrder: string;
    createProduct: string;
    text: string;
    warehouses: string;
}
export interface IIndexResources {
    'en-GB': IIndexResourceStrings;
    'et-EE': IIndexResourceStrings;

}
export const IndexResources: IIndexResources = {
    'en-GB':{
        warehouses: 'Warehouses',
        admin: 'Users orders',
        campaign:'Campaign',
        products: 'Products',
        name: 'Name',
        description: 'Description',
        language: 'Language',
        login: 'Login',
        logout: 'Logout',
        register: 'Register',
        categories: 'Categories',
        order: 'Order',
        cancel: 'Cancel',
        addToBasket: 'Add To Basket',
        homePage: 'Home Page',
        shoppingCart: 'Basket',
        privacy: 'Privacy',
        hello: 'Hello',
        image: 'Image',
        price: 'Price',
        quantity: 'Quantity',
        total: 'Total',
        remove: 'Remove',
        continueShopping: 'Continue Shopping',
        checkout: 'Checkout',
        phone: 'Phone',
        backToOrders: 'back To Orders',
        backToProducts: 'back To Products',
        createNew: 'Create New',
        edit: 'edit',
        save: 'save',
        delete: 'delete',
        firstName: 'First Name',
        lastName: 'LastName',
        email: 'Email',
        password: 'Password',
        confirmPassword: 'Confirm Password',
        createNewAccount: 'create New Account',
        forgotPassword: 'ForgotPassword',
        registerAsANew: 'Register As A New',
        activeOrders: 'Active Orders',
        location: 'Location',
        date: 'Date',
        viewOrder: 'ViewOrder',
        createProduct: 'Create Product',
        text: 'text',
    },
    'et-EE': {
        warehouses: 'Laod',
        admin: 'Kasutajate Tellimused',
        campaign: 'Kampaania',
        name: 'Nimi',
        description: 'Kirjeldus',
        language: 'Keel',
        login: 'Logi sisse',
        logout: 'Logi välja',
        register: 'Registreeri',
        categories: 'Kategooriad',
        order: 'Järjesta',
        cancel: 'Tühjenda filtrid',
        addToBasket: 'Lisa ostukorvi',
        homePage: 'Avaleht',
        products: 'Tooted',
        shoppingCart: 'Ostukorv',
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
        backToOrders: 'Tagasi tellimuste lehele',
        backToProducts: 'Tagasi toodete lehele',
        createNew: 'Loo uus',

        edit: 'Muuda',
        save: 'Salvesta',
        delete: 'Kustuta',
        firstName: 'Eesnimi',
        lastName: 'Perekonnanimi',
        email: 'Email',
        password: 'Parool',
        confirmPassword: 'Kinnita parool',
        createNewAccount: 'Loo uus kasutaja.',
        forgotPassword: 'Unustasid parooli?',
        registerAsANew: 'Registreeri uus kasutaja',
        activeOrders: 'Aktiivsed tellimused',
        location: 'Asukoht (Omniva)',
        date: 'Kuupäev',
        viewOrder: 'Vaata tellimust',
        createProduct: 'Lisa uus toode',
        text: 'Tekst',
    }
}
