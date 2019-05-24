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
    mint: string = '';
}

@Component({
    components: {
        CoinDialog: require('../coinDialog/coinDialog.vue.html').default
    }
})
export default class CollectionComponent extends Vue {
    coins: Coin[] = [];

    mounted() {
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
                value: 'id'
            },
            { text: 'Type', value: 'type', align: 'right' },
            { text: 'Year', value: 'year', align: 'right' },
            { text: 'Condition', value: 'condition', align: 'right' },
            { text: 'Mint', value: 'mint', align: 'right' }
        ]
    }
}
