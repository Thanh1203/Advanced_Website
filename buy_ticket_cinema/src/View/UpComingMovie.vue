<template>
<header>
    <NavigateHeader/>
</header>
<main>
    <UpComingMoviePage/>
</main>
<footer>
    <FooterContact/>
</footer>
</template>
<script setup>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import UpComingMoviePage from '@/components/UpcomingMovie/UpComingMoviePage.vue';
import FooterContact from '@/components/HomePage/FooterContact.vue';
import { useStore } from 'vuex';
import { onMounted } from 'vue';

const store = useStore()

onMounted(() => {
    store.dispatch('upComingMovie')
})
</script>
<style scoped></style>