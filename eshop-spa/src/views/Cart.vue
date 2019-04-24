<template>
<div>
    <div v-if="getCartCount <= 0" class="row">
        <div class="col-12">
            <h3>There are no items in your cart</h3>
        </div>
    </div>
    <div v-if="getCartCount > 0" class="row">
        <h3>Your cart</h3>
        <ShoppingCart></ShoppingCart>
        <div class="col-12 text-center">
            <router-link :to="{name: 'checkout'}" class="btn btn-success">Checkout</router-link>
        </div>
    </div>
</div>
</template>

<script>
import { mapGetters } from 'vuex'
import ShoppingCart from '@/components/ShoppingCart.vue'
export default {
    components: {
        ShoppingCart
    },
    data() {
        return {

        }
    },
    computed: {
        ...mapGetters([
            'getCartCount',
            'getCart',
            'getTotal'
        ])
    }
}
</script>

<style lang="scss" scoped>
.btn-success {
    width: 60%
}
</style>
