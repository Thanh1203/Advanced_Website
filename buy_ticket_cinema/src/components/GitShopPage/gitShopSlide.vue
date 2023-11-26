<template>
<Swiper class="gitSlide" :modules="module" :autoplay="{delay: 2500, disableOnInteraction: false, }"  :speed="1000"
    :pagination="{
        clickable: true,
    }"
    :navigation="true">
    <SwiperSlide class="gitSlideItem">
        <img src="@/assets/slideGitShop1.jpg">
    </SwiperSlide>
    <SwiperSlide class="gitSlideItem">
        <img src="@/assets/slideGitShop2.jpg">
    </SwiperSlide>
</Swiper>
</template>
<script setup>
import { Swiper, SwiperSlide } from 'swiper/vue';
import { ref } from 'vue';
import { Autoplay, Pagination, Navigation } from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/pagination';
import 'swiper/css/navigation';

const module = ref([Autoplay, Pagination, Navigation]);
</script>
<style scoped>
.gitSlide {
    height: 420px;
    width: 100%;
}

.gitSlideItem {
    height: 100%;
    display: flex;
    justify-content: center;
    overflow: hidden;
}
    
.gitSlide .gitSlideItem > img {
    height: 100%;
}
</style>