<template>
    <div class="product">
        <div class="row">
            <div class="col-12 mb-5 product-title">
                <h2>{{product.name}}</h2>
                <p>{{product.summary}}</p>
            </div>
            <div class="col-7">
                <div class="row">
                    <div class="col-4">
                        <div class="product-info text-left">
                            <h3>Product Info:</h3>
                            <p>Category: {{product.categoryName}}</p>
                            <p>Manufacturer: {{product.manufacturerName}}</p>
                            <p>Price: <strong class="product-price">{{ product.unitPrice }}</strong> kr. /stk</p>
                        </div>
                        <button @click="addToCart()" class="btn btn-primary mt-3">Add to cart</button>
                    </div>
                    <div class="col-8 product-content">
                        <h5>{{product.description}}</h5>
                    </div>
                </div>
            </div>
            <div class="col-5">
                <img class="zoom card-img-top text-center" v-bind:src="product.imageUrl" alt="Card image cap">
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    name: 'product',
    data() {
        return {
            product: {}
        }
    },
    mounted() {
        axios.get('https://localhost:44334/api/products/' + this.$route.params.productId)
                        .then(response => (this.product = response.data))
                        .catch(error => console.log(error))
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

<style lang="scss" scoped>
.product-title {
    border-bottom: 3px solid green;
}
.product-info {
    font-weight: 600;
    padding: 5px;
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
