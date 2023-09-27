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
                            <div class="product-name"><p>{{ product.name }}</p></div>
                            <div class="box-info">
                                <p><strong>Thể Loại:</strong> {{ product.genre }}</p>
                                <p><strong>Thời lượng:</strong> {{ product.duration }}</p>
                                <p><strong>Khởi chiếu: </strong>{{ product.premiere }}</p>
                            </div>
                        </div>
                        <button type="button" class="btn buy-btn" @click="buyTicket">BUY TICKET !</button>
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
        },
        buyTicket: function () {
            this.$router.push("/Buy_ticket")
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
    background-color: white;
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
    padding: 10px; 
    border-radius: 30px;
    font-weight: bold;
}

.selects_list li.active {
    background-color: rgb(218, 41, 28);
    color: white;
    filter: blur(0);
    border: 1px solid rgb(218, 41, 28);
    box-shadow: 0 0 5px 5px rgb(218, 41, 28);
}

.products{
    display: flex;
    height: 550px;
}

.products_list{
    flex-basis: 80%;
    height: 550px;
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
    position: relative;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.product_group img {
    height: 334px;
    width: 228px;
    margin: 0 31px;
}

.product_info
{
    height: 155px;
    width: 228px;
    display: flex;
    flex-direction: column;
    align-items: start;
    justify-content: space-between;
}
.product_info p
{
    margin: 0;
    font-family: Verdana;
    font-size: 14px;
}
.product-name {
    width: 100%;
    height: 50px;
    overflow: hidden;
}
.product-name > p {
    font-size: 15px;
    font-weight: bolder;
    word-break: break-word;
    line-height: 1.6;
    text-align: left;
}
.box-info {
    display: flex;
    height: 100px;
    width: 100%;
    flex-direction: column;
    padding-bottom: 10px;
    align-items: start;
}
.box-info p {
    word-break: break-word;
    width: 100%;
    text-align: left;
}

.buy-btn
{
    background-color: rgb(218, 41, 28);
    border: 1px solid white;
    color: white;
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