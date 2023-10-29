<template>
<div class="nav_search input-group mb-3">
    <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'magnifying-glass']" size="lg" style="color: #000000;" /></span>
    <input type="text" class="form-control from_search" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" v-model="searching">
    <span class="input-group-text cancel_searching" id="basic-addon2" v-if="searching !== null && searching !== ''"><font-awesome-icon :icon="['fas', 'circle-xmark']" size="lg" style="color: #000000;"  @click="btn_cancle_searching"/></span>
</div>
<div class="search_result" v-if="searching !== null && searching !== ''">
    <ul>
        <li v-for="(product, index) in filterProduct" :key="index" class="product_search">
            <img :src="`${product.img}`" alt="">
            <p style="padding-left: 10px;">{{ product.name.toUpperCase() }}</p>
        </li>
        <li v-if="filterProduct.length === 0" class="product_search">
            <p style="color: red;">Phim đang tìm kiếm không tồn tại!</p>
        </li>
    </ul>
</div>
</template>
<script setup>
import { store } from '@/store/store';
import { computed, ref } from 'vue';

const dataProducts = computed(() => store.getters['products'])
let searching = ref('')

function filterProduct() {
    if (searching.value == '') {
        return
    } else return dataProducts.value.filter(product => product.name.toLocaleLowerCase().includes(this.searching.toLocaleLowerCase()))
}

const btn_cancle_searching = () => {
    searching.value = ''
}
</script>
<style scoped>
.nav_search:focus-within{
    border-color: #86b7fe;
    box-shadow: 0 0 0 0.25rem rgba(218, 41, 28, .5);
    border-radius: 10px;
}

.nav_search .input-group-text:nth-of-type(1) {
    border-right: none;
}

.nav_search .input-group-text {
    background-color: white !important;
}

.nav_search .from_search {
    border-left: none;
}

.nav_search .from_search:focus {
    border: var(--bs-border-width) solid var(--bs-border-color);
    border-left: none;
    box-shadow: none;
}

.search_result {
    position: absolute;
    z-index: 2;
    top: 90px;
    width: 100%;
    background-color: white;
}

.search_result .product_search {
    height: 60px;
    width: 100%;
    display: flex;
    margin-bottom: 10px;
}

.search_result .product_search > img {
    height: 100%;
}
</style>