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
                        <div class="product_in4">
                            <p>{{ product.name }}</p>
                            <p>Thể Loại: {{ product.genre }}</p>
                            <p>Thời lượng: {{ product.duration }}</p>
                            <p>Khởi chiếu: {{ product.premiere }}</p>
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
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Autoplay } from 'swiper/modules';

import 'swiper/css';

const selects = ['PHIM ĐANG CHIẾU', 'PHIM SẮP CHIẾU']
const products = [
    {
        id: 1,
        name: 'BẾN PHÀ XÁC SỐNG',
        img: '11224_103_100001.jpg',
        genre: 'Hồi hộp',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 2,
        name: 'ÁC QUỶ MA SƠ 2',
        img: '11229_103_100001.jpg',
        genre: 'Bí ẩn, Kinh Dị',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 3,
        name: 'KẺ ẨN DANH',
        img: '11186_103_100002.jpg',
        genre: 'Gia đình, Hài, Hành Động',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 4,
        name: 'BỘ ĐÔI BÁO THỦ',
        img: '11225_103_100002.jpg',
        genre: 'Hành Động',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 5,
        name: 'ĐỊA ĐÀNG SỤP ĐỔ',
        img: '11221_103_100004.jpg',
        genre: 'Hành Động, Hồi hộp',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 6,
        name: '3DCG! SHIN - CẬU BÉ BÚT CHÌ: ĐẠI CHIẾN SIÊU NĂNG LỰC ~ SHUSI BAY',
        img: '11206_103_100003.jpg',
        genre: 'Hoạt Hình',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 1
    },
    {
        id: 7,
        name: 'NHÂN DUYÊN TIỀN ĐÌNH',
        img: '11233_103_100002.jpg',
        genre: 'Hài, Tình cảm',
        duration: '119 phút',
        premiere: '15-09-2023',
        status: 2
    },
        {
        id: 8,
        name: 'ÁN MẠNG Ở VENICE',
        img: '11231_103_100002.jpg',
        genre: 'Kinh Dị, Tâm Lý, Tội phạm',
        duration: '103 phút',
        premiere: '15-09-2023',
        status: 2
    },
        {
        id: 9,
        name: 'TRỪNG PHẠT',
        img: '11245_103_100001.jpg',
        genre: 'Hành Động, Tội phạm',
        duration: '91 phút',
        premiere: '15-09-2023',
        status: 2
    },
        {
        id: 10,
        name: 'THANH TRA SÁT NHÂN',
        img: '11200_103_100003.jpg',
        genre: 'Hành Động, Tội phạm',
        duration: '102 Phút',
        premiere: '28/07/2023',
        status: 1
    },
]

let swiperRef = null;

const setSwiperRef = (swiper) => {
    swiperRef = swiper;
};


export default {
    components: {
        Swiper,
        SwiperSlide
    },

    watch: {
    },

    computed: {
        filterdProduct() {
            switch (this.isActive) {
                case 1:
                    return products.filter(product => product.status == 2)
                default:
                    return products.filter(product => product.status == 1)
            }
        },
    },
    data() {
        return {
            selects,
            products,
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
}

.product_group img {
    height: 275px;
    border: 6px solid black;
}

.product_in4
{
    text-align: left;
    margin-left: 45px;
}
.product_in4 p:first-child {
    width: 200px;
    height: 18px;
    font-family: Verdana;
    font-size: 15px;
    font-weight: bolder;
    margin-top: 5px;
}

.product_in4 p:nth-of-type(2){
    width: 200px;
    height: 35px;
    font-family: Verdana;
    font-size: 14px;
    font-weight: bolder;
    margin-top: -10px;
}

.product_in4 p:nth-of-type(3){
    color: violet;
}


.product_in4 p:last-child {
    color: green;
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