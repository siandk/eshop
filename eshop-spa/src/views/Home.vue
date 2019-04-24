<template>
  <div class="home">
    <div class="row">
      <ProductList v-bind:class="'col-12'" v-bind:searchDisable="true" v-bind:featured="true"></ProductList>
    </div>
  </div>
</template>

<script>
import ProductList from '@/components/ProductList.vue'

export default {
  name: 'home',
  components: {
    ProductList
  }
}
</script>
