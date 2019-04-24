import Vue from 'vue'
import VeeValidate from 'vee-validate'
import App from './App.vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false
Vue.use(VeeValidate)

new Vue({
  router,
  store,
  created() {
    this.$store.dispatch('loadCategories')
  },
  render: h => h(App)
}).$mount('#app')
