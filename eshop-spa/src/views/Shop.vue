<template>
  <div class="shop">
    <div class="row">
      <CategoryMenu></CategoryMenu>
      <ProductList v-bind:pageSize="8" v-bind:categoryId="categoryId"></ProductList>
    </div>
  </div>
</template>

<script>
import ProductList from '@/components/ProductList.vue'
import CategoryMenu from '@/components/CategoryMenu.vue'

export default {
  name: 'shop',
  data() {
    return {
      categoryId: undefined
    }
  },
  watch: {
    '$route': 'setCategoryId'
  },
  methods: {
    setCategoryId(route) {
      this.categoryId = route.params.categoryId
      console.log(this.categoryId)
    }
  },
  components: {
    ProductList,
    CategoryMenu
  }
}
</script>
