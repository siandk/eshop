<template>

  <Modal>
    <div slot="header" class="row">
    <div class="col-6 text-left">
      <h3>Edit Product {{product.name}}</h3>
    </div>
    <div class="col-6 text-right">
      <button class="btn btn-danger pull-right" @click="cancel()">Close</button>
    </div>
    </div>
    <form slot="content" @submit.prevent="edit" class="row text-left">
        <div class="col-6 mb-4">
            <div class="form-group">
                <label for="name">Name</label>
                <input v-validate="'required|alpha_spaces'" name="name" id="name" class="form-control" v-model="product.name" type="text">
                <span v-show="errors.has('name')" class="validation-warning">{{errors.first('name')}}</span>
            </div>
            <div class="form-group">
                <label for="summary">Summary</label>
                <input v-validate="'max:40'" name="summary" id="summary" class="form-control" v-model="product.summary" type="text">
                <span v-show="errors.has('summary')" class="validation-warning">{{errors.first('summary')}}</span>
            </div>
            <div class="form-group">
                <label for="description">Description</label>
                <input v-validate="'max:250'" name="description" id="description" class="form-control" v-model="product.description" type="text">
                <span v-show="errors.has('description')" class="validation-warning">{{errors.first('description')}}</span>
            </div>
            <div class="form-group">
                <label for="imageUrl">Image URL</label>
                <input name="imageUrl" id="imageUrl" class="form-control" v-model="product.imageUrl" type="text">
            </div>
        </div>
        <div class="col-6 mb-4">
            <div class="form-group">
                <label for="category">Category</label>
                <select name="category" v-validate="'required'" id="category" class="form-control" v-model="product.categoryId">
                  <option disabled value="">Please select a category</option>
                  <option v-for="category in this.getCategories" v-bind:key="category.categoryId" v-bind:value="category.categoryId">{{ category.name }}</option>
                </select>
                <span v-show="errors.has('category')" class="validation-warning">{{errors.first('category')}}</span>
            </div>
            <div class="form-group">
                <label for="unitPrice">Unit Price</label>
                <input v-validate="'required|numeric'" name="unitPrice" id="unitPrice" class="form-control" v-model="product.unitPrice" type="text">
                <span v-show="errors.has('unitPrice')" class="validation-warning">{{errors.first('unitPrice')}}</span>
            </div>
            <div class="form-group">
                <label for="featured">Featured</label>
                <input name="featured" id="featured" class="form-control" v-model="product.featured" type="checkbox">
            </div>
        </div>
        <div class="col-12 text-center">
            <button id="edit" type="submit" class="btn btn-success">Edit</button>
        </div>
    </form>
  </Modal>

</template>

<script>
import Modal from './Modal.vue'
import axios from 'axios'
import { mapGetters } from 'vuex'

export default {
    components: {
      Modal
    },
    props: ['product'],
    computed: {
        ...mapGetters([
            'getCategories'
        ]),
    },
    mounted() {
        this.cachedProduct = Object.assign({}, this.product)
    },
    methods: {
        edit() {
            this.$validator.validateAll().then((result) => {
                console.log(result)
                if (result) {
                  console.log(this.product)
                    axios.put('https://localhost:44334/api/products', this.product, {headers: {'content-type': 'application/json'}})
                        .then(response => console.log(response))
                        .catch(error => console.log(error))
                        .finally(this.$emit('close'))
                }
            })
        },
        cancel() {
            Object.assign(this.product, this.cachedProduct)
            this.$emit('close')
        }
    }
}
</script>
