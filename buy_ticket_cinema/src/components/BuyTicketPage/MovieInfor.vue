<template>
<div class="detailMove_ctn">
    <div class="detailMovie_header">
        <h2>Mua vé</h2>
    </div>
    <div class="detailMovie_body">
        <div class="detailMovie_img">
            <img :src="`${inforMovie?.img}`" @error="setAltImg">
        </div>
        <div class="detailMovie_info">
            <div class="detailMovie_name"> 
                <p>{{ inforMovie?.name?.toUpperCase() }}</p>
            </div>
            <div class="detailMovie_info-box">
                <p><strong>Thể Loại:</strong> {{ inforMovie?.genre }}</p>
                <p><strong>Thời lượng:</strong> {{ inforMovie?.duration }} phút</p>
                <p><strong>Khởi chiếu: </strong>{{ inforMovie?.premiere }}</p>
            </div>
        </div>
    </div>
</div>
</template>
<script setup>
import { store } from '@/store/store';
import { computed } from 'vue';

const inforMovie = computed(() => store.getters['getMovieBuyTicket'])
</script>
<style scoped>
.detailMove_ctn {
    width: 100%;
    margin-bottom: 30px;
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
</style>