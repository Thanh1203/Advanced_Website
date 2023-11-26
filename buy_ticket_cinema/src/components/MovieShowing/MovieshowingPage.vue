<template>
<div id="movieshowing">
    <div class="movieshowing_ctn">
        <div class="movieshowing_header">
            <h2>Phim Đang Chiếu</h2>
        </div>
        <div class="movieshowing_body">
            <div v-for="(product,index) in products" :key="product.id" :data-id="`${product.id}`" class="product_item" ref="productItem">
                <div class="product_img" @click="goDetailMovie(index)">
                    <img :src="`${product.img}`" :alt="`${product.name}`">
                </div>
                <div class="product_item-info" @click="goDetailMovie(index)">
                    <p class="product_name">{{ product.name.toUpperCase() }}</p>
                    <div class="box-info">
                        <p><strong>Thể Loại:</strong> {{ product.genre }}</p>
                        <p><strong>Thời lượng:</strong> {{ product.duration }} phút</p>
                        <p><strong>Khởi chiếu: </strong>{{ product.premiere }}</p>
                    </div>
                </div>
                <div class="product_btn">
                    <button type="button" class="btn buy-btn" @click="buyTicket">
                        <font-awesome-icon :icon="['fas', 'ticket']" size="lg" style="color: #ffffff;" />
                        <span style="padding-left: 10px; font-weight: bold;">Mua vé</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { computed, ref } from 'vue';
import { useStore } from 'vuex';
import idMovieLS from '@/localStorage/idMovieLS'

const store = useStore()

const products = computed(() => store.getters['dataMovieIsShowing'])
const dataProducts = computed(() => store.getters['products'])

const productItem = ref(null)

const goDetailMovie = (index) => {
    const IdproductItem = productItem.value[index].attributes[1].value
    const data = dataProducts.value.find(item => item.id == IdproductItem)
    store.commit('setMovieDetail', data)
    router.push('/Detail%20movie')
    idMovieLS.set(IdproductItem)
}

const buyTicket = () => {
    router.push('/Buy%20ticket')
}
</script>
<style scoped>
#movieshowing {
    background-color: #f1f0e5;
    width: 100%;
    display: flex;
    justify-content: center;
}
.movieshowing_ctn {
    width: 980px;
}
.movieshowing_ctn .movieshowing_header {
    width: 100%;
    height: 65px;
    border-bottom: 2px solid #222;
    margin-top: 30px;
    margin-bottom: 35px;
}

.movieshowing_ctn .movieshowing_body {
    width: 100%;
    display: flex;
    flex-wrap: wrap;
}

.movieshowing_ctn .movieshowing_body .product_item {
    width: 197px;
    height: 482px;
    margin: 24px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}

.movieshowing_body .product_item .product_img {
    height: 277px;
    width: 100%;
}

.product_item .product_img >img {
    width: 100%;
    height: 100%;
}

.product_item .product_item-info {
    flex-grow: 1;
    padding: 5px 5px 0 0;
}
.product_item .product_item-info .product_name {
    font-size: 15px;
    font-weight: 700;
    color: #000;
    height: 50px;

}
.product_item .product_item-info .box-info {
    display: flex;
    height: 100px;
    width: 100%;
    flex-direction: column;
    padding-bottom: 10px;
    align-items: start;
}
.product_item-info .box-info p {
    word-break: break-word;
    width: 100%;
    text-align: left;
    margin-bottom: 0;
}

.product_item .product_btn {
    height: 36px;
}
.product_item .product_btn .buy-btn
{
    background-color: rgb(218, 41, 28);
    color: white;
    border: none;
}
</style>