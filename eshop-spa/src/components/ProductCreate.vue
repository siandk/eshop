<template>

  <transition>
    <div class="vue-modal-mask">
      <div class="vue-modal-wrapper">
        <div class="vue-modal-container">

          <div class="vue-modal-header">
            <div class="row">
            <div class="col-6 text-left">
              <h3>Create Product</h3>
            </div>
            <div class="col-6 text-right">
              <button class="btn btn-danger pull-right" @click="$emit('close')">Close</button>
            </div>
            </div>
          </div>

          <div class="vue-modal-body">

            <form @submit.prevent="create" class="row text-left">
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
                    <button id="create" type="submit" class="btn btn-success">Create</button>
                </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </transition>

</template>

<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
export default {
    data() {
        return {
            product: {
              name: "",
              summary: "",
              description: "",
              imageUrl: "",
              unitPrice: 0.0,
              categoryId: "",
              published: true,
              featured: false
            }
        }
    },
    computed: {
        ...mapGetters([
            'getCategories'
        ]),
    },
    methods: {
        create() {
            this.$validator.validateAll().then((result) => {
                console.log(result)
                if (result) {
                  console.log(this.product)
                    axios.post('https://localhost:44334/api/products', this.product, {headers: {'content-type': 'application/json'}})
                        .then(response => console.log(response))
                        .catch(error => console.log(error))
                        .finally(this.$emit('close'))
                }
            })
        }
    }
}
</script>

<style lang="scss" scoped>
.vue-modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, .5);
  display: table;
  transition: opacity .3s ease;
}

.vue-modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.vue-modal-container {
  width: 60%;
  margin: 0px auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, .33);
  transition: all .3s ease;
  font-family: Helvetica, Arial, sans-serif;
}
.vue-modal-header {
  border-bottom: 2px solid black;
  margin-bottom: 10px;
}
.vue-modal-header h3 {
  margin-top: 0;
  color: green;
}

.vue-modal-body {
  margin: 20px 0;
}

.vue-modal-default-button {
  float: right;
}

/*
 * The following styles are auto-applied to elements with
 * transition="modal" when their visibility is toggled
 * by Vue.js.
 *
 * You can easily play with the modal transition by editing
 * these styles.
 */

.vue-modal-enter {
  opacity: 0;
}

.vue-modal-leave-active {
  opacity: 0;
}

.vue-modal-enter .vue-modal-container,
.vue-modal-leave-active .vue-modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>
