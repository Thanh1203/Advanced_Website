<template>
    <header>
        <NavigateHeader></NavigateHeader>
    </header>
    <main>
        <SliderMain></SliderMain>
        <IndexMovie></IndexMovie>
        <EventUser></EventUser>
        <ContactUser></ContactUser>
    </main>
</template>
<script>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import SliderMain from '@/components/HomePage/SliderMain.vue'
import IndexMovie from '@/components/HomePage/IndexMovie.vue';
import EventUser from '@/components/HomePage/EventUser.vue';
import ContactUser from '@/components/HomePage/ContactUser.vue';

export default {
    components: {
        NavigateHeader,
        SliderMain,
        IndexMovie,
        EventUser,
        ContactUser,
    },
    data() {
        return {}
    }
}
</script>
<style>
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
    height: 1900px;
    width: 100%;
}
</style>