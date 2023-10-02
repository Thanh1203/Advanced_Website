<template>
    <div id="notice">
        <div class="notice_ctn">
            <div class="notice-content">
                <p>Thông báo</p>
                <Swiper
                :direction="'vertical'" :allowTouchMove="false"
                :modules="modules" :speed="1000"
                @swiper="setSwiperRef" :loop="true"
                class="notice-slide"
                >
                    <swiper-slide class="notice-slide-item"
                    v-for="(ctent, index) in noticeArr" :key="index">
                        <p>{{ ctent.content }}</p>
                    </swiper-slide>
                </Swiper>
                <div class="notice-btn-more">
                    <a href="#" class="txt_link">
                        more
                        <font-awesome-icon :icon="['fas', 'circle-chevron-right']" style="color: #000000;" />
                    </a>
                </div>
            </div>
            <div class="notice-btn">
                <div class="notice-btn-item" style="border-bottom: .5px solid #e5e5e5;" @click="upNotice"><font-awesome-icon :icon="['fas', 'caret-up']" style="color: #000000;" /></div>
                <div class="notice-btn-item" style="border-top: .5px solid #e5e5e5;" @click="downNotice"><font-awesome-icon :icon="['fas', 'caret-down']" style="color: #000000;" /></div>
            </div>
        </div>
    </div>
</template>
<script setup>
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Pagination } from 'swiper/modules';

import 'swiper/css';
import { ref } from 'vue';

const modules = ref([Pagination])
const noticeArr = ref([
    {
        content: "Đồng giá 45k cả tuần tại rạp Huế"
    },
    {
        content: "Đồng giá 50k cả tuần tại rạp Thủ Đức"
    },
    {
        content: "Đồng giá 55k cả tuần tại rạp Cà Mau"
    },
])

let swiperRef = null;


const setSwiperRef = (swiper) => {
    swiperRef = swiper;
};

const upNotice = () => {
    if (swiperRef) {
        swiperRef.slideNext();
    }
}

const downNotice = () => {
    if (swiperRef) {
        swiperRef.slidePrev();
    }
}
</script>
<style scoped>
#notice{
    border-bottom: 1px solid #e5e5e5;
    height: 57px;
}

.notice_ctn {
    width: 980px;
    height: 100%;
    margin: 0 auto;
    display: flex;
}

.notice-content {
    width: calc(100% - 49px);
    display: flex;
    align-items: center;
}

.notice-content > p {
    width: 82px;
    font-size: 16px;
    color: #231f20;
    font-weight: bold;
    margin: 0;
}

.notice-slide {
    height: 24px;
    width: calc(100% - 82px - 70px);
}

.notice-slide-item {
    padding-left: 10px;
    display: flex;
    align-items: center;
}

.notice-slide-item > p {
    margin: 0;
    font-size: 14px;
}

.notice-btn-more {
    width: 70px;
    padding-right: 17px;
}

.notice-btn-more > a {
    font-size: 11px;
    color: #666;
    font-weight: 300;
}

.notice-btn {
    background-color: aliceblue;
    width: 49px;
    height: 58px;
    display: flex;
    flex-direction: column;
}

.notice-btn-item {
    width: 100%;
    height: 29px;
    display: flex;
    justify-content: center;
    align-items: center;
    cursor: pointer;
}


</style>