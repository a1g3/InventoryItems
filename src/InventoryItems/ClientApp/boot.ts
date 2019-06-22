import './css/site.css';
import '../node_modules/vuetify/dist/vuetify.min.css';
import '../node_modules/vuetify/dist/vuetify.min.js';
import { ApplicationPaths } from './authorization/api-authorization.constants';
import 'bootstrap';
import Vue from 'vue';
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';
import axios from 'axios';

Vue.prototype.$http = axios;
Vue.use(VueRouter);
Vue.use(VeeValidate);
Vue.use(Vuetify);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html').default },
    { name: 'collection', path: '/collection/:id', component: require('./components/collection/collection.vue.html').default },
    { path: ApplicationPaths.Register, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.Profile, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.Login, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.LoginFailed, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.LoginCallback, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.LogOut, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.LoggedOut, component: require('./components/login/login.vue.html').default },
    { path: ApplicationPaths.LogOutCallback, component: require('./components/login/login.vue.html').default }
];

axios.interceptors.request.use(function (config) {
    // Do something before request is sent
    config.headers = { 'Test': 'TEST' };
    return config;
}, function (error) {
    // Do something with request error
    return Promise.reject(error);
});

const router = new VueRouter({ mode: 'history', routes: routes });
router.beforeEach((to, from, next) => {
});

new Vue({
    el: '#app-root',
    router: router,
    render: h => h(require('./components/app/app.vue.html').default)
});

/*
 * 
 * 
 *     if (!!token && this.isSameOriginUrl(req)) {
*       req = req.clone({
*         setHeaders: {
*           Authorization: `Bearer ${token}`
*         }
*       });
*     }
* 
*     return next.handle(req);
*   }
* 
*   private isSameOriginUrl(req: any) {
*     // It's an absolute url with the same origin.
*     if (req.url.startsWith(`${window.location.origin}/`)) {
*       return true;
*     }
* 
*     // It's a protocol relative url with the same origin.
*     // For example: //www.example.com/api/Products
*     if (req.url.startsWith(`//${window.location.host}/`)) {
*       return true;
*     }
* 
*     // It's a relative url like /api/Products
*     if (/^\/[^\/]..test(req.url)) {
*     return true;
* }
* 
* // It's an absolute or protocol relative url that
* // doesn't have the same origin.
* return false;
*   }*/