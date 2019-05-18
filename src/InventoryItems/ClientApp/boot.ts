import './css/site.css';
import '../node_modules/vuetify/dist/vuetify.min.css';
import '../node_modules/vuetify/dist/vuetify.min.js';
import 'bootstrap';
import Vue from 'vue';
import Vuetify from 'vuetify';
import VueRouter from 'vue-router';
Vue.use(VueRouter);
Vue.use(Vuetify);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html').default },
    { path: '/counter', component: require('./components/counter/counter.vue.html').default },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html').default },
    { name: 'project', path: '/project/:id', component: require('./components/project/project.vue.html').default }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html').default)
});
