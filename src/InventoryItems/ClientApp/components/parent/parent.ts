import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class Coin {
    constructor() { }

    id: string = '';
    country: string = '';
    type: string = '';
    year: string = '';
    condition: string = '';
    description: string = '';
}

@Component
export default class ParentComponent extends Vue {
    dialog: boolean = false;
    items: string[] = ['United States', 'Canada']
    coin_types: string[] = ['Cent', 'Nickel', 'Dime', 'Quarter', 'Half Dollar', 'Small Dollar', 'Large Dollar']
    coin_conditions: string[] = ['Good', 'Very Good', 'Fine', 'Very Fine', 'Extremely Fine', 'About Uncirculated', 'Mint State']
    coin: Coin = new Coin();

    submit(): void {
        this.$validator.validateAll().then((result) => {
            if (!result) {
                alert('error');
                return;
            }
            this.dialog = false;
            fetch('api/Projects/CreateProject', {
                method: 'PUT',
                body: JSON.stringify(this.coin),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        });
    }

    clear(): void {
        this.$validator.reset();
        this.coin = new Coin();
        this.dialog = false;
    }
}