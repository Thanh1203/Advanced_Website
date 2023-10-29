<template>
<div class="nav_change-page" ref="navChangePage">
    <p class="nav_change-txt" @click="goMovieShowing">Phim đang chiếu</p>
    <p class="nav_change-txt" @click="goUpComingMovie">Phim sắp chiếu</p>
    <p class="nav_change-txt" v-show="isLogin" @click="goUserInfo">Thông tin cá nhân</p>
    <p class="nav_change-txt" v-show="isLogin">Thông tin vé</p>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { store } from '@/store/store';
import { computed, ref, watch } from 'vue';

const navChangePage = ref(null)

const isLogin = computed(() => {
    if (store.getters['getIsLoginUser']) {
        return true;
    } else return false
})

watch(isLogin, newValue => {
    if (newValue) {
        navChangePage.value.style.width = '100%'
    } else {
        navChangePage.value.style.width = '80%'
    }
})

const goMovieShowing = () => {
    router.push('/Movie%20showing')
}
const goUpComingMovie = () => {
    router.push('/Up%20coming%20movie')
}
const goUserInfo = () => {
    router.push('/User%20Information')
}
</script>
<style scoped>
.nav_change-page {
    display: flex;
    justify-content: space-around
}

.nav_change-page .nav_change-txt {
    text-transform: uppercase;
    font-size: 14px;
    font-weight: bolder;
    margin: 0;
    cursor: pointer;
}
</style>