<template>
<div class="navLogo">
    <img src="../../../assets/logo.png" alt="logo" @click="backHomePage">
</div>
</template>
<script setup>
import router from '@/Router/router';

const backHomePage = () => {
    router.push('/')
}
</script>
<style scoped>
.navLogo {
    width: 100%;
    padding: 15px 0 20px 0;
    height: 73px;
    box-sizing: border-box;
    display: flex;
    justify-content: center;
}
.navLogo > img {
    height: 100%;
}
</style>