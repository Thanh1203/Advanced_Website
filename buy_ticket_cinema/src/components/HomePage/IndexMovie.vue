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
            <div class="btn_product btn_pre"><font-awesome-icon @click="prevSlide" :icon="['fas', 'angle-left']" size="2xl" style="color: #000000;" /></div>
            <Swiper class="products_list" :modules="module" :watchSlidesProgress="true" :slidesPerView="3"
            :autoplay="{
                delay: 2500,
                disableOnInteraction: false,
            }" :speed="1000" :allowTouchMove="false" @swiper="setSwiperRef" >
                <SwiperSlide v-for="(product) in filterdProduct" :key="product.id" class="product-swiperslide">
                    <div class="product_group">
                        <img :src="require(`@/assets/${product.img}`)" alt="">
                        <div class="product_info">
                            <p>{{ product.name }}</p>
                            <p><strong>Thể Loại:</strong> {{ product.genre }}</p>
                            <p><strong>Thời lượng:</strong> {{ product.duration }}</p>
                            <p><strong>Khởi chiếu: </strong>{{ product.premiere }}</p>
                        </div>
                        <button type="button" class="btn btn-success">BUY TICKET !</button>
                    </div>
                </SwiperSlide>
            </Swiper>
            <div class="btn_product btn_next"><font-awesome-icon @click="nextSlide" :icon="['fas', 'angle-right']" size="2xl" style="color: #000000;" /></div>
        </div>
    </div>
</template>
<script>
import { mapGetters } from 'vuex';
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Autoplay } from 'swiper/modules';

import 'swiper/css';

const selects = ['PHIM ĐANG CHIẾU', 'PHIM SẮP CHIẾU']

let swiperRef = null;

const setSwiperRef = (swiper) => {
    swiperRef = swiper;
};


export default {
    components: {
        Swiper,
        SwiperSlide
    },

    watch: {},

    computed: {
        ...mapGetters(['products']),
        filterdProduct() {
            switch (this.isActive) {
                case 1:
                    return this.products.filter(product => product.status == 2)
                default:
                    return this.products.filter(product => product.status == 1)
            }
        },
    },
    data() {
        return {
            selects,
            isActive: 0,
        }
    },
    methods: {
        changeSelect: function (index) {
            this.isActive = index
        }
    },
    setup() {

        const nextSlide = () => {
            if (swiperRef) {
                swiperRef.slideTo(swiperRef.realIndex + 3);
            }
        };

        const prevSlide = () => {
            if (swiperRef) {
                swiperRef.slideTo(swiperRef.realIndex - 3);
            }
        };

        return {
            module: [Autoplay],
            setSwiperRef,
            nextSlide,
            prevSlide,
        }
    }
}
</script>

<style scoped>
#index {
    text-align: center;
    background-color: rgb(245, 245, 237);
    position: relative;
    padding-top: 50px;
}

.selects_list {
    width: 50%;
    display: flex;
    justify-content: space-between;
    margin: 0 auto 50px;
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

.products{
    display: flex;
}

.products_list{
    flex-basis: 80%;
    height: 500px;
}

.product-swiperslide {
    padding: 10px;
    height: 100%;
    width: 310px;
    display: flex;
    justify-content: center;
}

.product_group {
    width: 290px;
    overflow: hidden;
    text-align: center;
    position: relative;
}

.product_group img {
    height: 275px;
    border: 6px solid black;
}

.product_info
{
    text-align: left;
    margin-top: 6px;
    margin-bottom: 6px;
    margin-left: 45px;
}

p
{
    margin: 0;
}
.product_info p:first-child {
    width: 200px;
    font-family: Verdana;
    font-size: 15px;
    font-weight: bolder;
}

.product_info p:nth-of-type(2){
    width: 200px;
    font-family: Verdana;
    font-size: 14px;
}

.product_info p:nth-of-type(3){
    font-family: Verdana;
    font-size: 14px;
}

.product_info p:last-child {
    font-family: Verdana;
    font-size: 14px;
}
.btn-success
{
    margin-left: -75px;
    position: absolute;
    bottom: 0;
}

.btn_product {
    flex-basis: 10%;
    display: flex;
    align-items: center;
    font-size: 2rem;
}

.btn_pre {
    justify-content: end;
    padding-right: 20px;
}

.btn_next {
    padding-left: 20px;
}

</style>