<template>
    <div id="index">
        <div class="select_index">
            <ul class="selects_list">
                <li v-for="(select, index) in selects" :key="index"
                :class="{ active: isActive == index }" @click="changeSelect(index)">
                    {{ select }}
                </li>
            </ul>
        </div>
        <div class="products">
            <div class="btn_pre"></div>
            <Swiper class="products_list" :modules="module" :watchSlidesProgress="true" :slidesPerView="3">
                <SwiperSlide v-for="(product) in products" :key="product.id" class="product-swiperslide">
                    <div class="box">
                        <img :src="require(`@/assets/${product.img}`)" alt="">
                        <p>{{ product.name }}</p>
                        <button type="button" class="btn btn-success">BUY TICKET !</button>
                    </div>
                </SwiperSlide>
            </Swiper>
            <div class="btn_next"></div>
        </div>
    </div>
</template>
<script>
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Autoplay } from 'swiper/modules';

import 'swiper/css';


const selects = ['PHIM ĐANG CHIẾU', 'PHIM SẮP CHIẾU', 'VÉ BÁN TRƯỚC']
const products = [
    {
        id: 1,
        name: 'BẾN PHÀ XÁC SỐNG',
        img: '11224_103_100001.jpg',
        status: 'available'
    },
    {
        id: 2,
        name: 'ÁC QUỶ MA SƠ 2',
        img: '11224_103_100001.jpg',
        status: 'coming soon'
    },
    {
        id: 3,
        name: 'KẺ ẨN DANH',
        img: '11224_103_100001.jpg',
        status: 'oder'
    },
    {
        id: 4,
        name: 'BỘ ĐÔI BÁO THỦ',
        img: '11224_103_100001.jpg',
        status: 'oder'
    },
    {
        id: 5,
        name: 'ĐỊA ĐÀNG SỤP ĐỔ',
        img: '11224_103_100001.jpg',
        status: 'available'
    },
    {
        id: 6,
        name: '3DCG! SHIN - CẬU BÉ BÚT CHÌ: ĐẠI CHIẾN SIÊU NĂNG LỰC ~ SHUSI BAY',
        img: '11206_103_100003.jpg',
        status: 'coming soon'
    },
    {
        id: 7,
        name: 'NHÂN DUYÊN TIỀN ĐÌNH',
        img: '11224_103_100001.jpg',
        status: 'available'
    },
]

export default {
    components: {
        Swiper,
        SwiperSlide
    },
    data() {
        return {
            selects,
            products,
            isActive: 0
        }
    },
    methods: {
        changeSelect: function (index) {
            this.isActive = index
        }
    },
    setup() {
        return {
            module: [ Autoplay]
        }
    }
}
</script>

<style>
#index {
    text-align: center;
}

.selects_list {
    width: 70%;
    display: flex;
    justify-content: space-between;
    margin: 50px auto;
}

.selects_list li {
    font-size: 1.4rem;
    cursor: default;
    color: #737171;
    border: 5px solid greenyellow;
    padding: 10px; 
    border-radius: 30px;
    font-weight: bold;
}

.selects_list li.active {
    background-color: greenyellow;
    color: rgb(65, 64, 64);
    filter: blur(0);
}

.products_list {
    height: 450px;
    width: 80%;
}

.box {
    background-color: rgb(22, 99, 167);
    height: 450px;
    width: 220px;
    padding: 10px;
}
.box >img {
    height: 272px;
    width: 197px;
}
</style>