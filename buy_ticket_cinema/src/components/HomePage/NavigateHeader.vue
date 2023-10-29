<template>
<div class="nav_container">
    <div class="nav_icon">
        <img src="../../assets/logo.png" alt="logo" @click="backHomePage">
    </div>
    <div class="nav_menu">
        <NavSearch/>
        <NavChangePage/>
    </div>
    <div class="nav_login_user">
        <button type="button" class="btn btn-outline-dark btn_login" @click="goToLogin" v-show="!isShow">Đăng nhập</button>
        <button type="button" class="btn btn-outline-dark"  v-show="isShow" @click="logout">Đăng xuất</button>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { computed, onMounted} from 'vue';
import { store } from '@/store/store';
import NavChangePage from './NavChangePage.vue'
import NavSearch from './NavSearch.vue';

onMounted(() => {
    store.dispatch('loadIsLoginUser')
})
let isShow = computed(() => store.getters['getIsLoginUser'])

const backHomePage = () => {
    router.push('/')
}
const goToLogin = ()=>{
    router.push('/Login')
}

const logout = () => {
    window.sessionStorage.setItem('token', '')
    window.sessionStorage.setItem('islogin', false)
    store.dispatch('loadIsLoginUser')
}
</script>
<style scoped>
.nav_container{
    height: 100px;
    width: 90%;
    display: flex;
    justify-content: space-around;
}

.nav_container .nav_icon {
    flex-basis: 20%;
}

.nav_icon > img {
    width: 100%;
}
.nav_container .nav_menu
{
    position: relative;
    flex-basis: 65%;
    height: 100%;
}
.nav_menu > div:first-child
{
    width: 100%;
    border: solid 1px black;
    border-radius: 7px;
}

.nav_container .nav_login_user {
    flex-basis: 9%;
    height: 38px;
}

.nav_container .nav_login_user .btn_login {
    height: 100%;
    box-sizing: border-box;
}
</style>