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
</script>
<style scoped></style>