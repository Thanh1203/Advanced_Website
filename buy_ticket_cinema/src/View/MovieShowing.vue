<template>
<header>
    <NavigateHeader/>
</header>
<main>
    <MovieshowingPage/>
</main>
<footer>
    <FooterContact/>
</footer>
</template>
<script setup>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import MovieshowingPage from '@/components/MovieShowing/MovieshowingPage.vue';
import FooterContact from '@/components/HomePage/FooterContact.vue';
import { useStore } from 'vuex';
import { onMounted } from 'vue';

const store = useStore()

onMounted(() => {
    store.dispatch('movieShowing')
})
</script>
<style scoped></style>