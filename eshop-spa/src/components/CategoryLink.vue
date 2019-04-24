<template>
    <ul class="list-unstyled components">
        <li v-for="category in childCategories" v-bind:key="category.categoryId">
            <router-link :to="{name: 'shopCategory', params: {categoryId: category.categoryId}}">{{category.name}}</router-link>
            <CategoryLink v-bind:parent="category.categoryId" v-bind:categories="categories"></CategoryLink>
        </li>
    </ul>
</template>

<script>
export default {
    name: 'CategoryLink',
    props: ['categories', 'parent'],
    computed: {
        childCategories() {
            return this.categories.filter(cat => cat.parentCategoryId === this.parent)
        }
    }
}
</script>
<style lang="scss" scoped>
ul {
    margin-left: 10px;
}

a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
        color: green;
    }
}
</style>
