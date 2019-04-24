<template>
<div>
    <div v-if="getCartCount <= 0" class="row">
        <div class="col-12">
            <h3>Nothing to checkout</h3>
        </div>
    </div>
    <div v-if="getCartCount > 0">
        <form @submit.prevent="checkout" class="row text-left">
            <div class="col-12"><h3>Delivery Address</h3></div>
            <div class="col-6 mb-4">
                <div class="form-group">
                    <label for="name">Name</label>
                    <input v-validate="'required|alpha_spaces'" name="name" id="name" class="form-control" v-model="customer.name" type="text">
                    <span v-show="errors.has('name')" class="validation-warning">{{errors.first('name')}}</span>
                </div>
                <div class="form-group">
                    <label for="city">City</label>
                    <input v-validate="'alpha_spaces'" name="city" id="city" class="form-control" v-model="customer.city" type="text">
                    <span v-show="errors.has('city')" class="validation-warning">{{errors.first('city')}}</span>
                </div>
                <div class="form-group">
                    <label for="street">Street</label>
                    <input name="street" id="street" class="form-control" v-model="customer.street" type="text">
                </div>
                <div class="form-group">
                    <label for="zip">Zip</label>
                    <input name="zip" id="zip" class="form-control" v-model="customer.zip" type="text">
                </div>
                <div class="form-group">
                    <label for="country">Country</label>
                    <input v-validate="'alpha_spaces'" name="country" id="country" class="form-control" v-model="customer.country" type="text">
                    <span v-show="errors.has('country')" class="validation-warning">{{errors.first('country')}}</span>
                </div>
            </div>
            <div class="col-6 mb-4">
                <div class="form-group">
                    <label for="email">Email</label>
                    <input name="email" v-validate="'required|email'" id="email" class="form-control" v-model="customer.email" type="text">
                    <span v-show="errors.has('email')" class="validation-warning">{{errors.first('email')}}</span>
                </div>
                <div class="form-group">
                    <label for="phone">Phone</label>
                    <input v-validate="'required|numeric'" name="phone" id="phone" class="form-control" v-model="customer.phone" type="text">
                    <span v-show="errors.has('phone')" class="validation-warning">{{errors.first('phone')}}</span>
                </div>
            </div>
            <div class="col-12"><h3>Notes</h3></div>
            <div class="col-12 mb-4">
                <input id="notes" class="form-control" v-model="orderNotes">
            </div>
            <div class="col-12"><h3>Your order</h3></div>
            <ShoppingCart v-bind:editable="false"></ShoppingCart>
            <div class="col-12 text-center">
                <button id="checkout" type="submit" class="btn btn-success">Order now!</button>
            </div>
        </form>
    </div>
</div>
</template>

<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
import ShoppingCart from '@/components/ShoppingCart.vue'
export default {
    components: {
        ShoppingCart
    },
    data() {
        return {
            customerId: 0,
            customer: {
                name: "",
                email: "",
                street: "",
                phone: "",
                zip: "",
                city: "",
                country: ""
            },
            orderNotes: ""
        }
    },
    methods: {
        checkout() {
            this.$validator.validateAll().then((result) => {
                console.log(result)
                if (result) {
                    let checkoutData = {
                        order: {
                            notes: this.orderNotes,
                            orderLines: this.getCart
                        },
                        customer: this.customer
                    }
                    console.log(checkoutData)
                    axios.post('https://localhost:44334/api/orders/checkout', checkoutData, {headers: {'content-type': 'application/json'}})
                        .then(response => console.log(response))
                        .catch(error => console.log(error))
                        .finally(this.$store.dispatch('setCart', []))
                }
            })
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
#checkout {
    width: 60%
}
.validation-warning {
    color: red
}
</style>
