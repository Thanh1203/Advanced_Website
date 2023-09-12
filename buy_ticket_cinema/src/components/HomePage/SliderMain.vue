<template>
    <div id="slider">
        <Swiper :modules="module" navigation :loop="true" :pagination="{ clickable: true }"
        :autoplay="{
            delay: 3000,
            disableOnInteraction: false,
        }" :speed="1000">
            <SwiperSlide v-for="(photo, index) in photos" :key="index"
            :style="{
                'background-image': `url(${require(`../../assets/${photo.img}`)})`,
                'background-size': 'cover',
                'background-position': 'center',
            }" class="slide-swiperslide">
                <img :src="require(`@/assets/${photo.img}`)" alt="">
            </SwiperSlide>
        </Swiper>
    </div>
</template>
<script>
// import { mapGetters } from 'vuex';
import { Swiper, SwiperSlide} from 'swiper/vue';
import { Navigation, Pagination, Autoplay  } from 'swiper/modules';

import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

const photos = [
    {
        name: 'BẾN PHÀ XÁC SỐNG',
        img: '11224_104_100002.jpg'
    },
    {
        name: 'ÁC QUỶ MA SƠ 2',
        img: '11229_105_100007.jpg'
    },
    {
        name: 'KẺ ẨN DANH',
        img: '11186_105_100001.jpg'
    },
    {
        name: 'BỘ ĐÔI BÁO THỦ',
        img: '11225_105_100001.jpg'
    },
    {
        name: 'ĐỊA ĐÀNG SỤP ĐỔ',
        img: '11221_105_100008.jpg'
    },
    {
        name: '3DCG! SHIN - CẬU BÉ BÚT CHÌ: ĐẠI CHIẾN SIÊU NĂNG LỰC ~ SHUSI BAY',
        img: '11206_105_100007.jpg'
    },
    {
        name: 'NHÂN DUYÊN TIỀN ĐÌNH',
        img: '11233_105_100001.jpg'
    },
    {
        name: 'TRỪNG PHẠT',
        img: '11245_105_100001.jpg'
    },
    {
        name: 'ÁN MẠNG Ở VENICE',
        img: '11231_105_100007.jpg'
    },
    {
        name: 'LIVE - #pháttrựctiếp',
        img: '11235_105_100001.jpg'
    },
]


export default {
    // computed: {
    //     computed: {
    //         ...mapGetters(['photos']),
    //     },
    // },

    components: {
        Swiper,
        SwiperSlide
    },

    setup() {
        return {
            photos,
            module: [Navigation, Pagination, Autoplay]

        }
    },
}
</script>
<style> 

#slider{
    position: relative;
}

.slide-swiperslide{
    text-align: center;
    height: 600px;
}

.slide-swiperslide::before {
    content: "";
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(255, 255, 255, 0.5);
    z-index: -1;
    filter: blur(10px);
}

.swiper-pagination{
    height: 20px;
}

.swiper-pagination-bullet{
    height: 15px;
    width: 15px;
    border: 1px solid greenyellow;
    opacity: .5 !important;
    background-color: black;
}

.swiper-pagination-bullet-active{
    background-color: greenyellow !important;
}
</style>