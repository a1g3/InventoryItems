import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class Coin {
    constructor() { }

    id: string = '';
    friendlyId: string = '';
    country: string = '';
    type: string = '';
    year: string = '';
    condition: string = '';
    description: string = '';
    mint: string = '';
}

@Component
export default class CollectionComponent extends Vue {
    coins: Coin[] = [];

    collectionId: string = '';
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
            }).then((response) => {
                response.json().then(json => {
                    if (json.isSuccessStatusCode) {
                        this.disableButtons = false;
                        this.dialog = false;
                        this.snackbar = true;
                        this.clear();
                        this.loadCoinList();
                    } else {
                        this.disableButtons = false;
                        alert('Server Error!');
                    }
                });
            });
        });
    }

    clear() {
        this.$validator.reset();
        this.coin = new Coin();
        this.dialog = false;
    }

    editItem(item: Coin) {
        this.coin = item;
        this.dialog = true;
    }


    mounted() {
        this.collectionId = this.$route.params.id;
        this.loadCoinList();
    };

    loadCoinList() {
        fetch('api/collections/' + this.$route.params.id + '/coins/')
            .then(response => response.json() as Promise<Coin[]>)
            .then(data => {
                this.coins = data;
            });
    }

    get headers() {
        return [
            {
                text: 'Id',
                align: 'left',
                value: 'friendlyId'
            },
            { text: 'Type', value: 'type', align: 'right' },
            { text: 'Year', value: 'year', align: 'right' },
            { text: 'Condition', value: 'condition', align: 'right' },
            { text: 'Mint', value: 'mint', align: 'right' },
            { text: 'Actions', align: 'right' },
        ]
    }
}
