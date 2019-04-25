<template>

  <Modal>
    <h2 slot="header">Are you sure you want to delete {{product.name}}?</h2>

    <div slot="content" class="col-12 text-center">
        <button class="btn btn-danger" @click="deleteProduct()">Confirm</button>
        <button class="btn btn-warning" @click="$emit('close')">Close</button>
    </div>
  </Modal>

</template>

<script>
import Modal from './Modal.vue'
import axios from 'axios'

export default {
    props: ['product'],
    components: {
      Modal
    },
    methods: {
        deleteProduct() {
            console.log(this.product.productId)
            axios.delete('https://localhost:44334/api/products/' + this.product.productId.toString())
                .then(response => console.log(response))
                .catch(error => console.log(error))
                .finally(this.$emit('close'))
        }
    }
}
</script>
