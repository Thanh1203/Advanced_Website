<template>
<div class="nav_container">
    <NavLuncher/>
    <navLogo/>
    <NavChangePage/>
</div>
</template>
<script setup>
import NavLuncher from './NavigateItem/NavLuncher.vue'
import navLogo from './NavigateItem/navLogo.vue';
import NavChangePage from './NavigateItem/NavChangePage.vue';
</script>
<style scoped>
.nav_container{
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    border: 1.5px solid #E9E4D2;
    border-bottom: none;
}
</style>