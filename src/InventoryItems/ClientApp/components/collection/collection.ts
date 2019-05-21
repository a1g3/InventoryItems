import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        CoinDialog: require('../coinDialog/coinDialog.vue.html').default
    }
})
export default class CollectionComponent extends Vue {
}
