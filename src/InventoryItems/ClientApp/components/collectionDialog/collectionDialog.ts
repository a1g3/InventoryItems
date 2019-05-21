import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class Collection {
    constructor() { }

    name: string = '';
}

@Component
export default class CollectionDialog extends Vue {
    dialog: boolean = false;
    snackbar: boolean = false;
    disableButtons: boolean = false;
    collection: Collection = new Collection();
    timeout: Number = 5000;

    submit(): void {
        this.$validator.validateAll().then((result) => {
            if (!result) {
                return;
            }
            this.disableButtons = true;
            fetch('api/Collections/Create', {
                method: 'PUT',
                body: JSON.stringify(this.collection),
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
        this.dialog = false;
        this.collection = new Collection();
    }
}