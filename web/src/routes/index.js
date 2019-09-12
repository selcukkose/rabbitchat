import Vue from 'vue';
import Router from 'vue-router';

// #region Components
import MasterPage from '@/components/MasterPage';

Vue.use(Router);

var router = new Router({
	mode: 'history',
	routes: [{
		path: '/',
		name: 'MasterPage',
		component: MasterPage,
	}]
});

export default router;
