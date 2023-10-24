<template>
<div id="detailMovie">
    <div class="detailMove_ctn">
        <div class="detailMovie_header">
            <h2>Nội Dung Phim</h2>
        </div>
        <div class="detailMovie_body" v-bind="product">
            <div class="detailMovie_img">
                <img :src="`${product?.img}`" :alt="`${product?.name}`">
            </div>
            <div class="detailMovie_info">
                <div class="detailMovie_name"> 
                    <p>{{ product?.name?.toUpperCase() }}</p>
                </div>
                <div class="detailMovie_info-box">
                    <p><strong>Thể Loại:</strong> {{ product?.genre }}</p>
                    <p><strong>Thời lượng:</strong> {{ product?.duration }} phút</p>
                    <p><strong>Khởi chiếu: </strong>{{ product?.premiere }}</p>
                </div>
            </div>
        </div>
        <div class="detailMovie_btn">
            <button type="button" class="btn buy-btn" @click="buyTicket">
                <font-awesome-icon :icon="['fas', 'ticket']" size="lg" style="color: #ffffff;" />
                <span style="padding-left: 10px; font-weight: bold;">Mua vé</span>
            </button>
            <button type="button" class="btn trailer-btn" @click="watchTicket">
                <font-awesome-icon :icon="['fas', 'video']" size="lg" style="color: #ffffff;" />
                <span style="padding-left: 10px; font-weight: bold;">Trailer</span>
            </button>
        </div>
        <div class="detailMovie_synopsis" v-bind="product">
            <p>Tóm tắt</p>
            {{ product?.content }}
        </div>
    </div>
</div>
</template>
<script setup>
// import idMovieDetailLocalStore from '@/localStorage/idMovieDetailLocalStore';
import { computed } from 'vue';
import { useStore } from 'vuex';

const store = useStore()
const product = computed(() => store.getters['movieDetail'])

</script>
<style scoped>
#detailMovie {
    width: 100%;
    display: flex;
    justify-content:center;
    background-color: #f1f0e5;
}
.detailMove_ctn {
    width: 980px;
}
.detailMove_ctn .detailMovie_header {
    width: 100%;
    height: 65px;
    border-bottom: 2px solid #222;
    margin-top: 30px;
    margin-bottom: 20px;
}
.detailMove_ctn .detailMovie_header > h2 {
    font-weight: 600;
    color: #1a1919;
}
.detailMove_ctn .detailMovie_body {
    display: flex;
}

.detailMove_ctn .detailMovie_body .detailMovie_img {
    width: 181px;
    margin-right: 15px;
}
.detailMovie_body .detailMovie_img > img {
    width: 100%;
}
.detailMove_ctn .detailMovie_body .detailMovie_info {
    flex-grow: 1;
    padding-left: 15px;
}
.detailMovie_body .detailMovie_info .detailMovie_name{
    height: 52px;
    margin-bottom: 10px;
    border-bottom: 1px solid #d9d6c8;
    color: #1a1919;
}
.detailMovie_info .detailMovie_name > p {
    font-size: 24px;
    font-weight: 700;
}
.detailMove_ctn .detailMovie_btn {
    width: 100%;
    height: 50px;
    margin: 20px 0 30px 0;
    display: flex;
    justify-content: space-around;
    align-items: center;
}
.detailMove_ctn .detailMovie_btn .btn {
    background-color: rgb(218, 41, 28);
    height: 100%;
    padding: 10px 16px;
    color: #fff;
}
.detailMove_ctn .detailMovie_synopsis {
    margin-bottom: 50px;
}
.detailMove_ctn .detailMovie_synopsis > p {
    font-size: 22px;
    color: #231f20;
    font-weight: 700;
}
</style>