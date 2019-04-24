<template>

  <transition>
    <div class="vue-modal-mask">
      <div class="vue-modal-wrapper">
        <div class="vue-modal-container">

          <div class="vue-modal-header">
              <h2>Are you sure you want to delete {{product.name}}?</h2>
          </div>

          <div class="vue-modal-body">
                <div class="col-12 text-center">
                    <button class="btn btn-danger" @click="deleteProduct()">Confirm</button>
                    <button class="btn btn-warning" @click="$emit('close')">Close</button>
                </div>
            </div>
        </div>
      </div>
    </div>
  </transition>

</template>

<script>
import axios from 'axios'

export default {
    props: ['product'],
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

.vue-modal-header h3 {
  margin-top: 0;
  margin-bottom: 10px;
  color: green;
  border-bottom: 2px solid black;
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
