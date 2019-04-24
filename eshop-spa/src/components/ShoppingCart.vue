<template>
    <div class="col-12">
        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Total</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="line in cartItems" v-bind:key="line.productId">
                    <td>{{line.productName}}</td>
                    <td>{{line.productUnitPrice}}</td>
                    <td>{{line.quantity}}</td>
                    <td>{{line.productUnitPrice * line.quantity}}</td>
                    <td><button v-if="editable" class="btn btn-danger" @click="removeFromCart(line.productId)">Remove</button></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td><strong>Total</strong></td>
                    <td>{{ cartTotal }}</td>
                    <td><button v-if="editable" class="btn btn-danger" @click="clearCart()">Clear Cart</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    props: {
        editable: {
            type: Boolean,
            required: false,
            default: true
        }
    },
    methods: {
        removeFromCart(productId) {
            this.$store.dispatch('removeFromCart', productId)
        },
        clearCart() {
            this.$store.dispatch('setCart', [])
        }
    },
    computed: {
        cartItems() {
            return this.$store.getters.getCart
        },
        cartTotal() {
            return this.$store.getters.getTotal
        }
    }
}
</script>

<style lang="scss" scoped>

</style>
