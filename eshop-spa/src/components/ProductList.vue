<template>
    <div class="col-9">
        <div class="row">
            <ProductCreate v-if="showCreate" @close="showCreate = false"/>
            <ProductSearch v-if="this.searchDisable === false" v-on:searchProducts="filterChange({'name': $event})" v-on:orderProducts="filterChange({'orderBy': $event})"></ProductSearch>
            <div v-if="this.searchDisable === false" class="col-12 text-left mt-3"><button class="btn btn-success" @click="showCreate = true">New Product</button></div>
            <ProductCard v-for="product in products.items"
                        v-bind:key="product.productId"
                        v-bind:product="product"
                        v-bind:editable="!searchDisable"

            />
            <div class="col-12 text-center page-nav">
                <button v-bind:disabled="!products.hasPreviousPage" class="btn btn-primary m-2" @click="pageChange(params.pageNum - 1)">
                    Previous
                </button>
                <button v-bind:disabled="params.pageNum === num" class="btn btn-primary m-2" v-for="num in products.totalPages" v-bind:key="num" @click="pageChange(num)">{{ num }}</button>
                <button v-bind:disabled="!products.hasNextPage" class="btn btn-primary m-2" @click="pageChange(params.pageNum + 1)">
                    Next
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import ProductCard from './ProductCard.vue'
import ProductSearch from './ProductSearch.vue'
import ProductCreate from './ProductCreate.vue'
import axios from 'axios'

export default {
    components: {
        ProductCard,
        ProductSearch,
        ProductCreate
    },

    data() {
        return {
            products: [],
            params: {},
            showCreate: false
        }
    },
    props: {
        featured: {
            type: Boolean,
            required: false,
            default: false
        },
        searchDisable: {
            type: Boolean,
            required: false,
            default: false
        },
        pageSize: {
            type: Number,
            required: false,
            default: 4
        },
        categoryId: {
            type: Number,
            required: false,
            default: undefined
        }
    },
    watch: {
        categoryId: 'categoryChange'
    },
    mounted() {
        // Initialize filtering parameters
        this.params['name'] = ""
        this.params['orderBy'] = "priceAsc"
        this.params['pageNum'] = 1

        // Props passed down from parent
        this.params['categoryId'] = this.categoryId
        this.params['featured'] = this.featured
        this.params['pageSize'] = this.pageSize

        this.fetchProducts()
    },
    methods: {
        categoryChange() {
            // Clear search term and page index
            this.params['name'] = ""
            this.params['pageNum'] = 1

            this.params['categoryId'] = this.categoryId
            this.fetchProducts()
        },
        pageChange(num) {
            this.params['pageNum'] = num
            this.fetchProducts()
        },
        filterChange(change) {
            // Reset pageindex when filtering terms change
            this.params['pageNum'] = 1
            this.params = Object.assign(this.params, change)
            this.fetchProducts()
        },
        fetchProducts() {
            axios.get('https://localhost:44334/api/products', {params: this.params})
                 .then(response => (this.products = response.data))
                 .catch(error => console.log(error))
        }
    },
}
</script>

<style scoped>
.page-nav {
    margin-top: 20px;
}
</style>
