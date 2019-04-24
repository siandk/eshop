<template>
  <div id="app">
    <div id="nav">
      | <router-link to="/">Home</router-link> |
      <router-link to="/shop">Shop</router-link> | 
      <router-link v-show="this.$store.getters.getCartCount > 0" to="/cart">Cart<span class="cart-count">{{this.$store.getters.getCartCount}}</span></router-link>
    </div>
    <router-view class="container"/>
  </div>
</template>
<style lang="scss">
@import "https://stackpath.bootstrapcdn.com/bootstrap/4.1.2/css/bootstrap.min.css";
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
  a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
      color: green;
    }
  }
}
.cart-count {
  background-color: green;
  border-radius: 50%;
  color: white;
  padding: 2px;
  font-size: 12px;
  margin: 3px;
  font-weight: 600;
}
</style>
