import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    inCart: [], // orderLine object
    categories: [] // List of all available categories
  },
  getters: {
    getCart: state => {
      return state.inCart
    },
    getTotal: state => {
      return state.inCart.reduce((sum, line) => sum + (line.quantity * line.productUnitPrice), 0)
    },
    getCartCount: state => {
      return state.inCart.reduce((sum, line) => sum + line.quantity, 0)
    },
    getCategories: state => {
      return state.categories
    }
  },
  mutations: {
    pushToCart: (state, item) => {
      state.inCart.push(item)
    },
    increaseCartQty: (state, item) => {
      const cartItem = state.inCart.find(line => line.productId === item.productId)
      cartItem.quantity++
    },
    setCart: (state, items) => {
      state.inCart = items
    },
    setCategories: (state, items) => {
      state.categories = items
    }
  },
  actions: {
    loadCategories ({commit}) {
      axios.get('https://localhost:44334/api/categories')
      .then(response => (commit('setCategories', response.data)))
      .catch(error => console.log(error))
    },
    setCart ({commit}, items) {
      commit('setCart', items)
    },
    addToCart ({commit, state}, item) {
      let cartItem = state.inCart.find(line => line.productId === item.productId)
      if (cartItem === undefined) {
        commit('pushToCart', item)
      } else {
        commit('increaseCartQty', item)
      }
    },
    removeFromCart({commit, state}, productId) {
      let cart = state.inCart.filter(line => line.productId !== productId)
      commit('setCart', cart)
    }
  }
})
