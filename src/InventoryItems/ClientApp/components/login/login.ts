import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class User {
    email: string = '';
    password: string = '';
}

@Component({
    components: {
        CollectionDialog: require('../login/login.vue.html').default
    }
})
export default class LoginComponent extends Vue {
    user: User = new User();
    token: string = '';

    submitLogin() {
        fetch('api/Accounts', {
            method: 'POST',
            body: JSON.stringify(this.user),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response => response.json() as Promise<string>)
            .then(data => {
                this.token = data;
            });
    }
}