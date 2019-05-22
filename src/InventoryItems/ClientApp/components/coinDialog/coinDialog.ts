import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

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
export default class CoinDialog extends Vue {
    @Prop({
        default: ''
    }) collectionId!: string

    dialog: boolean = false;
    snackbar: boolean = false;
    disableButtons: boolean = false;
    items: string[] = ['United States', 'Canada']
    coin_types: string[] = ['Cent', 'Nickel', 'Dime', 'Quarter', 'Half Dollar', 'Small Dollar', 'Large Dollar']
    coin_conditions: string[] = ['Good', 'Very Good', 'Fine', 'Very Fine', 'Extremely Fine', 'About Uncirculated', 'Mint State']
    coin: Coin = new Coin();
    timeout: number = 5000;

    submit(): void {
        this.$validator.validateAll().then((result) => {
            if (!result) {
                return;
            }
            this.disableButtons = true;
            fetch('api/collections/' + this.collectionId + '/coins/createcoin', {
                method: 'PUT',
                body: JSON.stringify(this.coin),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                this.disableButtons = false;
                this.dialog = false;
                this.snackbar = true;
                this.clear();
            });
        });
    }

    clear(): void {
        this.$validator.reset();
        this.coin = new Coin();
        this.dialog = false;
    }
}