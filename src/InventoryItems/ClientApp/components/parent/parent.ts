import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class ParentComponent extends Vue {
    dialog: boolean = false;
}