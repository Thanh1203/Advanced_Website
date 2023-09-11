<template>
    <header>
        <NavigateHeader></NavigateHeader>
    </header>
    <main>
        <SliderMain></SliderMain>
        <IndexMovie></IndexMovie>
    </main>
</template>
<script>
import NavigateHeader from '@/components/HomePage/NavigateHeader.vue';
import SliderMain from '@/components/HomePage/SliderMain.vue'
import IndexMovie from '@/components/HomePage/IndexMovie.vue';

export default {
    components: {
        NavigateHeader,
        SliderMain,
        IndexMovie
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
    top: 0%;
    background-color: aquamarine;
}
main {
    height: 1900px;
    width: 100%;
}
</style>