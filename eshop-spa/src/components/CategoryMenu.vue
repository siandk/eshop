<template>
    <div class="col-3">
        <h3>Categories</h3>
        <ul class="list-unstyled components">
            <li>
                <router-link :to="{name: 'shop'}">All Products</router-link>
            </li>
            <li v-for="category in categoryRoot" v-bind:key="category.categoryId">
                <router-link :to="{name: 'shopCategory', params: {categoryId: category.categoryId}}">{{category.name}}</router-link>
                <CategoryLink v-bind:parent="category.categoryId" v-bind:categories="categories"></CategoryLink>
            </li>
        </ul>
    </div>
</template>

<script>
import CategoryLink from './CategoryLink.vue'
export default {
    components: {
        CategoryLink
    },
    computed: {
        categories() {
            return this.$store.getters.getCategories
        },
        categoryRoot() {
            return this.$store.getters.getCategories.filter(cat => cat.parentCategoryId === null)
        }
    }
}
</script>

<style lang="scss" scoped>
h3 {
    color: green;
}
.col-3 {
    border-right: 2px solid green;
    padding-right: 5px;

}
ul {
    text-align: left;
    margin-left: 10px;
}
li {
    font-size: 20px;
    padding: 15px;
}

a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
        color: green;
    }
}
</style>
