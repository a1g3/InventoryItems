import './css/site.css';
import '../node_modules/vuetify/dist/vuetify.min.css';
import '../node_modules/vuetify/dist/vuetify.min.js';
import 'bootstrap';
import Vue from 'vue';
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';

Vue.use(VueRouter);
Vue.use(VeeValidate);
Vue.use(Vuetify);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html').default },
    { name: 'collection', path: '/collection/:id', component: require('./components/collection/collection.vue.html').default }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html').default)
});
