import Vue from 'vue';
import App from './App.vue';
import router from './routes';
import './assets/styles/main.css';
import Vuex from 'vuex';
import Vuei18n from 'vue-i18n';
import tr from '@/lang/tr';
import en from '@/lang/en';

Vue.use(Vuei18n);

// Language settings
const locale = 'tr';

const messages = {
	tr: tr,
	en: en
};

const i18n = new Vuei18n({
	locale,
	messages
});
// End language settings

Vue.use(Vuex)

Vue.config.productionTip = false;

new Vue({
	render: h => h(App),
	router,
	i18n
}).$mount('#app');
