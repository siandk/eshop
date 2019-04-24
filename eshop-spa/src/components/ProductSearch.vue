<template>
    <div class="col-12">
        <div class="row">
        <div class="col-8">
            <strong>Search: </strong><input v-on:keyup="$emit('searchProducts', search)" class="search-bar" type="text" v-model="search">
        </div>
        <div class="col-3">
            <strong>Order by: </strong>
            <select v-on:change="$emit('orderProducts', orderBy)" v-model="orderBy">
                <option value="priceAsc">Price asc.</option>
                <option value="priceDesc">Price desc.</option>
                <option value="name">Name</option>
            </select>
        </div>
        </div>
    </div>
</template>

<script>
export default {
    data () {
        return {
            search: "",
            orderBy: "priceAsc"
        }
    }
}
</script>

<style scoped>
strong {
    font-size: 20px;
    color: green;
}
select {
    margin-top: 20px;
}
.search-bar {
    width: 70%;
    margin-top: 20px;
}
.col-12 {
    border-bottom: 2px solid green;
    padding-bottom: 30px;
}
</style>
