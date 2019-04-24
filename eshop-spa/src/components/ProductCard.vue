<template>
    <div class="col-3">
        <div class="card">
            <div v-if="editable" class="btn-group" role="group">
                <ProductEdit v-bind:product="product" v-if="showEdit" @close="showEdit = false"/>
                <button class="btn btn-info" @click="showEdit = true">Edit</button>
                <ProductDelete v-bind:product="product" v-if="showDelete" @close="showDelete = false"/>
                <button class="btn btn-danger" @click="showDelete = true">Delete</button>
            </div>
            <router-link :to="{name: 'product', params: {productId: product.productId}}">
                <img class="zoom card-img-top text-center" v-bind:src="product.imageUrl" alt="Card image cap">
            </router-link>
            <div class="card-body">
                <h4 class="card-title">{{ product.name }}</h4>
                <p class="card-text">{{ product.summary }}</p>
                <p><strong class="product-price">{{ product.unitPrice }}</strong> kr. /stk</p>
                <button @click="addToCart()" class="btn btn-primary">Add to cart</button>
            </div>
        </div>
    </div>
</template>

<script>
import ProductEdit from './ProductEdit.vue'
import ProductDelete from './ProductDelete.vue'
import {mapActions} from 'vuex'
export default {
    data() {
        return {
            showEdit: false,
            showDelete: false
        }
    },
    props: ['product', 'editable'],
    components: {
        ProductEdit,
        ProductDelete
    },
    methods: {
        addToCart() {
            let orderLine = {
                productId: this.product.productId,
                productName: this.product.name,
                productUnitPrice: this.product.unitPrice,
                quantity: 1
            }
            this.$store.dispatch('addToCart', orderLine)
        }
    }
}
</script>

<style scoped>
.card {
    margin-top: 25px;
}
.product-price {
    color: red;
    font-size: 22px;
}
.zoom {
    position: relative;
    z-index: 0;
    transition: transform .2s; /* Animation */
}

.zoom:hover {
    transform: scale(1.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
    z-index: 50;
}
</style>
