<template>
<div class="nav_container">
    <div class="nav_icon">
        <img src="../../assets/logo.png" alt="logo" @click="backHomePage">
    </div>
    <div class="nav_menu">
        <div class="nav_search input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'magnifying-glass']" size="lg" style="color: #000000;" /></span>
            <input type="text" class="form-control from_search" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" v-model="searching">
            <span class="input-group-text cancel_searching" id="basic-addon2" v-if="searching !== null && searching !== ''"><font-awesome-icon :icon="['fas', 'circle-xmark']" size="lg" style="color: #000000;"  @click="btn_cancle_searching"/></span>
        </div>
        <div class="nav_link">
            <p href="#" class="txt_link" @click="goMovieShowing">Phim đang chiếu</p>
            <p href="#" class="txt_link" @click="goUpComingMovie">Phim sắp chiếu</p>
        </div>
        <div class="search_result" v-if="searching !== null && searching !== ''">
            <ul>
                <li v-for="(product, index) in filterProduct" :key="index" class="product_search">
                    <img :src="`${ product.img }`" alt="">
                    <p style="padding-left: 10px;">{{ product.name.toUpperCase() }}</p>
                </li>
                <li v-if="filterProduct.length === 0" class="product_search">
                    <p style="color: red;">Phim đang tìm kiếm không tồn tại!</p>
                </li>
            </ul>
        </div>
    </div>
    <div class="nav_login_user">
        <button type="button" class="btn btn-outline-dark" :class="{ hide: isShow }" @click="goToLogin">Đăng nhập</button>
        <div class="nav_user" :class="{ hide: !isShow }">
            <font-awesome-icon :icon="['fas', 'circle-user']" size="2xl" style="color: #000000;" />
            <div class="nav_user_info"></div>
        </div>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { computed, ref } from 'vue';
import { useStore } from 'vuex';

const store = useStore()
const products = computed(() => store.getters['products'])
const filterProduct = () => {
    if (this.searching == '') {
        return
    } else {
        return products.value.filter(product => {
            return product.name.toLocaleLowerCase().includes(this.searching.toLocaleLowerCase())
        })
    }
}

let searching = ref('')
let isShow = ref(false)

const btn_cancle_searching = ()=>{
    searching.value = ''
}
const backHomePage = () => {
    router.push('/')
}
const goToLogin = ()=>{
    router.push('/Login')
}
const goMovieShowing = () => {
    router.push('/Movie%20showing')
}
const goUpComingMovie = () => {
    router.push('/Up%20coming%20movie')
}
</script>
<style scoped>
.nav_container{
    position: absolute;
    top: 0;
    height: 100px;
    width: 90%;
    display: flex;
    justify-content: space-around;
    align-items: center;
}
.nav_menu
{
    margin-top: 42px;
    position: relative;
}
.nav_menu > div:first-child
{
    width: 600px;
    border: solid 1px black;
    border-radius: 7px;
}
.nav_link
{
    width: 80%;
    display: flex;
    justify-content: space-around
}
.txt_link
{
    text-transform: uppercase;
    font-size: 16px;
    font-weight: bolder;
    margin: 0;
}
.input-group-text {
    background-color: white !important;
}

.from_search {
    border-left: 0 !important;
    border-right: 0 !important;
}

.from_search:focus{
    border-color: transparent !important;
    box-shadow: none !important;
}

.nav_search:focus-within{
    border-color: #86b7fe;
    box-shadow: 0 0 0 0.25rem rgba(13, 110, 253, 0.25)
}

.search_result {
    position: absolute;
    z-index: 2;
    top: 90px;
    width: 100%;
    background-color: white;
}

.product_search {
    height: 60px;
    width: 100%;
    display: flex;
    margin-bottom: 10px;
}

.product_search > img {
    height: 100%;
}
</style>