<template>
    <header>
        <NavigateHeader/>
    </header>
    <main>
        <SliderMain/>
        <IndexMovie/>
        <EventUser/>
        <ContactUser/>
    </main>
    <footer>
        <NotificationCinema/>
        <FooterContact/>
    </footer>
</template>
<script setup>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import SliderMain from '@/components/HomePage/SliderMain.vue'
import IndexMovie from '@/components/HomePage/IndexMovie.vue';
import EventUser from '@/components/HomePage/EventUser.vue';
import ContactUser from '@/components/HomePage/ContactUser.vue';
import NotificationCinema from '@/components/HomePage/NotificationCinema.vue';
import FooterContact from '@/components/HomePage/FooterContact.vue';

import { useStore } from "vuex";
import { onMounted } from "vue";

const store = useStore();

onMounted(() => {
    store.dispatch("loadProducts");
    store.dispatch("loadSlide");
    store.dispatch("loadEvents");
})

</script>
<style scoped>
</style>