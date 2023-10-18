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
    </footer>
</template>
<script setup>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import SliderMain from '@/components/HomePage/SliderMain.vue'
import IndexMovie from '@/components/HomePage/IndexMovie.vue';
import EventUser from '@/components/HomePage/EventUser.vue';
import ContactUser from '@/components/HomePage/ContactUser.vue';
import NotificationCinema from '@/components/HomePage/NotificationCinema.vue';
import { useStore } from 'vuex';
import { onMounted } from 'vue';

const store = useStore()

onMounted(() => {
  store.dispatch('loadProducts')
  store.dispatch('loadEvents')
  store.dispatch('loadSlide')
})
</script>
<style scoped>
header {
    height: 130px;
    width: 100%;
    position: relative;
    display: flex;
    justify-content: center;
    align-items: center;
}
main {
    position: relative;
    width: 100%;
}
footer {
    border-top: 1px solid #e5e5e5;
    position: relative;
    width: 100%;
}
</style>