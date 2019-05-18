import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Projects {
    name: string;
    id: string;
}

@Component({
    components: {
        ParentComponent: require('../parent/parent.vue.html').default
    }
})
export default class FetchDataComponent extends Vue {
    projects: Projects[] = [];

    mounted() {
        fetch('api/Projects/GetProjectList')
            .then(response => response.json() as Promise<Projects[]>)
            .then(data => {
                this.projects = data;
            });
    };

    openCreateProjectDialog() {
        alert("Create project?");
    }
}
